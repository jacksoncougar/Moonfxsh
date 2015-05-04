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
        public static readonly TagClass Goof = (TagClass) "goof";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("goof")]
    public partial class MultiplayerVariantSettingsInterfaceDefinitionBlock :
        MultiplayerVariantSettingsInterfaceDefinitionBlockBase
    {
        public MultiplayerVariantSettingsInterfaceDefinitionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 368, Alignment = 4)]
    public class MultiplayerVariantSettingsInterfaceDefinitionBlockBase : GuerillaBlock
    {
        [TagReference("wgit")] internal Moonfish.Tags.TagReference invalidName_;
        [TagReference("wgit")] internal Moonfish.Tags.TagReference invalidName_0;
        [TagReference("wgit")] internal Moonfish.Tags.TagReference invalidName_1;
        internal VariantSettingEditReferenceBlock[] gameEngineSettings;
        [TagReference("unic")] internal Moonfish.Tags.TagReference defaultVariantStrings;
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

        public override int SerializedSize
        {
            get { return 368; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MultiplayerVariantSettingsInterfaceDefinitionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadTagReference();
            invalidName_1 = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<VariantSettingEditReferenceBlock>(binaryReader));
            defaultVariantStrings = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<GDefaultVariantsBlock>(binaryReader));
            createNewVariantStruct = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct.ReadFields(binaryReader)));
            createNewVariantStruct0 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct0.ReadFields(binaryReader)));
            createNewVariantStruct1 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct1.ReadFields(binaryReader)));
            createNewVariantStruct2 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct2.ReadFields(binaryReader)));
            createNewVariantStruct3 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct3.ReadFields(binaryReader)));
            createNewVariantStruct4 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct4.ReadFields(binaryReader)));
            createNewVariantStruct5 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct5.ReadFields(binaryReader)));
            createNewVariantStruct6 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct6.ReadFields(binaryReader)));
            createNewVariantStruct7 = new CreateNewVariantStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct7.ReadFields(binaryReader)));
            unusedCreateNewVariants = new[]
            {
                new UnusedCreateNewVariants(), new UnusedCreateNewVariants(), new UnusedCreateNewVariants(),
                new UnusedCreateNewVariants(), new UnusedCreateNewVariants(), new UnusedCreateNewVariants(),
                new UnusedCreateNewVariants()
            };
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(unusedCreateNewVariants[0].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(unusedCreateNewVariants[1].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(unusedCreateNewVariants[2].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(unusedCreateNewVariants[3].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(unusedCreateNewVariants[4].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(unusedCreateNewVariants[5].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(unusedCreateNewVariants[6].ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            gameEngineSettings = ReadBlockArrayData<VariantSettingEditReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
            defaultVariants = ReadBlockArrayData<GDefaultVariantsBlock>(binaryReader, blamPointers.Dequeue());
            createNewVariantStruct.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct0.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct1.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct2.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct3.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct4.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct5.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct6.ReadPointers(binaryReader, blamPointers);
            createNewVariantStruct7.ReadPointers(binaryReader, blamPointers);
            unusedCreateNewVariants[0].ReadPointers(binaryReader, blamPointers);
            unusedCreateNewVariants[1].ReadPointers(binaryReader, blamPointers);
            unusedCreateNewVariants[2].ReadPointers(binaryReader, blamPointers);
            unusedCreateNewVariants[3].ReadPointers(binaryReader, blamPointers);
            unusedCreateNewVariants[4].ReadPointers(binaryReader, blamPointers);
            unusedCreateNewVariants[5].ReadPointers(binaryReader, blamPointers);
            unusedCreateNewVariants[6].ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                nextAddress = Guerilla.WriteBlockArray<VariantSettingEditReferenceBlock>(binaryWriter,
                    gameEngineSettings, nextAddress);
                binaryWriter.Write(defaultVariantStrings);
                nextAddress = Guerilla.WriteBlockArray<GDefaultVariantsBlock>(binaryWriter, defaultVariants, nextAddress);
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
                return nextAddress;
            }
        }

        [LayoutAttribute(Size = 20, Alignment = 1)]
        public class UnusedCreateNewVariants : GuerillaBlock
        {
            internal CreateNewVariantStructBlock createNewVariantStruct;

            public override int SerializedSize
            {
                get { return 20; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public UnusedCreateNewVariants() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                createNewVariantStruct = new CreateNewVariantStructBlock();
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(createNewVariantStruct.ReadFields(binaryReader)));
                return blamPointers;
            }

            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
                createNewVariantStruct.ReadPointers(binaryReader, blamPointers);
            }

            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
                using (binaryWriter.BaseStream.Pin())
                {
                    createNewVariantStruct.Write(binaryWriter);
                    return nextAddress;
                }
            }
        };
    };
}