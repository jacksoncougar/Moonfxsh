// ReSharper disable All
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
        public  UserInterfaceGlobalsDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  UserInterfaceGlobalsDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            sharedGlobals = binaryReader.ReadTagReference();
            ReadUserInterfaceWidgetReferenceBlockArray(binaryReader);
            mpVariantSettingsUi = binaryReader.ReadTagReference();
            gameHopperDescriptions = binaryReader.ReadTagReference();
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
        internal  virtual UserInterfaceWidgetReferenceBlock[] ReadUserInterfaceWidgetReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserInterfaceWidgetReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserInterfaceWidgetReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserInterfaceWidgetReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserInterfaceWidgetReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sharedGlobals);
                WriteUserInterfaceWidgetReferenceBlockArray(binaryWriter);
                binaryWriter.Write(mpVariantSettingsUi);
                binaryWriter.Write(gameHopperDescriptions);
            }
        }
    };
}
