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
        public  ClothPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ClothPropertiesBlockBase(BinaryReader binaryReader)
        {
            this.integrationType = (IntegrationType)binaryReader.ReadInt16();
            this.numberIterations = binaryReader.ReadInt16();
            this.weight = binaryReader.ReadSingle();
            this.drag = binaryReader.ReadSingle();
            this.windScale = binaryReader.ReadSingle();
            this.windFlappinessScale = binaryReader.ReadSingle();
            this.longestRod = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(24);
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
        internal enum IntegrationType : short
        
        {
            Verlet = 0,
        };
    };
}
