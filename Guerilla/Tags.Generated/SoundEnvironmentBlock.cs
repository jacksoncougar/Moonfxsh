// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Snde = (TagClass)"snde";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("snde")]
    public partial class SoundEnvironmentBlock : SoundEnvironmentBlockBase
    {
        public  SoundEnvironmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEnvironmentBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class SoundEnvironmentBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 72; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEnvironmentBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            priority = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            roomIntensityDB = binaryReader.ReadSingle();
            roomIntensityHfDB = binaryReader.ReadSingle();
            roomRolloff0To10 = binaryReader.ReadSingle();
            decayTime1To20Seconds = binaryReader.ReadSingle();
            decayHfRatio1To2 = binaryReader.ReadSingle();
            reflectionsIntensityDB10010 = binaryReader.ReadSingle();
            reflectionsDelay0To3Seconds = binaryReader.ReadSingle();
            reverbIntensityDB10020 = binaryReader.ReadSingle();
            reverbDelay0To1Seconds = binaryReader.ReadSingle();
            diffusion = binaryReader.ReadSingle();
            density = binaryReader.ReadSingle();
            hfReference20To20000Hz = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(16);
        }
        public  SoundEnvironmentBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            priority = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            roomIntensityDB = binaryReader.ReadSingle();
            roomIntensityHfDB = binaryReader.ReadSingle();
            roomRolloff0To10 = binaryReader.ReadSingle();
            decayTime1To20Seconds = binaryReader.ReadSingle();
            decayHfRatio1To2 = binaryReader.ReadSingle();
            reflectionsIntensityDB10010 = binaryReader.ReadSingle();
            reflectionsDelay0To3Seconds = binaryReader.ReadSingle();
            reverbIntensityDB10020 = binaryReader.ReadSingle();
            reverbDelay0To1Seconds = binaryReader.ReadSingle();
            diffusion = binaryReader.ReadSingle();
            density = binaryReader.ReadSingle();
            hfReference20To20000Hz = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(16);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(priority);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(roomIntensityDB);
                binaryWriter.Write(roomIntensityHfDB);
                binaryWriter.Write(roomRolloff0To10);
                binaryWriter.Write(decayTime1To20Seconds);
                binaryWriter.Write(decayHfRatio1To2);
                binaryWriter.Write(reflectionsIntensityDB10010);
                binaryWriter.Write(reflectionsDelay0To3Seconds);
                binaryWriter.Write(reverbIntensityDB10020);
                binaryWriter.Write(reverbDelay0To1Seconds);
                binaryWriter.Write(diffusion);
                binaryWriter.Write(density);
                binaryWriter.Write(hfReference20To20000Hz);
                binaryWriter.Write(invalidName_1, 0, 16);
                return nextAddress;
            }
        }
    };
}
