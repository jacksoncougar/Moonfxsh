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
        public static readonly TagClass WgtzClass = (TagClass)"wgtz";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wgtz")]
    public  partial class UserInterfaceGlobalsDefinitionBlock : UserInterfaceGlobalsDefinitionBlockBase
    {
        public  UserInterfaceGlobalsDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class UserInterfaceGlobalsDefinitionBlockBase  : IGuerilla
    {
        [TagReference("wigl")]
        internal Moonfish.Tags.TagReference sharedGlobals;
        internal UserInterfaceWidgetReferenceBlock[] screenWidgets;
        [TagReference("goof")]
        internal Moonfish.Tags.TagReference mpVariantSettingsUi;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference gameHopperDescriptions;
        internal  UserInterfaceGlobalsDefinitionBlockBase(BinaryReader binaryReader)
        {
            sharedGlobals = binaryReader.ReadTagReference();
            screenWidgets = Guerilla.ReadBlockArray<UserInterfaceWidgetReferenceBlock>(binaryReader);
            mpVariantSettingsUi = binaryReader.ReadTagReference();
            gameHopperDescriptions = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sharedGlobals);
                Guerilla.WriteBlockArray<UserInterfaceWidgetReferenceBlock>(binaryWriter, screenWidgets, nextAddress);
                binaryWriter.Write(mpVariantSettingsUi);
                binaryWriter.Write(gameHopperDescriptions);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
