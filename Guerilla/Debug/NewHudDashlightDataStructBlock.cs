// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class NewHudDashlightDataStructBlock : NewHudDashlightDataStructBlockBase
    {
        public  NewHudDashlightDataStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class NewHudDashlightDataStructBlockBase
    {
        /// <summary>
        /// the cutoff for showing the reload dashlight
        /// </summary>
        internal short lowClipCutoff;
        /// <summary>
        /// the cutoff for showing the low ammo dashlight
        /// </summary>
        internal short lowAmmoCutoff;
        /// <summary>
        /// the ageCutoff for showing the low battery dashlight
        /// </summary>
        internal float ageCutoff;
        internal  NewHudDashlightDataStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            lowClipCutoff = binaryReader.ReadInt16();
            lowAmmoCutoff = binaryReader.ReadInt16();
            ageCutoff = binaryReader.ReadSingle();
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
                binaryWriter.Write(lowClipCutoff);
                binaryWriter.Write(lowAmmoCutoff);
                binaryWriter.Write(ageCutoff);
            }
        }
    };
}
