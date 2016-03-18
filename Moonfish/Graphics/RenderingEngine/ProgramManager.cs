using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class ProgramManager : IEnumerable<Program>
    {
        private Program _activeProgram;
        private bool _changedProgram;
        private int _normalMapPaletteTexture;

        public ProgramManager( )
        {
            Materials = new Dictionary<TagIdent, MaterialShader>( );
            Shaders = new Dictionary<string, Program>( );
            LoadedTextureArrays = new Dictionary<TagIdent, List<TextureHandle>>( );
            LightmapTextures = new Dictionary<Tuple<int, int>, TextureHandle>( );
            //LoadDefaultShader( );
            //LoadSystemShader( );
            LoadScreenShader( );
            //LoadLightmapShader( );
            LoadDebugShader( );
            LoadDebug2Shader( );
        }

        public Dictionary<Tuple<int, int>, TextureHandle> LightmapTextures { get; set; }
        public Dictionary<TagIdent, List<TextureHandle>> LoadedTextureArrays { get; set; }
        public Dictionary<TagIdent, MaterialShader> Materials { get; set; }

        public Program ScreenProgram
        {
            get { return Shaders[ "screen" ]; }
        }

        public Program DefaultProgram => Shaders[ "default" ];

        public Program SystemProgram
        {
            get { return Shaders[ "system" ]; }
        }

        public Program DebugShader => Shaders[ "debug" ];

        private Program ActiveProgram
        {
            get { return _activeProgram; }
            set
            {
                _changedProgram = ActiveProgram != value;

                if ( _changedProgram )
                {
                    _activeProgram = value;
                    ActiveProgram.Assign( );
                }
            }
        }

        private Dictionary<string, Program> Shaders { get; set; }
        public Program DebugShader2 => Shaders[ "debug2" ];


        public IEnumerator<Program> GetEnumerator( )
        {
            return Shaders.Select( x => x.Value ).GetEnumerator( );
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return GetEnumerator( );
        }

        public TextureHandle GetLightmapTexture( int bitmapIndex, int paletteIndex )
        {
            return LightmapTextures[ new Tuple<int, int>( bitmapIndex, paletteIndex ) ];
        }

        public Program GetProgram( ShaderReference reference, string shaderName = null )
        {
            if ( reference == null )
                return ActiveProgram = Shaders[ "lightmapped" ];

            switch ( reference.Type )
            {
                case ShaderReference.ReferenceType.Halo2:
                    MaterialShader material;
                    var tagIdent = ( TagIdent ) reference.Ident;
                    if ( Materials.TryGetValue( tagIdent, out material ) )
                    {
                        material.UsePass( 0, LoadedTextureArrays );
                        Program shaderProgram;
                        if ( shaderName != null && Shaders.TryGetValue( shaderName, out shaderProgram ) )
                        {
                            ActiveProgram = shaderProgram;
                            break;
                        }
                    }
                    ActiveProgram = Shaders[ "default" ];
                    break;

                case ShaderReference.ReferenceType.System:
                    ActiveProgram = Shaders[ "system" ];
                    break;
            }
            return ActiveProgram;
        }

        public void LoadMaterials( IList<GlobalGeometryMaterialBlock> materials, CacheStream cacheStream,
            IList<int> indices = null )
        {
            //for ( var index = 0; index < materials.Count; index++ )
            //{
            //    var globalGeometryMaterialBlock = materials[ index ];
            //    var shaderBlock = globalGeometryMaterialBlock.Shader.Get<ShaderBlock>( );
            //    ShaderPostprocessBitmapNewBlock[] textures;
            //    var material = new MaterialShader( shaderBlock, cacheStream, out textures );

            //    foreach ( var shaderPostprocessBitmapNewBlock in textures )
            //    {
            //        LoadTextureGroup(shaderPostprocessBitmapNewBlock.BitmapGroup);
            //    }

            //    Materials[
            //        indices != null && index < indices.Count
            //            ? ( TagIdent ) indices[ index ]
            //            : globalGeometryMaterialBlock.Shader.Ident ] = material;
            //}
        }

        public void LoadPalettedTextureGroup( int bitmapIndex, int paletteIndex, BitmapDataBlock bitmapDataBlock,
            StructureLightmapPaletteColorBlock colourPaletteData, TextureMagFilter textureMagFilter,
            TextureMinFilter textureMinFilter )
        {
            var texture = new TextureHandle( );
            var paletteData = colourPaletteData.GetColourPaletteData( );
            //texture.LoadPalettedTexture( bitmapDataBlock, paletteData, textureMagFilter, textureMinFilter );
            OpenGL.GetError( );

            var key = new Tuple<int, int>( bitmapIndex, paletteIndex );

            if ( LightmapTextures.ContainsKey( key ) )
            {
                LightmapTextures[ key ].Dispose( );
                LightmapTextures[ key ] = texture;
            }
            else
                LightmapTextures[ key ] = texture;
        }

        private void LoadScreenShader( )
        {
            var vertex_shader = new Shader( "data/viewscreen.vert", ShaderType.VertexShader );
            var fragment_shader = new Shader( "data/debug.frag", ShaderType.FragmentShader );
            var defaultProgram = new Program( "screen" );
            GL.BindAttribLocation( defaultProgram.Ident, 0, "Position" );
            GL.BindAttribLocation( defaultProgram.Ident, 1, "Colour" );

            defaultProgram.Link( new List<Shader>( 2 ) {vertex_shader, fragment_shader} );

            var diffuseMapUniform = defaultProgram.GetUniformLocation( "diffuseSampler" );

            defaultProgram.Use( );
            defaultProgram.SetUniform( diffuseMapUniform, 0 );
            Shaders[ "screen" ] = defaultProgram;
        }

        private void LoadDebugShader()
        {
            var vertex_shader = new Shader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/debug.vert"), ShaderType.VertexShader);
            var fragment_shader = new Shader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/debug.frag"), ShaderType.FragmentShader);
            var program = new Program("debug");

            program.Link(new List<Shader>(2) { vertex_shader, fragment_shader });

            var diffuseMapUniform = program.GetUniformLocation("diffuseSampler");

            program.Use();
            program.SetUniform(diffuseMapUniform, 0);

            StateManager.AlphaFuncChanged += delegate (object sender, D3DCMPFUNC function)
            {
                var uniformLocation = program.GetUniformLocation("AlphaFuncUniform");
                program.SetUniform(uniformLocation, (int)function);
            };
            StateManager.AlphaRefChanged += delegate (object sender, float alphaRef)
            {
                var uniformLocation = program.GetUniformLocation("AlphaRefUniform");
                program.SetUniform(uniformLocation, alphaRef);
            };
            Shaders["debug"] = program;
        }

        private void LoadDebug2Shader()
        {
            var vertex_shader = new Shader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/debug2.vert"), ShaderType.VertexShader);
            var fragment_shader = new Shader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/debug2.frag"), ShaderType.FragmentShader);
            var program = new Program("debug2");

            program.Link(new List<Shader>(2) { vertex_shader, fragment_shader });

            Shaders["debug2"] = program;
        }
    };
}