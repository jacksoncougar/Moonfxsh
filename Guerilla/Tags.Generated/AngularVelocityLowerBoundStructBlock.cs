// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AngularVelocityLowerBoundStructBlock : AngularVelocityLowerBoundStructBlockBase
    {
        public  AngularVelocityLowerBoundStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AngularVelocityLowerBoundStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AngularVelocityLowerBoundStructBlockBase : GuerillaBlock
    {
        internal float guidedAngularVelocityLowerDegreesPerSecond;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AngularVelocityLowerBoundStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            guidedAngularVelocityLowerDegreesPerSecond = binaryReader.ReadSingle();
        }
        public  AngularVelocityLowerBoundStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            guidedAngularVelocityLowerDegreesPerSecond = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(guidedAngularVelocityLowerDegreesPerSecond);
                return nextAddress;
            }
        }
    };
}
