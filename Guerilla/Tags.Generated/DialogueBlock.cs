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
        public static readonly TagClass Udlg = (TagClass)"udlg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("udlg")]
    public partial class DialogueBlock : DialogueBlockBase
    {
        public  DialogueBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DialogueBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class DialogueBlockBase : GuerillaBlock
    {
        [TagReference("adlg")]
        internal Moonfish.Tags.TagReference globalDialogueInfo;
        internal Flags flags;
        internal SoundReferencesBlock[] vocalizations;
        /// <summary>
        /// 3-letter missionDialogueDesignator name
        /// </summary>
        internal Moonfish.Tags.StringID missionDialogueDesignator;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DialogueBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            globalDialogueInfo = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            vocalizations = Guerilla.ReadBlockArray<SoundReferencesBlock>(binaryReader);
            missionDialogueDesignator = binaryReader.ReadStringID();
        }
        public  DialogueBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            globalDialogueInfo = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            vocalizations = Guerilla.ReadBlockArray<SoundReferencesBlock>(binaryReader);
            missionDialogueDesignator = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(globalDialogueInfo);
                binaryWriter.Write((Int32)flags);
                nextAddress = Guerilla.WriteBlockArray<SoundReferencesBlock>(binaryWriter, vocalizations, nextAddress);
                binaryWriter.Write(missionDialogueDesignator);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Female = 1,
        };
    };
}
