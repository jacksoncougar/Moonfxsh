using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;
using BitmapBlock = Moonfish.Guerilla.Tags.BitmapBlock;
using ShaderBlock = Moonfish.Guerilla.Tags.ShaderBlock;

namespace Moonfish.Graphics.RenderingEngine
{
    public class MaterialManager
    {
        public Dictionary<TagIdent, MaterialShader> _materialDictionary = new Dictionary<TagIdent, MaterialShader>();

        public static Dictionary<TagIdent, TextureHandle> TextureDictionary { get; } =
            new Dictionary<TagIdent, TextureHandle>( );

        public MaterialShader GetMaterial()
        {
            throw new NotImplementedException();
        }

        private static TagIdent GetBitmapKey( ShaderPostprocessBitmapNewBlock bitmap )
        {
            //  Pack the bitmap layer-index into the salt of the ident to create a unique id
            return new TagIdent( bitmap.BitmapGroup.Index, ( short ) bitmap.BitmapIndex );
        }

        public IDisposable Bind( MaterialShader material )
        {
            return new Handle( material );
        }

        private class Handle : IDisposable
        {
            private bool disposed;
            private List<MaterialShader.BindingHandle> DefaultBindings { get; set; } = new List<MaterialShader.BindingHandle>();

            public Handle( MaterialShader material )
            {
                var bindings = material.Bind();
                foreach (var handle in bindings)
                {
                    if ( handle.DefaultState )
                    {
                        DefaultBindings.Add( handle );
                        continue;
                    }
                    ProcessState(handle);
                }
            }

            private void Dispose( bool disposing )
            {
                if ( !disposing || disposed) return;
                disposed = true;
                foreach ( var handle in DefaultBindings )
                {
                    ProcessState( handle );
                }
            }

            private static void ProcessState( MaterialShader.BindingHandle handle )
            {
                var textureHandle = handle as MaterialShader.TextureHandle;
                var stateHandle = handle as MaterialShader.RenderStateHandle;
                if ( textureHandle != null )
                {
                    var texture = TextureDictionary[ textureHandle.Key ];

                    GL.ActiveTexture( TextureUnit.Texture0 + textureHandle.TextureStage );
                    texture.Bind( );
                }
                if ( stateHandle != null )
                {
                    StateManager.DispatchState( stateHandle );
                }
            }


            public void Dispose( )
            {
                Dispose( true );
                GC.SuppressFinalize( this );
            }
        }
    }
}
