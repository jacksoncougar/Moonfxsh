// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ClothPropertiesBlock : ClothPropertiesBlockBase
    {
        public  ClothPropertiesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class ClothPropertiesBlockBase
    {
        internal IntegrationType integrationType;
        /// <summary>
        /// [1-8] sug 1
        /// </summary>
        internal short numberIterations;
        /// <summary>
        /// [-10.0 - 10.0] sug 1.0
        /// </summary>
        internal float weight;
        /// <summary>
        /// [0.0 - 0.5] sug 0.07
        /// </summary>
        internal float drag;
        /// <summary>
        /// [0.0 - 3.0] sug 1.0
        /// </summary>
        internal float windScale;
        /// <summary>
        /// [0.0 - 1.0] sug 0.75
        /// </summary>
        internal float windFlappinessScale;
        /// <summary>
        /// [1.0 - 10.0] sug 3.5
        /// </summary>
        internal float longestRod;
        internal byte[] invalidName_;
        internal  ClothPropertiesBlockBase(System.IO.BinaryReader binaryReader)
        {
            integrationType = (IntegrationType)binaryReader.ReadInt16();
            numberIterations = binaryReader.ReadInt16();
            weight = binaryReader.ReadSingle();
            drag = binaryReader.ReadSingle();
            windScale = binaryReader.ReadSingle();
            windFlappinessScale = binaryReader.ReadSingle();
            longestRod = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
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
                binaryWriter.Write((Int16)integrationType);
                binaryWriter.Write(numberIterations);
                binaryWriter.Write(weight);
                binaryWriter.Write(drag);
                binaryWriter.Write(windScale);
                binaryWriter.Write(windFlappinessScale);
                binaryWriter.Write(longestRod);
                binaryWriter.Write(invalidName_, 0, 24);
            }
        }
        internal enum IntegrationType : short
        
        {
            Verlet = 0,
        };
    };
}
