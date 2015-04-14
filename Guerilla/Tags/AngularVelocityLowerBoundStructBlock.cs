// ReSharper disable All
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
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AngularVelocityLowerBoundStructBlockBase  : IGuerilla
    {
        internal float guidedAngularVelocityLowerDegreesPerSecond;
        internal  AngularVelocityLowerBoundStructBlockBase(BinaryReader binaryReader)
        {
            guidedAngularVelocityLowerDegreesPerSecond = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(guidedAngularVelocityLowerDegreesPerSecond);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
