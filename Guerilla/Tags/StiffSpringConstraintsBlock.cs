using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StiffSpringConstraintsBlock : StiffSpringConstraintsBlockBase
    {
        public  StiffSpringConstraintsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 124)]
    public class StiffSpringConstraintsBlockBase
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float springLength;
        internal  StiffSpringConstraintsBlockBase(BinaryReader binaryReader)
        {
            this.constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.springLength = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
