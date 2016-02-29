using System.ComponentModel;

namespace Moonfish.Graphics
{
    public class VertexShader
    {
        public VertexShader( NV30Shader.ScalarOps scalarOp, NV30Shader.VectorOps vectorOp, int constantSource, int attributerSource )
        {
            ScalarOp = scalarOp;
            VectorOp = vectorOp;
            ConstantSource = constantSource;
            AttributerSource = attributerSource;
        }

        public int AttributerSource { get; }
        public int ConstantSource { get; }
        public NV30Shader.DestinationRegister Destination { get; }
        public WriteMask DstScalarWriteMask { get; }
        public WriteMask DstTempWriteMask { get; }
        public WriteMask DstVectorWriteMask { get; }
        public int IndexConstant { get; }
        public bool LastInstruction { get; }
        public int RegisterSource { get; }
        public NV30Shader.ScalarOps ScalarOp { get; }
        public bool ScalarResult { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source0 { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source1 { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source2 { get; }

        public NV30Shader.VectorOps VectorOp { get; }
    }
}