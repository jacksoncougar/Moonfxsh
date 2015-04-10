// ReSharper disable All
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
        public  ScenarioDecalsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioDecalsBlockBase(System.IO.BinaryReader binaryReader)
        {
            decalType = binaryReader.ReadShortBlockIndex1();
            yaw127127 = binaryReader.ReadByte();
            pitch127127 = binaryReader.ReadByte();
            position = binaryReader.ReadVector3();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(decalType);
                binaryWriter.Write(yaw127127);
                binaryWriter.Write(pitch127127);
                binaryWriter.Write(position);
            }
        }
    };
}
