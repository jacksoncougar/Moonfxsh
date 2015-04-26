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
        public  StaticSpawnZoneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class StaticSpawnZoneBlockBase  : IGuerilla
    {
        internal StaticSpawnZoneDataStructBlock data;
        internal OpenTK.Vector3 position;
        internal float lowerHeight;
        internal float upperHeight;
        internal float innerRadius;
        internal float outerRadius;
        internal float weight;
        internal  StaticSpawnZoneBlockBase(BinaryReader binaryReader)
        {
            data = new StaticSpawnZoneDataStructBlock(binaryReader);
            position = binaryReader.ReadVector3();
            lowerHeight = binaryReader.ReadSingle();
            upperHeight = binaryReader.ReadSingle();
            innerRadius = binaryReader.ReadSingle();
            outerRadius = binaryReader.ReadSingle();
            weight = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress;
            }
        }
    };
}
