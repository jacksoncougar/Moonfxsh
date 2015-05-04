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
        public static readonly TagClass Sce = (TagClass) "*sce";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*sce")]
    public partial class ScenarioSoundSceneryResourceBlock : ScenarioSoundSceneryResourceBlockBase
    {
        public ScenarioSoundSceneryResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ScenarioSoundSceneryResourceBlockBase : GuerillaBlock
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal ScenarioSoundSceneryPaletteBlock[] palette;
        internal ScenarioSoundSceneryBlock[] objects;
        internal int nextObjectIDSalt;
        internal GScenarioEditorFolderBlock[] editorFolders;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioSoundSceneryResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioObjectNamesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSoundSceneryPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSoundSceneryBlock>(binaryReader));
            nextObjectIDSalt = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<GScenarioEditorFolderBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            names = ReadBlockArrayData<ScenarioObjectNamesBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_ = ReadBlockArrayData<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader,
                blamPointers.Dequeue());
            structureReferences = ReadBlockArrayData<ScenarioStructureBspReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
            palette = ReadBlockArrayData<ScenarioSoundSceneryPaletteBlock>(binaryReader, blamPointers.Dequeue());
            objects = ReadBlockArrayData<ScenarioSoundSceneryBlock>(binaryReader, blamPointers.Dequeue());
            editorFolders = ReadBlockArrayData<GScenarioEditorFolderBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, names, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryWriter,
                    invalidName_, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter,
                    structureReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSoundSceneryPaletteBlock>(binaryWriter, palette,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSoundSceneryBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(nextObjectIDSalt);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}