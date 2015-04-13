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
        public static readonly TagClass GoofClass = (TagClass)"goof";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("goof")]
    public  partial class MultiplayerVariantSettingsInterfaceDefinitionBlock : MultiplayerVariantSettingsInterfaceDefinitionBlockBase
    {
        public  MultiplayerVariantSettingsInterfaceDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 368, Alignment = 4)]
    public class MultiplayerVariantSettingsInterfaceDefinitionBlockBase  : IGuerilla
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
            invalidName_ = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadTagReference();
            invalidName_1 = binaryReader.ReadTagReference();
            gameEngineSettings = Guerilla.ReadBlockArray<VariantSettingEditReferenceBlock>(binaryReader);
            defaultVariantStrings = binaryReader.ReadTagReference();
            defaultVariants = Guerilla.ReadBlockArray<GDefaultVariantsBlock>(binaryReader);
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
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                Guerilla.WriteBlockArray<VariantSettingEditReferenceBlock>(binaryWriter, gameEngineSettings, nextAddress);
                binaryWriter.Write(defaultVariantStrings);
                Guerilla.WriteBlockArray<GDefaultVariantsBlock>(binaryWriter, defaultVariants, nextAddress);
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
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        public class UnusedCreateNewVariants  : IGuerilla
        {
            internal CreateNewVariantStructBlock createNewVariantStruct;
            internal  UnusedCreateNewVariants(BinaryReader binaryReader)
            {
                createNewVariantStruct = new CreateNewVariantStructBlock(binaryReader);
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    createNewVariantStruct.Write(binaryWriter);
                    return nextAddress = (int)binaryWriter.BaseStream.Position;
                }
            }
        };
    };
}
