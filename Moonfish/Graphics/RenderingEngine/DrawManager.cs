using System;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

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

        public InstanceManager InstanceManager { get; } = new InstanceManager( );

        private Dictionary<TagGlobalKey, List<GlobalGeometryPartBlockNew>> OpaquePatches { get; } =
            new Dictionary<TagGlobalKey, List<GlobalGeometryPartBlockNew>>( );

        private List<PatchData> TransparentPatches { get; set; } = new List<PatchData>( );

        public void AssignShader( GlobalGeometryPartBlockNew part, CacheKey cacheKey, TagIdent shaderIdent )
        {
            var glocalKey = new TagGlobalKey( cacheKey, shaderIdent );
            //  Does this work now?
            _shaderDictionary[ part ] = glocalKey;
        }

        public void Clear( )
        {
            InstanceManager.ClearInstances( );
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
        public void CreateInstance( GlobalGeometryPartBlockNew part, IH2ObjectInstance instance,
            bool supportsPermutations )
        {
            InstanceManager.CreateInstance( part, instance, supportsPermutations );
        }

        public IEnumerable<GlobalGeometryPartBlockNew> GetOpaqueParts( TagGlobalKey shaderKey )
        {
            return OpaquePatches.ContainsKey( shaderKey )
                ? OpaquePatches[ shaderKey ]
                : Enumerable.Empty<GlobalGeometryPartBlockNew>( );
        }

        public IEnumerable<TagGlobalKey> GetShaders( )
        {
            return _shaderDictionary.Values;
        }

        /// <summary>
        ///     Returns all Transparent type parts
        /// </summary>
        /// <param name="eye">The viewer used for depth sorting</param>
        /// <returns>A sequence of patch data</returns>
        public IEnumerable<PatchData> GetTransparentParts( Camera eye )
        {
            return TransparentPatches;
        }

        public void RemoveInstance( GlobalGeometryPartBlockNew part, dynamic instance )
        {
            InstanceManager.RemoveInstance( part, instance );
        }

        public void Sort( Camera eye )
        {
            OpaquePatches.Clear( );
            TransparentPatches.Clear( );
            var opaqueParts = InstanceManager.Parts.Where(
                e => e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowCasting ||
                     e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowOnly ||
                     e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueNonshadowing );
            var globalGeometryPartBlockNews = opaqueParts as GlobalGeometryPartBlockNew[] ?? opaqueParts.ToArray( );
            foreach ( var part in globalGeometryPartBlockNews )
            {
                var key = _shaderDictionary[ part ];
                if ( !OpaquePatches.ContainsKey( key ) ) OpaquePatches[ key ] = new List<GlobalGeometryPartBlockNew>( );
                OpaquePatches[ key ].Add( part );
            }

            var transparentParts =
                InstanceManager.Parts.Where( e => e.Type == GlobalGeometryPartBlockNew.TypeEnum.Transparent )
                    .ToList( );
            TransparentPatches = new List<PatchData>( SortTransparentParts( transparentParts, eye ) );
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

        private Dictionary<IndirectCommandBufferKey, IndirectDrawCommandBuffer> PrimitiveIndirectDrawBuffer =
            new Dictionary<IndirectCommandBufferKey, IndirectDrawCommandBuffer>( );

        public void CreateIndirectDrawCommands( BucketManager bucketManager, InstanceDataBuffer instanceData )
        {
            foreach ( var commandBuffer in PrimitiveIndirectDrawBuffer.Values )
            {
                if(commandBuffer.Count>0)return;
                commandBuffer.Clear( );
            }

            foreach ( var part in InstanceManager.Parts )
            {
                var bucket = bucketManager.GetBucketResource( part );
                var primitiveType = part.PrimitiveType;

                var bufferKey = new IndirectCommandBufferKey( bucket, primitiveType );

                if ( !PrimitiveIndirectDrawBuffer.ContainsKey( bufferKey ) )
                {
                    PrimitiveIndirectDrawBuffer[ bufferKey ] = new IndirectDrawCommandBuffer( primitiveType, bucket );
                }
                PrimitiveIndirectDrawBuffer[ bufferKey ].AddDrawCommand( part, bucket,
                    instanceData[ part ] );

            }

            foreach ( var indirectDrawCommandBuffers in PrimitiveIndirectDrawBuffer.Values )
            {
                indirectDrawCommandBuffers.CreateCommandBuffer( );
            }
        }

        public void DispatchDraws( InstanceDataBuffer instanceData )
        {
            foreach ( var drawCommandBuffer in PrimitiveIndirectDrawBuffer.Values )
            {
                using ( drawCommandBuffer.Bind( ) )
                using ( drawCommandBuffer.SourceBucket.Bind( ) )
                using ( instanceData.Bind( ) )
                {
                    GL.MultiDrawElementsIndirect(
                        drawCommandBuffer.PrimitiveType,
                        DrawElementsType.UnsignedShort,
                        IntPtr.Zero,
                        drawCommandBuffer.Count,
                        0 );
                }
            }
        }
    };
}