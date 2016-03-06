using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;
using Moonfish.Cache;
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
        public Dictionary<TagIdent, Texture> _textureDictionary = new Dictionary<TagIdent, Texture>( );

        public MaterialShader GetMaterial( TagIdent materialIdent )
        {
            if ( _materialDictionary.ContainsKey( materialIdent ) ) return _materialDictionary[ materialIdent ];

            var shaderBlock = materialIdent.Get<ShaderBlock>();
            ShaderPostprocessBitmapNewBlock[] bitmaps;
            _materialDictionary[materialIdent] = new MaterialShader(shaderBlock, out bitmaps);

            foreach ( var bitmap in bitmaps )
            {
                var bitmapKey = GetBitmapKey( bitmap );
                if ( _textureDictionary.ContainsKey( bitmapKey ) ) continue;

                var layer = bitmap.BitmapIndex;
                var bitmapBlock = ( BitmapBlock ) bitmap.BitmapGroup.Get( );
                if ( bitmapBlock==null )
                {
                    continue;
                }
                var texture = new Texture(  );
                texture.Load(bitmapBlock.Bitmaps[layer]);
                _textureDictionary.Add(bitmapKey, texture );
            }

            return _materialDictionary[materialIdent];
        }

        private static TagIdent GetBitmapKey( ShaderPostprocessBitmapNewBlock bitmap )
        {
            //  Pack the bitmap layer-index into the salt of the ident to create a unique id
            return new TagIdent( bitmap.BitmapGroup.Index, ( short ) bitmap.BitmapIndex );
        }

        public void Bind( MaterialShader material )
        {
            var bindings = material.Bind( );
            foreach ( var handle in bindings )
            {
                var textureHandle = handle as MaterialShader.TextureHandle;
                var stateHandle = handle as MaterialShader.RenderStateHandle;
                if ( textureHandle != null )
                {
                    var texture = _textureDictionary[ textureHandle.Key ];

                    GL.ActiveTexture( TextureUnit.Texture0 + textureHandle.TextureStage );
                    texture.Bind(  );
                }
                if (stateHandle != null)
                {
                    StateManager.DispatchState( stateHandle );
                }
            }
        }
        
    }
}
