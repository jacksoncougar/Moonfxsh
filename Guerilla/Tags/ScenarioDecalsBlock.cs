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
        public  ScenarioDecalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecalsBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 decalType;
        internal byte yaw127127;
        internal byte pitch127127;
        internal OpenTK.Vector3 position;
        internal  ScenarioDecalsBlockBase(BinaryReader binaryReader)
        {
            decalType = binaryReader.ReadShortBlockIndex1();
            yaw127127 = binaryReader.ReadByte();
            pitch127127 = binaryReader.ReadByte();
            position = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
