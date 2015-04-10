// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelTargetBlock : ModelTargetBlockBase
    {
        public  ModelTargetBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class ModelTargetBlockBase
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
        internal  ModelTargetBlockBase(System.IO.BinaryReader binaryReader)
        {
            markerName = binaryReader.ReadStringID();
            size = binaryReader.ReadSingle();
            coneAngle = binaryReader.ReadSingle();
            damageSection = binaryReader.ReadShortBlockIndex2();
            variant = binaryReader.ReadShortBlockIndex1();
            targetingRelevance = binaryReader.ReadSingle();
            lockOnData = new ModelTargetLockOnDataStructBlock(binaryReader);
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
                binaryWriter.Write(markerName);
                binaryWriter.Write(size);
                binaryWriter.Write(coneAngle);
                binaryWriter.Write(damageSection);
                binaryWriter.Write(variant);
                binaryWriter.Write(targetingRelevance);
                lockOnData.Write(binaryWriter);
            }
        }
    };
}
