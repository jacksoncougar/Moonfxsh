using System.Collections.Generic;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public class BillboardObject : ObjectBlock
    {
        public BillboardObject( TagIdent bitmap, ICache destination )
        {
            Model = ( TagReference ) new ModelBlock( );
            var modelBlock = ( ModelBlock ) Model.Get();
            var block = ( BitmapBlock ) bitmap.Get();

            var w = block.Bitmaps[0].Width * 0.5f;
            var h = block.Bitmaps[ 0 ].Height * 0.5f;

            var worldCoordinates = new[]
            {
                new Vector3( -w, -h, 0 ),
                new Vector3( -w, h, 0 ),
                new Vector3( w, -h, 0 ),
                new Vector3( w, h, 0 )
            };

            var textureCoordinates = new[]
            {
                new Vector3( 0, 0, 0 ),
                new Vector3( 0, 1, 0 ),
                new Vector3( 1, 0, 0 ),
                new Vector3( 1, 1, 0 )
            };

            var normals = new[]
            {
                new Vector3( 0, 0, 1 ),
                new Vector3( 0, 0, 1 ),
                new Vector3( 0, 0, 1 ),
                new Vector3( 0, 0, 1 )
            };

            var elements = new short[]
            {
                0, 1, 2,
                2, 1, 3
            };

            var mesh = new GeometryMesh
            {
                Parts = new List<GeometryPart>( new[]
                {
                    new GeometryPart
                    {
                        Type = GlobalGeometryPartBlockNew.TypeEnum.OpaqueNonshadowing,
                        Flags = GlobalGeometryPartBlockNew.Flags.OverrideTriangleList,
                        NormalVectors = new List<Vector3>( normals ),
                        WorldCoordinates = new List<Vector3>( worldCoordinates ),
                        TextureCoordinates = new List<Vector3>( textureCoordinates ),
                        Elements = new List<short>( elements )
                    }
                } )
            };

            var renderModelBlock = mesh.Export( );
            var shaderBlock = new MoonfishScreenSpaceShader( bitmap );
            renderModelBlock.Materials = new[]
            {
                new GlobalGeometryMaterialBlock
                {
                    Shader = ( TagReference ) shaderBlock
                }
            };
            modelBlock.RenderModel = ( TagReference ) renderModelBlock;
        }
    };

    public class MoonfishScreenSpaceShader : ShaderBlock
    {
        public MoonfishScreenSpaceShader(TagIdent bitmap )
        {
            TagReference renderPass = new TagReference();
            var shaderPass = new ShaderPassBlock
            {
                PostprocessDefinition = new[]
                {
                    new ShaderPassPostprocessDefinitionNewBlock
                    {
                        Implementations = new[]
                        {
                            new ShaderPassPostprocessImplementationNewBlock
                            {
                                DefaultRenderStates = new TagBlockIndexStructBlock( 0, 2 ),
                                Textures = new TagBlockIndexStructBlock( 0, 1 ),
                                TextureStates = new TagBlockIndexStructBlock( 0, 1 )
                            }
                        },
                        RenderStates = new[]
                        {
                            new RenderStateBlock
                            {
                                StateIndex = ( byte ) ( D3DRENDERSTATETYPE.COLORWRITEENABLE ),
                                StateValue = 0x01010101 //ALL CHANNELS
                            },
                            new RenderStateBlock
                            {
                                StateIndex = ( byte ) D3DRENDERSTATETYPE.ALPHABLENDENABLE,
                                StateValue = 0
                            }
                        },
                        Textures = new[]
                        {
                            new ShaderPassPostprocessTextureNewBlock
                            {
                                BitmapExternIndex = 0,
                                BitmapParameterIndex = 0,
                                Flags = 0,
                                TextureStageIndex = 0,
                            }
                        },
                        TextureStates = new[] {ShaderPassPostprocessTextureStateBlock.Default,}
                    }
                }
            };
            var shaderTemplate = new ShaderTemplateBlock( )
            {
                PostprocessDefinition = new[]
                {
                    new ShaderTemplatePostprocessDefinitionNewBlock
                    {
                        LevelsOfDetail = new[]
                        {
                            new ShaderTemplatePostprocessLevelOfDetailNewBlock
                            {
                                AvailableLayers = 1,
                                Layers = new TagBlockIndexStructBlock( 0, 1 )
                            }
                        },
                        Layers = CreateLayers( 0, 1 ),
                        Passes = new[]
                        {
                            new ShaderTemplatePostprocessPassNewBlock
                            {
                                Implementations = new TagBlockIndexStructBlock( 0, 1 ),
                                Pass = ( TagReference ) shaderPass
                            }
                        },
                        Implementations = new[]
                        {
                            new ShaderTemplatePostprocessImplementationNewBlock
                            {
                                Bitmaps = new TagBlockIndexStructBlock( 0, 1 ),
                                PixelConstants = new TagBlockIndexStructBlock( 1, 0 ),
                                VertexConstants = new TagBlockIndexStructBlock( 1, 0 )
                            }
                        },
                        Remappings = new[] {( ShaderTemplatePostprocessRemappingNewBlock ) new BitmapMapping( 0, 0 )}
                    }
                }
            };

            Template = ( TagReference ) shaderTemplate;
            PostprocessDefinition = new[]
            {
                new ShaderPostprocessDefinitionNewBlock
                {
                    Bitmaps = new[]
                    {
                        new ShaderPostprocessBitmapNewBlock
                        {
                            BitmapGroup = bitmap
                        }
                    },
                    ShaderTemplateIndex = ( int ) Template.Ident
                }
            };
        }

        private TagBlockIndexBlock[] CreateLayers( int layer, int count )
        {
            var layers = new TagBlockIndexBlock[25];
            for ( int index = 0; index < layers.Length; index++ )
            {
                layers[ index ] = new TagBlockIndexBlock(  );
            }
            layers[ layer ].Indices = new TagBlockIndexStructBlock( 0, ( byte ) count );
            for ( var i = layer + 1; i < 25; i++ )
            {
                layers[ i ].Indices = new TagBlockIndexStructBlock( ( byte ) count, 0 );
            }
            return layers;
        }
    }
}