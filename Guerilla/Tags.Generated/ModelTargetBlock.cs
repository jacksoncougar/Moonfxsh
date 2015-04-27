// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelTargetBlock : ModelTargetBlockBase
    {
        public  ModelTargetBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ModelTargetBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class ModelTargetBlockBase : GuerillaBlock
    {
        /// <summary>
        /// multiple markers become multiple spheres of the same radius
        /// </summary>
        internal Moonfish.Tags.StringID markerName;
        /// <summary>
        /// sphere radius
        /// </summary>
        internal float size;
        /// <summary>
        /// the target is only visible when viewed within this angle of the marker's x axis
        /// </summary>
        internal float coneAngle;
        /// <summary>
        /// the target is associated with this damageSection
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex2 damageSection;
        /// <summary>
        /// the target will only appear with this variant
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 variant;
        /// <summary>
        /// higher relevances turn into stronger magnetisms
        /// </summary>
        internal float targetingRelevance;
        internal ModelTargetLockOnDataStructBlock lockOnData;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ModelTargetBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            markerName = binaryReader.ReadStringID();
            size = binaryReader.ReadSingle();
            coneAngle = binaryReader.ReadSingle();
            damageSection = binaryReader.ReadShortBlockIndex2();
            variant = binaryReader.ReadShortBlockIndex1();
            targetingRelevance = binaryReader.ReadSingle();
            lockOnData = new ModelTargetLockOnDataStructBlock(binaryReader);
        }
        public  ModelTargetBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            markerName = binaryReader.ReadStringID();
            size = binaryReader.ReadSingle();
            coneAngle = binaryReader.ReadSingle();
            damageSection = binaryReader.ReadShortBlockIndex2();
            variant = binaryReader.ReadShortBlockIndex1();
            targetingRelevance = binaryReader.ReadSingle();
            lockOnData = new ModelTargetLockOnDataStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(markerName);
                binaryWriter.Write(size);
                binaryWriter.Write(coneAngle);
                binaryWriter.Write(damageSection);
                binaryWriter.Write(variant);
                binaryWriter.Write(targetingRelevance);
                lockOnData.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
