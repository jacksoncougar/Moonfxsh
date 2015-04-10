// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wind")]
    public  partial class WindBlock : WindBlockBase
    {
        public  WindBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class WindBlockBase
    {
        /// <summary>
        /// the wind magnitude in the weather region scales the wind between these bounds
        /// </summary>
        internal Moonfish.Model.Range velocityWorldUnits;
        /// <summary>
        /// the wind direction varies inside a box defined by these angles on either side of the direction from the weather region.
        /// </summary>
        internal OpenTK.Vector2 variationArea;
        internal float localVariationWeight;
        internal float localVariationRate;
        internal float damping;
        internal byte[] invalidName_;
        internal  WindBlockBase(System.IO.BinaryReader binaryReader)
        {
            velocityWorldUnits = binaryReader.ReadRange();
            variationArea = binaryReader.ReadVector2();
            localVariationWeight = binaryReader.ReadSingle();
            localVariationRate = binaryReader.ReadSingle();
            damping = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(36);
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
                binaryWriter.Write(velocityWorldUnits);
                binaryWriter.Write(variationArea);
                binaryWriter.Write(localVariationWeight);
                binaryWriter.Write(localVariationRate);
                binaryWriter.Write(damping);
                binaryWriter.Write(invalidName_, 0, 36);
            }
        }
    };
}
