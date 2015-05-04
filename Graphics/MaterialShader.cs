using System;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class MaterialShader : IDisposable
    {
        private bool disposed = false;
        public List<Texture> Textures { get; private set; }

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

        public MaterialShader(ShaderBlock shader, CacheStream map)
            : this()
        {
            this.shader = shader;
            //  Load bitmap classes and transfer data into glTextures
            Textures = new List<Texture>(shader.postprocessDefinition[0].bitmaps.Length);
            foreach (var item in shader.postprocessDefinition[0].bitmaps)
            {
                var texture = new Texture();
                if (!TagIdent.IsNull(item.bitmapGroup))
                {
                    var bitmapBlock = (BitmapBlock) map.Deserialize(item.bitmapGroup);
                    texture.Load(bitmapBlock, map);
                }
                Textures.Add(texture);
            }

            //  Load shader template class and load shader passes

            var shaderTemplateIdent = (TagIdent) shader.postprocessDefinition[0].shaderTemplateIndex;
            this.shaderTemplate = map.Deserialize(shaderTemplateIdent) as ShaderTemplateBlock;

            this.shaderPasses = new ShaderPassBlock[shaderTemplate.postprocessDefinition[0].passes.Length];
            this.shaderPassPaths = new string[shaderTemplate.postprocessDefinition[0].passes.Length];
            for (int i = 0; i < shaderPasses.Length; ++i)
            {
                var item = shaderTemplate.postprocessDefinition[0].passes[i];
                shaderPasses[i] = map.Deserialize(item.pass.Ident) as ShaderPassBlock;
                shaderPassPaths[i] = item.pass.ToString();
            }
        }

        public MaterialShader()
        {
            Textures = new List<Texture>();
        }

        public void UsePass(int index)
        {
            ActiveShaderPassIndex = index;
            if (ActiveShaderPassIndex < 0) return;

            var template = shaderTemplate.postprocessDefinition[0];
            var activePass = shaderTemplate.postprocessDefinition[0].passes[ActiveShaderPassIndex];
            var implementations = template.implementations.ToList()
                .GetRange(activePass.implementations.Index, activePass.implementations.Length);
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

                    OpenGL.ReportError();
                    GL.ActiveTexture(TextureUnit.Texture1 + textureStage);
                    OpenGL.ReportError();
                    var bitmapString =
                        shader.postprocessDefinition[0].bitmaps[
                            remappings[implementations[implementationIndex].bitmaps.Index + bitmap].sourceIndex]
                            .bitmapGroup.ToString();
                    Textures[remappings[implementations[implementationIndex].bitmaps.Index + bitmap].sourceIndex]
                        .Bind();
                    OpenGL.ReportError();
                }
                break;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                foreach (var texture in Textures)
                {
                    texture.Dispose();
                }
            }
            disposed = true;
        }
    }
}