using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ConstraintBodiesStructBlock : ConstraintBodiesStructBlockBase
    {
        public  ConstraintBodiesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class ConstraintBodiesStructBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 nodeA;
        internal Moonfish.Tags.ShortBlockIndex1 nodeB;
        internal float aScale;
        internal OpenTK.Vector3 aForward;
        internal OpenTK.Vector3 aLeft;
        internal OpenTK.Vector3 aUp;
        internal OpenTK.Vector3 aPosition;
        internal float bScale;
        internal OpenTK.Vector3 bForward;
        internal OpenTK.Vector3 bLeft;
        internal OpenTK.Vector3 bUp;
        internal OpenTK.Vector3 bPosition;
        internal Moonfish.Tags.ShortBlockIndex1 edgeIndex;
        internal byte[] invalidName_;
        internal  ConstraintBodiesStructBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.nodeA = binaryReader.ReadShortBlockIndex1();
            this.nodeB = binaryReader.ReadShortBlockIndex1();
            this.aScale = binaryReader.ReadSingle();
            this.aForward = binaryReader.ReadVector3();
            this.aLeft = binaryReader.ReadVector3();
            this.aUp = binaryReader.ReadVector3();
            this.aPosition = binaryReader.ReadVector3();
            this.bScale = binaryReader.ReadSingle();
            this.bForward = binaryReader.ReadVector3();
            this.bLeft = binaryReader.ReadVector3();
            this.bUp = binaryReader.ReadVector3();
            this.bPosition = binaryReader.ReadVector3();
            this.edgeIndex = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
