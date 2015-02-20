using Moonfish.Graphics;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    partial class ShaderBlock
    {
        public ShaderPostprocessBitmapNewBlock[] Bitmaps { get { return postprocessDefinition[0].bitmaps; } }
        Texture texture;
        Texture texture1;
        Texture texture2;
        public void LoadShader(MapStream map)
        {
            var normalMap = map[postprocessDefinition[0].bitmaps[0].bitmapGroup].Deserialize() as BitmapBlock;
            var diffuseMap = map[postprocessDefinition[0].bitmaps[2].bitmapGroup].Deserialize() as BitmapBlock;
            var environmentMap = map[postprocessDefinition[0].bitmaps[5].bitmapGroup].Deserialize() as BitmapBlock;
            texture = new Texture();
            texture.Load(normalMap, map, TextureUnit.Texture0 + 1, TextureMagFilter.Nearest, TextureMinFilter.Nearest);
            texture1 = new Texture();
            texture1.Load(diffuseMap, map, TextureUnit.Texture0 + 2, TextureMagFilter.Linear, TextureMinFilter.Linear);
            texture1 = new Texture();
            texture1.Load(environmentMap, map, TextureUnit.Texture0 + 3, TextureMagFilter.Linear, TextureMinFilter.Linear);
        }
    }
}
