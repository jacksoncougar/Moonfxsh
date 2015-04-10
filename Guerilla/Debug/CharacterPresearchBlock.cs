// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterPresearchBlock : CharacterPresearchBlockBase
    {
        public  CharacterPresearchBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class CharacterPresearchBlockBase
    {
        internal PreSearchFlags preSearchFlags;
        /// <summary>
        /// If the min presearch time expires and the target is (actually) outside the min-certainty radius, presearch turns off
        /// </summary>
        internal Moonfish.Model.Range minPresearchTimeSeconds;
        /// <summary>
        /// Presearch turns off after the given time
        /// </summary>
        internal Moonfish.Model.Range maxPresearchTimeSeconds;
        internal float minCertaintyRadius;
        internal float dEPRECATED;
        /// <summary>
        /// if the minSuppressingTime expires and the target is outside the min-certainty radius, suppressing fire turns off
        /// </summary>
        internal Moonfish.Model.Range minSuppressingTime;
        internal  CharacterPresearchBlockBase(System.IO.BinaryReader binaryReader)
        {
            preSearchFlags = (PreSearchFlags)binaryReader.ReadInt32();
            minPresearchTimeSeconds = binaryReader.ReadRange();
            maxPresearchTimeSeconds = binaryReader.ReadRange();
            minCertaintyRadius = binaryReader.ReadSingle();
            dEPRECATED = binaryReader.ReadSingle();
            minSuppressingTime = binaryReader.ReadRange();
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
                binaryWriter.Write((Int32)preSearchFlags);
                binaryWriter.Write(minPresearchTimeSeconds);
                binaryWriter.Write(maxPresearchTimeSeconds);
                binaryWriter.Write(minCertaintyRadius);
                binaryWriter.Write(dEPRECATED);
                binaryWriter.Write(minSuppressingTime);
            }
        }
        [FlagsAttribute]
        internal enum PreSearchFlags : int
        
        {
            Flag1 = 1,
        };
    };
}
