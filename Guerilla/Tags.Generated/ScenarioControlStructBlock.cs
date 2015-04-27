// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioControlStructBlock : ScenarioControlStructBlockBase
    {
        public  ScenarioControlStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioControlStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioControlStructBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal short dONTTOUCHTHIS;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioControlStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            dONTTOUCHTHIS = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  ScenarioControlStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(dONTTOUCHTHIS);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            UsableFromBothSides = 1,
        };
    };
}
