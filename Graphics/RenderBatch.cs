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
        public Dictionary<string, dynamic> Attributes { get; private set; }
        public Dictionary<string, dynamic> Uniforms { get; private set; }
        public Dictionary<EnableCap, bool> RenderStates { get; private set; }

        public RenderBatch( )
            : this( 0, 0, 0 )
        {
        }

        public RenderBatch( int attributeCount, int uniformCount, int stateCount )
        {
            this.Shader = new ShaderReference( ShaderReference.ReferenceType.System, 0 );
            this.Attributes = new Dictionary<string, object>( attributeCount );
            this.Uniforms = new Dictionary<string, object>( uniformCount );
            this.RenderStates = new Dictionary<EnableCap, bool>( stateCount );
            this.PrimitiveType = PrimitiveType.TriangleStrip;
            this.DrawElementsType = DrawElementsType.UnsignedShort;
        }

        public void AssignAttribute( string attributeName, dynamic value )
        {
            this.Attributes[ attributeName ] = value;
        }

        public void AssignUniform( string uniformName, dynamic value )
        {
            this.Uniforms[ uniformName ] = value;
        }

        public void AssignRenderState( EnableCap state, bool value )
        {
            this.RenderStates[ state ] = value;
        }
    }
}