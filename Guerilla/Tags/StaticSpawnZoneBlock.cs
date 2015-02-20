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
        internal  StaticSpawnZoneBlockBase(BinaryReader binaryReader)
        {
            this.data = new StaticSpawnZoneDataStructBlock(binaryReader);
            this.position = binaryReader.ReadVector3();
            this.lowerHeight = binaryReader.ReadSingle();
            this.upperHeight = binaryReader.ReadSingle();
            this.innerRadius = binaryReader.ReadSingle();
            this.outerRadius = binaryReader.ReadSingle();
            this.weight = binaryReader.ReadSingle();
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
