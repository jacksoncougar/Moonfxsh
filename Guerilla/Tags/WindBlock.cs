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
        public  WindBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  WindBlockBase(BinaryReader binaryReader)
        {
            this.velocityWorldUnits = binaryReader.ReadRange();
            this.variationArea = binaryReader.ReadVector2();
            this.localVariationWeight = binaryReader.ReadSingle();
            this.localVariationRate = binaryReader.ReadSingle();
            this.damping = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(36);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
