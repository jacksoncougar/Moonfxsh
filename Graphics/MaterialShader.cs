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
            Textures = new List<Texture>(shader.PostprocessDefinition[0].Bitmaps.Length);
            foreach (var item in shader.PostprocessDefinition[0].Bitmaps)
            {
                var texture = new Texture();
                if (!TagIdent.IsNull(item.BitmapGroup))
                {
                    var bitmapBlock = (BitmapBlock) map.Deserialize(item.BitmapGroup);
                    texture.Load(bitmapBlock, map);
                }
                Textures.Add(texture);
            }

            //  Load shader template class and load shader passes

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
            Textures = new List<Texture>();
        }

        public void UsePass(int index)
        {
            ActiveShaderPassIndex = index;
            if (ActiveShaderPassIndex < 0) return;

            var template = shaderTemplate.PostprocessDefinition[0];
            var activePass = shaderTemplate.PostprocessDefinition[0].Passes[ActiveShaderPassIndex];
            var implementations = template.Implementations.ToList()
                .GetRange(activePass.Implementations.Index, activePass.Implementations.Length);
            var remappings = template.Remappings.ToList();
            for (int implementationIndex = 0; implementationIndex < implementations.Count; ++implementationIndex)
            {
                var shaderPass = shaderPasses[ActiveShaderPassIndex].PostprocessDefinition[0];
                var shaderPassImplementation = shaderPass.Implementations[implementationIndex];
                for (int i = 0; i < shaderPassImplementation.Textures.Length; ++i)
                {
                    var texture = shaderPass.Textures[shaderPassImplementation.Textures.Index + i];
                    var bitmap = texture.BitmapParameterIndex;
                    if (bitmap == byte.MaxValue) continue;

                    var texturestage = texture.TextureStageIndex;

                    OpenGL.ReportError();
                    GL.ActiveTexture(TextureUnit.Texture1 + texturestage);
                    OpenGL.ReportError();
                    var bitmapString =
                        shader.PostprocessDefinition[0].Bitmaps[
                            remappings[implementations[implementationIndex].Bitmaps.Index + bitmap].SourceIndex]
                            .BitmapGroup.ToString();
                    Textures[remappings[implementations[implementationIndex].Bitmaps.Index + bitmap].SourceIndex]
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