// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioDecalsBlock : ScenarioDecalsBlockBase
    {
        public  ScenarioDecalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioDecalsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecalsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 decalType;
        internal byte yaw127127;
        internal byte pitch127127;
        internal OpenTK.Vector3 position;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioDecalsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            decalType = binaryReader.ReadShortBlockIndex1();
            yaw127127 = binaryReader.ReadByte();
            pitch127127 = binaryReader.ReadByte();
            position = binaryReader.ReadVector3();
        }
        public  ScenarioDecalsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            decalType = binaryReader.ReadShortBlockIndex1();
            yaw127127 = binaryReader.ReadByte();
            pitch127127 = binaryReader.ReadByte();
            position = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(decalType);
                binaryWriter.Write(yaw127127);
                binaryWriter.Write(pitch127127);
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}
