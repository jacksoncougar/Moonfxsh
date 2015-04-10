using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wgtz")]
    public  partial class UserInterfaceGlobalsDefinitionBlock : UserInterfaceGlobalsDefinitionBlockBase
    {
        public  UserInterfaceGlobalsDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class UserInterfaceGlobalsDefinitionBlockBase
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
            this.sharedGlobals = binaryReader.ReadTagReference();
            this.screenWidgets = ReadUserInterfaceWidgetReferenceBlockArray(binaryReader);
            this.mpVariantSettingsUi = binaryReader.ReadTagReference();
            this.gameHopperDescriptions = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual UserInterfaceWidgetReferenceBlock[] ReadUserInterfaceWidgetReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserInterfaceWidgetReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserInterfaceWidgetReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserInterfaceWidgetReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
