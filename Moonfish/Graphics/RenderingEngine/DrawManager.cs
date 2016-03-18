using System.Collections.Generic;
using System.Linq;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     Sorts render calls into optimized batches
    /// </summary>
    internal class DrawManager
    {
        private static readonly Comparer<float> DistanceComparer = Comparer<float>.Create( ( a, b ) => a <= b ? 1 : -1 );

        private readonly Dictionary<GlobalGeometryPartBlockNew, TagGlobalKey> _shaderDictionary =
            new Dictionary<GlobalGeometryPartBlockNew, TagGlobalKey>( );

        private InstanceManager InstanceManager { get; } = new InstanceManager( );


        public void AssignShader( GlobalGeometryPartBlockNew part, CacheKey cacheKey, TagIdent shaderIdent )
        {
            var glocalKey = new TagGlobalKey( cacheKey, shaderIdent );
            //  Does this work now?
            _shaderDictionary[ part ] = glocalKey;
        }


        /// <summary>
        ///     Clears all parts currently marked as visible ( Call this at the start of a frame )
        /// </summary>
        public static void ClearVisible( )
        {
            //TODO implement filtering here
        }

        /// <summary>
        ///     Creates an instance object for the given part
        /// </summary>
        /// <param name="part">The part to be instanced</param>
        /// <param name="instance">The instance data</param>
        public void CreateInstance( GlobalGeometryPartBlockNew part, dynamic instance )
        {
            InstanceManager.CreateInstance( part, instance );
        }

        public IEnumerable<PatchData> GetOpaqueParts(TagGlobalKey shaderKey )
        {
            var opaqueParts = InstanceManager.Parts.Where(
                e => _shaderDictionary[ e ] == shaderKey && (
                    e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowCasting ||
                    e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowOnly ||
                    e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueNonshadowing ) );
            foreach ( var part in opaqueParts )
            {
                foreach ( var instance in InstanceManager.GetInstancesOf( part ) )
                {
                    yield return new PatchData( part, instance )
                    {
                        ShaderKey = _shaderDictionary[ part ]
                    };
                }
            }
        }

        /// <summary>
        ///     Returns all Opaque* type parts
        /// </summary>
        /// <returns>A sequence of patch data</returns>
        public IEnumerable<PatchData> GetOpaqueParts( )
        {
            var opaqueParts = InstanceManager.Parts.Where(
                e =>
                    e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowCasting ||
                    e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowOnly ||
                    e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueNonshadowing );
            var patches = new List<PatchData>( );
            foreach ( var part in opaqueParts )
            {
                foreach ( var instance in InstanceManager.GetInstancesOf( part ) )
                {
                    patches.Add( new PatchData( part, instance )
                    {
                        ShaderKey = _shaderDictionary[ part ]
                    } );
                }
            }
            return patches;
        }

        public IEnumerable<TagGlobalKey> GetShaders( )
        {
            return _shaderDictionary.Values.Distinct( );
        }

        /// <summary>
        ///     Returns all Transparent type parts
        /// </summary>
        /// <param name="eye">The viewer used for depth sorting</param>
        /// <returns>A sequence of patch data</returns>
        public IEnumerable<PatchData> GetTransparentParts( Camera eye )
        {
            var transparentParts =
                InstanceManager.Parts.Where( e => e.Type == GlobalGeometryPartBlockNew.TypeEnum.Transparent )
                    .ToList( );
            return SortTransparentParts( transparentParts, eye );
        }

        public void RemoveInstance( GlobalGeometryPartBlockNew part, dynamic instance )
        {
            InstanceManager.RemoveInstance( part, instance );
        }

        /// <summary>
        ///     Returns a sorted collection of DrawStubs
        /// </summary>
        /// <param name="transparentParts"></param>
        /// <param name="eye"></param>
        /// <returns></returns>
        private IEnumerable<PatchData> SortTransparentParts(
            ICollection<GlobalGeometryPartBlockNew> transparentParts,
            Camera eye )
        {
            var capacity = transparentParts.Sum( u => InstanceManager.GetInstanceCount( u ) );

            var transparentDrawsSortedList =
                new SortedList<float, PatchData>( capacity, DistanceComparer );

            foreach ( var part in transparentParts )
            {
                foreach ( var instance in InstanceManager.GetInstancesOf( part ) )
                {
                    var scenePosition = Vector3.TransformPosition( part.Position, instance.worldMatrix );

                    var distance = eye.DistanceOf( scenePosition );

                    transparentDrawsSortedList.Add( distance, new PatchData( part, instance )
                    {
                        ShaderKey = _shaderDictionary[ part ]
                    } );
                }
            }
            return transparentDrawsSortedList.Select( u => u.Value );
        }
    }
}