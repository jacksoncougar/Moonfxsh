using System.ComponentModel;

namespace Moonfish.Graphics
{
    public class VertexShader
    {
        public VertexShader( VertexProgramInstruction.ScalarOps scalarOp, VertexProgramInstruction.VectorOps vectorOp, int constantSource, int attributerSource )
        {
            ScalarOp = scalarOp;
            VectorOp = vectorOp;
            ConstantSource = constantSource;
            AttributerSource = attributerSource;
        }

        public int AttributerSource { get; }
        public int ConstantSource { get; }
        public VertexProgramInstruction.DestinationRegister Destination { get; }
        public WriteMask DstScalarWriteMask { get; }
        public WriteMask DstTempWriteMask { get; }
        public WriteMask DstVectorWriteMask { get; }
        public int IndexConstant { get; }
        public bool LastInstruction { get; }
        public int RegisterSource { get; }
        public VertexProgramInstruction.ScalarOps ScalarOp { get; }
        public bool ScalarResult { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source0 { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source1 { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source2 { get; }

        public VertexProgramInstruction.VectorOps VectorOp { get; }
    }
}