// ReSharper disable All
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
        public  MultiplayerVariantSettingsInterfaceDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  MultiplayerVariantSettingsInterfaceDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadTagReference();
            invalidName_1 = binaryReader.ReadTagReference();
            ReadVariantSettingEditReferenceBlockArray(binaryReader);
            defaultVariantStrings = binaryReader.ReadTagReference();
            ReadGDefaultVariantsBlockArray(binaryReader);
            createNewVariantStruct = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct0 = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct1 = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct2 = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct3 = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct4 = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct5 = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct6 = new CreateNewVariantStructBlock(binaryReader);
            createNewVariantStruct7 = new CreateNewVariantStructBlock(binaryReader);
            unusedCreateNewVariants = new []{ new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader), new UnusedCreateNewVariants(binaryReader),  };
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
        internal  virtual VariantSettingEditReferenceBlock[] ReadVariantSettingEditReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VariantSettingEditReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VariantSettingEditReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VariantSettingEditReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GDefaultVariantsBlock[] ReadGDefaultVariantsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GDefaultVariantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GDefaultVariantsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GDefaultVariantsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVariantSettingEditReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGDefaultVariantsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                WriteVariantSettingEditReferenceBlockArray(binaryWriter);
                binaryWriter.Write(defaultVariantStrings);
                WriteGDefaultVariantsBlockArray(binaryWriter);
                createNewVariantStruct.Write(binaryWriter);
                createNewVariantStruct0.Write(binaryWriter);
                createNewVariantStruct1.Write(binaryWriter);
                createNewVariantStruct2.Write(binaryWriter);
                createNewVariantStruct3.Write(binaryWriter);
                createNewVariantStruct4.Write(binaryWriter);
                createNewVariantStruct5.Write(binaryWriter);
                createNewVariantStruct6.Write(binaryWriter);
                createNewVariantStruct7.Write(binaryWriter);
                unusedCreateNewVariants[0].Write(binaryWriter);
                unusedCreateNewVariants[1].Write(binaryWriter);
                unusedCreateNewVariants[2].Write(binaryWriter);
                unusedCreateNewVariants[3].Write(binaryWriter);
                unusedCreateNewVariants[4].Write(binaryWriter);
                unusedCreateNewVariants[5].Write(binaryWriter);
                unusedCreateNewVariants[6].Write(binaryWriter);
            }
        }
        public class UnusedCreateNewVariants
        {
            internal CreateNewVariantStructBlock createNewVariantStruct;
            internal  UnusedCreateNewVariants(System.IO.BinaryReader binaryReader)
            {
                createNewVariantStruct = new CreateNewVariantStructBlock(binaryReader);
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
                    createNewVariantStruct.Write(binaryWriter);
                }
            }
        };
    };
}
