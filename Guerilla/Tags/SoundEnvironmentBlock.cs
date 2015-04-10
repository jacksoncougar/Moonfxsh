using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("snde")]
    public  partial class SoundEnvironmentBlock : SoundEnvironmentBlockBase
    {
        public  SoundEnvironmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class SoundEnvironmentBlockBase
    {
        internal byte[] invalidName_;
        /// <summary>
        /// when multiple listeners are in different sound environments in split screen, the combined environment will be the one with the highest priority.
        /// </summary>
        internal short priority;
        internal byte[] invalidName_0;
        /// <summary>
        /// intensity of the room effect
        /// </summary>
        internal float roomIntensityDB;
        /// <summary>
        /// intensity of the room effect above the reference high frequency
        /// </summary>
        internal float roomIntensityHfDB;
        /// <summary>
        /// how quickly the room effect rolls off, from 0.0 to 10.0
        /// </summary>
        internal float roomRolloff0To10;
        internal float decayTime1To20Seconds;
        internal float decayHfRatio1To2;
        internal float reflectionsIntensityDB10010;
        internal float reflectionsDelay0To3Seconds;
        internal float reverbIntensityDB10020;
        internal float reverbDelay0To1Seconds;
        internal float diffusion;
        internal float density;
        /// <summary>
        /// for hf values, what frequency defines hf, from 20 to 20,000
        /// </summary>
        internal float hfReference20To20000Hz;
        internal byte[] invalidName_1;
        internal  SoundEnvironmentBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.priority = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.roomIntensityDB = binaryReader.ReadSingle();
            this.roomIntensityHfDB = binaryReader.ReadSingle();
            this.roomRolloff0To10 = binaryReader.ReadSingle();
            this.decayTime1To20Seconds = binaryReader.ReadSingle();
            this.decayHfRatio1To2 = binaryReader.ReadSingle();
            this.reflectionsIntensityDB10010 = binaryReader.ReadSingle();
            this.reflectionsDelay0To3Seconds = binaryReader.ReadSingle();
            this.reverbIntensityDB10020 = binaryReader.ReadSingle();
            this.reverbDelay0To1Seconds = binaryReader.ReadSingle();
            this.diffusion = binaryReader.ReadSingle();
            this.density = binaryReader.ReadSingle();
            this.hfReference20To20000Hz = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(16);
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
    };
}
