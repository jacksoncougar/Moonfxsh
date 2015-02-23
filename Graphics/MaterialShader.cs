using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    public class MaterialShader
    {
        public List<Texture> Textures { get; private set; }

        int activeShaderPass;
        public int ActiveShaderPassIndex { get { return activeShaderPass; } set { activeShaderPass = value.Clamp<int>(0, shaderPasses.Length); } }


        ShaderBlock shader;
        ShaderTemplateBlock shaderTemplate;
        ShaderPassBlock[] shaderPasses;

        public MaterialShader(ShaderBlock inShader, MapStream map)
            : this()
        {
            this.shader = inShader;
            //  Load bitmap classes and transfer data into glTextures
            Textures = new List<Texture>(shader.postprocessDefinition[0].bitmaps.Length);
            foreach (var item in shader.postprocessDefinition[0].bitmaps)
            {
                var bitmapBlock = map[item.bitmapGroup].Deserialize() as BitmapBlock;
                var texture = new Texture();
                texture.Load(bitmapBlock, map);
                Textures.Add(texture);
            }

            //  Load shader template class and load shader passes

            var shaderTemplateIdent = (TagIdent)shader.postprocessDefinition[0].shaderTemplateIndex;
            this.shaderTemplate = map[shaderTemplateIdent].Deserialize() as ShaderTemplateBlock;

            this.shaderPasses = new ShaderPassBlock[shaderTemplate.postprocessDefinition[0].passes.Length];
            for (int i = 0; i < shaderPasses.Length; ++i)
            {
                var item = shaderTemplate.postprocessDefinition[0].passes[i];
                shaderPasses[i] = map[item.pass].Deserialize() as ShaderPassBlock;
            }
        }

        public MaterialShader()
        {
            Textures = new List<Texture>();
        }

        public void UsePass(int index)
        {
            ActiveShaderPassIndex = index;
            var template = shaderTemplate.postprocessDefinition[0];
            var activePass = shaderTemplate.postprocessDefinition[0].passes[ActiveShaderPassIndex];
            var implementations = template.implementations.ToList().GetRange(activePass.implementations.Index, activePass.implementations.Length);
            var remappings = template.remappings.ToList();
            for (int implementationIndex = 0; implementationIndex < implementations.Count; ++implementationIndex)
            {
                var shaderPass = shaderPasses[ActiveShaderPassIndex].postprocessDefinition[0];
                var shaderPassImplementation = shaderPass.implementations[implementationIndex];
                for (int i = 0; i < shaderPassImplementation.textures.Length; ++i)
                {
                    var texture = shaderPass.textures[shaderPassImplementation.textures.Index + i];
                    var bitmap = texture.bitmapParameterIndex;
                    if (bitmap == byte.MaxValue) continue;

                    var textureStage = texture.textureStageIndex;

                    GL.ActiveTexture(TextureUnit.Texture0 + textureStage);

                    Textures[remappings[implementations[implementationIndex].bitmaps.Index + bitmap].sourceIndex].Bind();
                }
            }
        }
    }
}
