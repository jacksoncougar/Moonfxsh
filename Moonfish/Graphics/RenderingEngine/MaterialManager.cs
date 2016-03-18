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
        public Dictionary<TagIdent, TextureHandle> _textureDictionary = new Dictionary<TagIdent, TextureHandle>( );

        public MaterialShader GetMaterial( TagGlobalKey key )
        {
            if ( _materialDictionary.ContainsKey( key.TagKey ) ) return _materialDictionary[ key.TagKey ];

            var shaderBlock = ( ShaderBlock ) key.Get( );
            ShaderPostprocessBitmapNewBlock[] bitmaps;
            _materialDictionary[ key.TagKey ] = new MaterialShader( shaderBlock, out bitmaps );

            foreach ( var bitmap in bitmaps )
            {
                var bitmapKey = GetBitmapKey( bitmap );
                if ( _textureDictionary.ContainsKey( bitmapKey ) ) continue;

                var layer = bitmap.BitmapIndex;
                var bitmapBlock = ( BitmapBlock ) bitmap.BitmapGroup.Get( key.CacheKey );
                if ( bitmapBlock == null )
                {
                    continue;
                }
                var texture = new TextureHandle( );
                texture.Load( bitmapBlock.Bitmaps[ layer ] );
                _textureDictionary.Add( bitmapKey, texture );
            }

            return _materialDictionary[ key.TagKey ];
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
