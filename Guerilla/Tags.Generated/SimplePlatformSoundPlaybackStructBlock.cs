// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SimplePlatformSoundPlaybackStructBlock : SimplePlatformSoundPlaybackStructBlockBase
    {
        public  implePlatformSoundPlaybackStructBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 52, Alignment = 4) ]
    public class SimplePlatformSoundPlaybackStructBlockBase  GuerillaBlock
    {
        internal PlatformSoundOverrideMixbinsBlock[] platformSoundOverrideMixbinsBlock;
        internal Flags flags;
        internal byte[] invalidName_;
        internal PlatformSoundFilterBlock[] filter;
        internal PlatformSoundPitchLfoBlock[] pitchLfo;
        internal PlatformSoundFilterLfoBlock[] filterLfo;
        internal SoundEffectPlaybackBlock[] soundEffec

          
       public override int SerializedSize{get {  return 52; }}
        
         internal  SimplePlatformSoundPlaybackStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
             p latformSoundOverrideMixbi nsBlo c k = Guerilla.ReadBlockA rray<PlatformSoundOverrideMixbinsBlock>(binaryReader);  
            flags = (Flags)binaryReader.ReadInt32();
            invalidN ame_ = binar yReader.ReadBytes(8);
            filter = Guerilla.ReadBlockArray<PlatformSou ndFilterBloc k>(binaryReader);
            pitchLfo = Guerilla.ReadBlockArray<PlatformSoundPi tchLfoBlock> (binaryReader);
            filterLfo = Guerilla.ReadBlockArray<PlatformSoundFi lterLfoBlock >(binaryReade

               soundEffec t = Guerilla.ReadBlockArray<SoundEffectPlaybackBlock>( binaryReader);
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStrea m.Pin())
   
                            {
                nextAddress = Gueri lla.WriteBlockArray<PlatformSoundOverri d eMixb i nsBlo ck>(binaryWriter, platformSoundOverride MixbinsBlock, next Address);
                binaryWriter.Write((Int32)flags);
                binaryW riter.Write(invalidName_, 0, 8); 
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundFilterBlock>(binar yWriter, filter, nextAddress);
                 nextAddress = Guerilla.WriteBlockArray<PlatformSoundPitchLfoBlock>(binaryWr iter, pitchLfo, nextAddr
                    ss);
                 nextAddress = Guerilla.WriteBlockArray<PlatformSoundFilterLfoBlock>(binary Writer, filterLfo, nextAddress);
                 nextAddress = Guerilla.WriteBlockArray<SoundEffectPla

        >(binaryWriter, soundEffect, nextAddress);
                return nextAddress;
            }
        }
        [FlsAttribute]
        internal enum Flags : int
        {
            Use3DRadioHack = 1,
        };
    };
}
