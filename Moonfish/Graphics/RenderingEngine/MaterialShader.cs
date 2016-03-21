using System.Collections.Generic;
using System.Linq;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class MaterialShader
    {
        private readonly ShaderBlock shader;
        private readonly ShaderTemplateBlock shaderTemplate;
        private int _activeShaderPass;
        private bool disposed = false;
        public ShaderPassBlock[] shaderPasses;
        public string[] shaderPassPaths;

        public MaterialShader( ShaderBlock shader, out ShaderPostprocessBitmapNewBlock[] bitmapBlocks )
        {
            CacheKey cacheKey;
            if ( !shader.TryGetCacheKey( out cacheKey ) )
            {
                bitmapBlocks = new ShaderPostprocessBitmapNewBlock[0];
                return;
            }

            this.shader = shader;

            //  Load shader template class and load shader passes
            bitmapBlocks = shader.PostprocessDefinition[ 0 ].Bitmaps;

            var shaderTemplateIdent = ( TagIdent ) shader.PostprocessDefinition[ 0 ].ShaderTemplateIndex;
            shaderTemplate = ( ShaderTemplateBlock ) shaderTemplateIdent.Get(cacheKey);

            shaderPasses = new ShaderPassBlock[shaderTemplate.PostprocessDefinition[ 0 ].Passes.Length];
            shaderPassPaths = new string[shaderTemplate.PostprocessDefinition[ 0 ].Passes.Length];
            for ( var i = 0; i < shaderPasses.Length; ++i )
            {
                var item = shaderTemplate.PostprocessDefinition[ 0 ].Passes[ i ];
                shaderPasses[ i ] = ( ShaderPassBlock ) item.Pass.Get(cacheKey);
                shaderPassPaths[ i ] = item.Pass.ToString( );
            }
        }

        private int ActiveShaderPassIndex
        {
            get { return _activeShaderPass; }
            set { _activeShaderPass = value.Clamp( -1, shaderPasses.Length - 1 ); }
        }

        public ICollection<BindingHandle> Bind( int pass = 0 )
        {
            var shader = this.shader.PostprocessDefinition[ 0 ];
            var template = shaderTemplate.PostprocessDefinition[ 0 ];
            var shaderPass = shaderPasses[ 0 ].PostprocessDefinition[ 0 ];
            var blockIndexData = template.LevelsOfDetail[ 0 ].Layers;

            //  Calculate which layer the pass targets and quit if invalid
            var layerIndex = GetPassLayer( pass, template, blockIndexData );
            if ( layerIndex < 0 ) return new BindingHandle[0];

            var handles = new List<BindingHandle>( );
            var implementationIndex = 0;
            foreach (
                var implementation in template.Implementations.TakeSubset( template.Passes[ pass ].Implementations ) )
            {
                var bitmapMappings =
                    template.Remappings.TakeSubset( implementation.Bitmaps ).Select( u => new BitmapMapping( u ) ).ToList(  );
                var textures = shaderPass.Implementations[implementationIndex].Textures;
                
                foreach ( var param in shaderPass.Textures.TakeSubset(textures))
                {
                    if ( (sbyte)param.BitmapExternIndex > 0 )
                        continue;

                    var bitmapParameterIndex = param.BitmapParameterIndex;

                    if ((sbyte)bitmapParameterIndex < 0)
                        continue;

                        var bitmapMapping = bitmapMappings[bitmapParameterIndex];
                    var bitmapParam = shader.Bitmaps[ bitmapMapping.SourceIndex ];

                    handles.Add( new TextureHandle( bitmapParam ) {TextureStage = param.TextureStageIndex} );
                }
                var renderStates = shaderPass.Implementations[implementationIndex].RenderStates;
                var defaultRenderStates = shaderPass.Implementations[implementationIndex].DefaultRenderStates;
                foreach ( var state in shaderPass.RenderStates.TakeSubset( renderStates ) )
                {
                    handles.Add( new RenderStateHandle( state ) );
                }

                foreach (var state in shaderPass.RenderStates.TakeSubset(defaultRenderStates))
                {
                    handles.Add( new RenderStateHandle( state, true ) );
                }

                // this is where other passes would be rendered, if we felt like it.
                implementationIndex++;
                break;
            }
            return handles.ToArray( );
        }

        public void UsePass( int index, Dictionary<TagIdent, List<Graphics.TextureHandle>> textures )
        {
            ActiveShaderPassIndex = index;
            if ( ActiveShaderPassIndex < 0 )
            {
                return;
            }

            var template = shaderTemplate.PostprocessDefinition[ 0 ];
            var activePass = shaderTemplate.PostprocessDefinition[ 0 ].Passes[ ActiveShaderPassIndex ];
            var implementations = template.Implementations.ToList( )
                .GetRange( activePass.Implementations.Index, activePass.Implementations.Length );
            var remappings = template.Remappings.ToList( );
            for ( var implementationIndex = implementations.Count - 1;
                implementationIndex < implementations.Count;
                ++implementationIndex )
            {
                var shaderPass = shaderPasses[ ActiveShaderPassIndex ].PostprocessDefinition[ 0 ];
                var shaderPassImplementation = shaderPass.Implementations[ implementationIndex ];
                for ( var i = 0; i < shaderPassImplementation.Textures.Length; ++i )
                {
                    var texture = shaderPass.Textures[ shaderPassImplementation.Textures.Index + i ];
                    var bitmap = texture.BitmapParameterIndex;
                    if ( bitmap == byte.MaxValue )
                        continue;

                    var texturestage = texture.TextureStageIndex;

                    GL.ActiveTexture( TextureUnit.Texture1 + texturestage );

                    textures[
                        shader.PostprocessDefinition[ 0 ].Bitmaps[
                            remappings[ implementations[ implementationIndex ].Bitmaps.Index + bitmap ].SourceIndex ]
                            .BitmapGroup ].First( ).Bind( );
                }
                break;
            }
        }

        private int GetPassLayer( int pass, ShaderTemplatePostprocessDefinitionNewBlock template,
            TagBlockIndexStructBlock blockIndexData )
        {
            var layerIndex = 0;
            foreach ( var layer in template.Layers.Skip( blockIndexData.Index ).Take( blockIndexData.Length ) )
            {
                if ( HasShaderPass( layer ) && ShaderPassOf( layer ) == pass )
                {
                    return layerIndex;
                }
                layerIndex++;
            }
            return -1;
        }

        private static bool HasShaderPass( TagBlockIndexBlock block )
        {
            return block.Indices.Length > 0;
        }

        private int ShaderPassOf( TagBlockIndexBlock layer )
        {
            return layer.Indices.Index;
        }

        public class BindingHandle
        {
            public bool DefaultState { get; protected set; }
        }
        
        public class RenderStateHandle : BindingHandle
        {
            public D3DRENDERSTATETYPE RenderState { get; }
            public int UnionValue { get; }

            public RenderStateHandle(  RenderStateBlock state, bool defaultState = false )
            {
                DefaultState = defaultState;
                RenderState = ( D3DRENDERSTATETYPE ) state.StateIndex;
                UnionValue = state.StateValue;
            }
        }

        public class TextureHandle : BindingHandle
        {
            public TextureHandle( ShaderPostprocessBitmapNewBlock bitmapParam )
            {
                Key = new TagIdent( bitmapParam.BitmapGroup.Index, ( short ) bitmapParam.BitmapIndex );
                LogDimension = bitmapParam.LogBitmapDimension;
            }

            public TagIdent Key { get; }

            public float LogDimension { get; }
            public byte TextureStage { get; set; }
        }
    }
}