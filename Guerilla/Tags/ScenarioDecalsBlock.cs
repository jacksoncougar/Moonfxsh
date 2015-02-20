using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioDecalsBlock : ScenarioDecalsBlockBase
    {
        public  ScenarioDecalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ScenarioDecalsBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 decalType;
        internal byte yaw127127;
        internal byte pitch127127;
        internal OpenTK.Vector3 position;
        internal  ScenarioDecalsBlockBase(BinaryReader binaryReader)
        {
            this.decalType = binaryReader.ReadShortBlockIndex1();
            this.yaw127127 = binaryReader.ReadByte();
            this.pitch127127 = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
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
