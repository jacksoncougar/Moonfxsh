using System;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class MaterialShader
    {
        private bool disposed = false;

        private int activeShaderPass;

        public int ActiveShaderPassIndex
        {
            get { return activeShaderPass; }
            set { activeShaderPass = value.Clamp<int>(-1, shaderPasses.Length - 1); }
        }


        private ShaderBlock shader;
        private ShaderTemplateBlock shaderTemplate;
        public ShaderPassBlock[] shaderPasses;
        public string[] shaderPassPaths;

        public MaterialShader(ShaderBlock shader, CacheStream map, out ShaderPostprocessBitmapNewBlock[] bitmapBlocks)
            : this()
        {
            this.shader = shader;

            //  Load shader template class and load shader passes
            bitmapBlocks = shader.PostprocessDefinition[0].Bitmaps;

            var shaderTemplateIdent = (TagIdent) shader.PostprocessDefinition[0].ShaderTemplateIndex;
            this.shaderTemplate = (ShaderTemplateBlock) map.Deserialize(shaderTemplateIdent);

            this.shaderPasses = new ShaderPassBlock[shaderTemplate.PostprocessDefinition[0].Passes.Length];
            this.shaderPassPaths = new string[shaderTemplate.PostprocessDefinition[0].Passes.Length];
            for (int i = 0; i < shaderPasses.Length; ++i)
            {
                var item = shaderTemplate.PostprocessDefinition[0].Passes[i];
                shaderPasses[i] = map.Deserialize(item.Pass.Ident) as ShaderPassBlock;
                shaderPassPaths[i] = item.Pass.ToString();
            }
        }

        public MaterialShader()
        {
        }

        public void UsePass(int index, Dictionary<TagIdent, Texture> textures )
        {
            OpenGL.ReportError();
            ActiveShaderPassIndex = index;
            if (ActiveShaderPassIndex < 0)
            {
                return;
            }
            //  hacky cleanup
            for (int i = 0; i < 5; i++)
            {
                GL.ActiveTexture(TextureUnit.Texture1 + i);
                GL.BindTexture(TextureTarget.Texture2D, 0);
            }

            var template = shaderTemplate.PostprocessDefinition[0];
            var activePass = shaderTemplate.PostprocessDefinition[0].Passes[ActiveShaderPassIndex];
            var implementations = template.Implementations.ToList()
                .GetRange(activePass.Implementations.Index, activePass.Implementations.Length);
            var remappings = template.Remappings.ToList();
            for (int implementationIndex = implementations.Count - 1; implementationIndex < implementations.Count; ++implementationIndex)
            {
                var shaderPass = shaderPasses[ActiveShaderPassIndex].PostprocessDefinition[0];
                var shaderPassImplementation = shaderPass.Implementations[implementationIndex];
                for (int i = 0; i < shaderPassImplementation.Textures.Length; ++i)
                {
                    var texture = shaderPass.Textures[shaderPassImplementation.Textures.Index + i];
                    var bitmap = texture.BitmapParameterIndex;
                    if (bitmap == byte.MaxValue) 
                        continue;

                    var texturestage = texture.TextureStageIndex;

                    OpenGL.ReportError();
                    GL.ActiveTexture(TextureUnit.Texture1 + texturestage);
                    OpenGL.ReportError();
#if DEBUG
                    var bitmapString =
                        shader.PostprocessDefinition[0].Bitmaps[
                            remappings[implementations[implementationIndex].Bitmaps.Index + bitmap].SourceIndex]
                            .BitmapGroup.ToString();
#endif

                    textures[
                        shader.PostprocessDefinition[0].Bitmaps[
                            remappings[implementations[implementationIndex].Bitmaps.Index + bitmap].SourceIndex]
                            .BitmapGroup].Bind();
                    OpenGL.ReportError();
                }
                break;
            }
        }
    }
}