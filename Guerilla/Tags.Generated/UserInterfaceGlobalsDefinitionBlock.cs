// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Wgtz = (TagClass)"wgtz";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wgtz")]
    public partial class UserInterfaceGlobalsDefinitionBlock : UserInterfaceGlobalsDefinitionBlockBase
    {
        public UserInterfaceGlobalsDefinitionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class UserInterfaceGlobalsDefinitionBlockBase : GuerillaBlock
    {
        [TagReference("wigl")]
        internal Moonfish.Tags.TagReference sharedGlobals;
        internal UserInterfaceWidgetReferenceBlock[] screenWidgets;
        [TagReference("goof")]
        internal Moonfish.Tags.TagReference mpVariantSettingsUi;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference gameHopperDescriptions;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public UserInterfaceGlobalsDefinitionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sharedGlobals = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<UserInterfaceWidgetReferenceBlock>(binaryReader));
            mpVariantSettingsUi = binaryReader.ReadTagReference();
            gameHopperDescriptions = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            screenWidgets = ReadBlockArrayData<UserInterfaceWidgetReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sharedGlobals);
                nextAddress = Guerilla.WriteBlockArray<UserInterfaceWidgetReferenceBlock>(binaryWriter, screenWidgets, nextAddress);
                binaryWriter.Write(mpVariantSettingsUi);
                binaryWriter.Write(gameHopperDescriptions);
                return nextAddress;
            }
        }
    };
}
