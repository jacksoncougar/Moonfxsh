using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AngularVelocityLowerBoundStructBlock : AngularVelocityLowerBoundStructBlockBase
    {
        public  AngularVelocityLowerBoundStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class AngularVelocityLowerBoundStructBlockBase
    {
        internal float guidedAngularVelocityLowerDegreesPerSecond;
        internal  AngularVelocityLowerBoundStructBlockBase(BinaryReader binaryReader)
        {
            this.guidedAngularVelocityLowerDegreesPerSecond = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
