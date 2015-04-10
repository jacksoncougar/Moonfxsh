// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StaticSpawnZoneBlock : StaticSpawnZoneBlockBase
    {
        public  StaticSpawnZoneBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class StaticSpawnZoneBlockBase
    {
        internal StaticSpawnZoneDataStructBlock data;
        internal OpenTK.Vector3 position;
        internal float lowerHeight;
        internal float upperHeight;
        internal float innerRadius;
        internal float outerRadius;
        internal float weight;
        internal  StaticSpawnZoneBlockBase(System.IO.BinaryReader binaryReader)
        {
            data = new StaticSpawnZoneDataStructBlock(binaryReader);
            position = binaryReader.ReadVector3();
            lowerHeight = binaryReader.ReadSingle();
            upperHeight = binaryReader.ReadSingle();
            innerRadius = binaryReader.ReadSingle();
            outerRadius = binaryReader.ReadSingle();
            weight = binaryReader.ReadSingle();
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
                data.Write(binaryWriter);
                binaryWriter.Write(position);
                binaryWriter.Write(lowerHeight);
                binaryWriter.Write(upperHeight);
                binaryWriter.Write(innerRadius);
                binaryWriter.Write(outerRadius);
                binaryWriter.Write(weight);
            }
        }
    };
}
