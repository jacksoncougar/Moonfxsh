using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("goof")]
    public  partial class MultiplayerVariantSettingsInterfaceDefinitionBlock : MultiplayerVariantSettingsInterfaceDefinitionBlockBase
    {
        public  MultiplayerVariantSettingsInterfaceDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 368)]
    public class MultiplayerVariantSettingsInterfaceDefinitionBlockBase
    {
        [TagReference("wgit")]
        internal Moonfish.Tags.TagReference invalidName_;
        [TagReference("wgit")]
        internal Moonfish.Tags.TagReference invalidName_0;
        [TagReference("wgit")]
        internal Moonfish.Tags.TagReference invalidName_1;
        internal VariantSettingEditReferenceBlock[] gameEngineSettings;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference defaultVariantStrings;
        internal GDefaultVariantsBlock[] defaultVariants;
        internal CreateNewVariantStructBlock createNewVariantStruct;
        internal CreateNewVariantStructBlock createNewVariantStruct0;
        internal CreateNewVariantStructBlock createNewVariantStruct1;
        internal CreateNewVariantStructBlock createNewVariantStruct2;
        internal CreateNewVariantStructBlock createNewVariantStruct3;
        internal CreateNewVariantStructBlock createNewVariantStruct4;
        internal CreateNewVariantStructBlock createNewVariantStruct5;
        internal CreateNewVariantStructBlock createNewVariantStruct6;
        internal CreateNewVariantStructBlock createNewVariantStruct7;
        internal UnusedCreateNewVariants[] unusedCreateNewVariants;
        internal  MultiplayerVariantSettingsInterfaceDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadTagReference();
            this.invalidName_1 = binaryReader.ReadTagReference();
            this.gameEngineSettings = ReadVariantSettingEditReferenceBlockArray(binaryReader);
            this.defaultVariantStrings = binaryReader.ReadTagReference();
            this.defaultVariants = ReadGDefaultVariantsBlockArray(binaryReader);
            this.createNewVariantStruct = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct0 = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct1 = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct2 = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct3 = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct4 = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct5 = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct6 = new CreateNewVariantStructBlock(binaryReader);
            this.createNewVariantStruct7 = new CreateNewVariantStructBlock(binaryReader);
            this.unusedCreateNewVariants = new []{ new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader),  };
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
        internal  virtual VariantSettingEditReferenceBlock[] ReadVariantSettingEditReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VariantSettingEditReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VariantSettingEditReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VariantSettingEditReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GDefaultVariantsBlock[] ReadGDefaultVariantsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GDefaultVariantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GDefaultVariantsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GDefaultVariantsBlock(binaryReader);
                }
            }
            return array;
        }
        public class UnusedCreateNewVariants
        {
            internal CreateNewVariantStructBlock createNewVariantStruct;
            internal  UnusedCreateNewVariants(BinaryReader binaryReader)
            {
                this.createNewVariantStruct = new CreateNewVariantStructBlock(binaryReader);
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
        };
    };
}
