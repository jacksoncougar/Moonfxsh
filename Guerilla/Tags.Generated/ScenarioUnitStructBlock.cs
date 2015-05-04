// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioUnitStructBlock : ScenarioUnitStructBlockBase
    {
        public  ScenarioUnitStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioUnitStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioUnitStructBlockBase : GuerillaBlock
    {
        internal float bodyVitality01;
        internal Flags flags;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioUnitStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bodyVitality01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public  ScenarioUnitStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            bodyVitality01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bodyVitality01);
                binaryWriter.Write((Int32)flags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Dead = 1,
            Closed = 2,
            NotEnterableByPlayer = 4,
        };
    };
}
