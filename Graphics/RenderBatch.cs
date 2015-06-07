using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class RenderBatch
    {
        public ShaderReference Shader { get; set; }
        public TriangleBatch BatchObject { get; set; }
        public PrimitiveType PrimitiveType { get; set; }
        public DrawElementsType DrawElementsType { get; set; }
        public int ElementStartIndex { get; set; }
        public int ElementLength { get; set; }
        public int InstanceCount { get; set; }

        public Dictionary<string, dynamic> Attributes { get; private set; }
        public Dictionary<string, dynamic> Uniforms { get; private set; }
        public Dictionary<EnableCap, bool> RenderStates { get; private set; }

        public void SetupGLRenderState()
        {
            if (ChangeState != null) ChangeState();
        }

        public void CleanupGLRenderState()
        {
            if (RevertState != null) RevertState();
        }

        public Action ChangeState { private get; set; }
        public Action RevertState { private get; set; }

        public RenderBatch()
            : this(0, 0, 0)
        {
        }

        public RenderBatch(int attributeCount, int uniformCount, int stateCount)
        {
            Shader = new ShaderReference(ShaderReference.ReferenceType.System, 0);
            Attributes = new Dictionary<string, object>(attributeCount);
            Uniforms = new Dictionary<string, object>(uniformCount);
            RenderStates = new Dictionary<EnableCap, bool>(stateCount);
            PrimitiveType = PrimitiveType.TriangleStrip;
            DrawElementsType = DrawElementsType.UnsignedShort;
        }

        public void AssignAttribute(string attributeName, dynamic value)
        {
            Attributes[attributeName] = value;
        }

        public void AssignUniform(string uniformName, dynamic value)
        {
            Uniforms[uniformName] = value;
        }

        public void AssignRenderState(EnableCap state, bool value)
        {
            RenderStates[state] = value;
        }
    }
}