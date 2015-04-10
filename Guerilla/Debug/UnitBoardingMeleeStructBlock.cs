// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitBoardingMeleeStructBlock : UnitBoardingMeleeStructBlockBase
    {
        public  UnitBoardingMeleeStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class UnitBoardingMeleeStructBlockBase
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference boardingMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference boardingMeleeResponse;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference landingMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference flurryMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference obstacleSmashDamage;
        internal  UnitBoardingMeleeStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            boardingMeleeDamage = binaryReader.ReadTagReference();
            boardingMeleeResponse = binaryReader.ReadTagReference();
            landingMeleeDamage = binaryReader.ReadTagReference();
            flurryMeleeDamage = binaryReader.ReadTagReference();
            obstacleSmashDamage = binaryReader.ReadTagReference();
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
                binaryWriter.Write(boardingMeleeDamage);
                binaryWriter.Write(boardingMeleeResponse);
                binaryWriter.Write(landingMeleeDamage);
                binaryWriter.Write(flurryMeleeDamage);
                binaryWriter.Write(obstacleSmashDamage);
            }
        }
    };
}
