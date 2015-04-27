// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StaticSpawnZoneBlock : StaticSpawnZoneBlockBase
    {
        public  StaticSpawnZoneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StaticSpawnZoneBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class StaticSpawnZoneBlockBase : GuerillaBlock
    {
        internal StaticSpawnZoneDataStructBlock data;
        internal OpenTK.Vector3 position;
        internal float lowerHeight;
        internal float upperHeight;
        internal float innerRadius;
        internal float outerRadius;
        internal float weight;
        
        public override int SerializedSize{get { return 48; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StaticSpawnZoneBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            data = new StaticSpawnZoneDataStructBlock(binaryReader);
            position = binaryReader.ReadVector3();
            lowerHeight = binaryReader.ReadSingle();
            upperHeight = binaryReader.ReadSingle();
            innerRadius = binaryReader.ReadSingle();
            outerRadius = binaryReader.ReadSingle();
            weight = binaryReader.ReadSingle();
        }
        public  StaticSpawnZoneBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
