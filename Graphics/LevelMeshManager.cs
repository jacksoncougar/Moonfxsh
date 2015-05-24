using System.Collections.Generic;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class LevelMeshManager
    {
        private ProgramManager ProgramManager { get; set; }

        public LevelMeshManager()
        {
            ClusterObjects = new List<RenderObject>();
            InstancedGeometryObjects = new List<RenderObject>();
            ProgramManager= new ProgramManager();
        }

        public ScenarioStructureBspBlock Level { get; private set; }
        public List<RenderObject> ClusterObjects { get; private set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

        public void LoadScenarioStructure(ScenarioStructureBspBlock levelBlock, CacheStream cacheStream)
        {
            Level = levelBlock;
            ClusterObjects = new List<RenderObject>();
            InstancedGeometryObjects = new List<RenderObject>();
            foreach (var cluster in Level.Clusters)
            {
                ClusterObjects.Add(new RenderObject(cluster));
            }
            foreach (var item in Level.InstancedGeometriesDefinitions)
            {
                InstancedGeometryObjects.Add(new RenderObject(item));
            }
            ProgramManager.LoadMaterials(Level.Materials, cacheStream, Enumerable.Range(0, Level.Materials.Length).ToList());
        }

        public void DrawLevel()
        {
            foreach (var batch in ClusterObjects.SelectMany(x => x.Batches))
            {
                if (batch.BatchObject == null) return;
                var program = ProgramManager.GetProgram(batch.Shader, "system");
                if (program == null) return;

                var usingProgram = program.Use();
                OpenGL.ReportError();

                GL.BindVertexArray(batch.BatchObject.VertexArrayObjectIdent);
                foreach (var attribute in batch.Attributes.Select(x => new { Name = x.Key, x.Value }))
                {
                    var attributeLocation = program.GetAttributeLocation(attribute.Name);
                    Program.SetAttribute(attributeLocation, attribute.Value);
                    OpenGL.ReportError();
                }
                foreach (var uniform in batch.Uniforms.Select(x => new { Name = x.Key, x.Value }))
                {
                    var uniformLocation = program.GetUniformLocation(uniform.Name);
                    program.SetUniform(uniformLocation, uniform.Value);
                }
                var openGLStates =
                    batch.RenderStates.Select(x => new { Capability = x.Key, Enabled = x.Value })
                        .Select(state => state.Enabled
                            ? OpenGL.Enable(state.Capability)
                            : OpenGL.Disable(state.Capability)).ToList();

                OpenGL.ReportError();

                batch.SetupGLRenderState();
                OpenGL.ReportError();
                GL.DrawElements(batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType, batch.ElementStartIndex);
                OpenGL.ReportError();
                batch.CleanupGLRenderState();
                OpenGL.ReportError();

                // Cleanup states
                foreach (var state in openGLStates) state.Dispose();
                usingProgram.Dispose();
                OpenGL.ReportError();
            }
        }
    }
}