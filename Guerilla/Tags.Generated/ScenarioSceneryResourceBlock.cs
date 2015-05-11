// ReSharper disable All

using Moonfish.Model;

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
        public static readonly TagClass Cen = (TagClass) "*cen";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*cen")]
    public partial class ScenarioSceneryResourceBlock : ScenarioSceneryResourceBlockBase
    {
        public ScenarioSceneryResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class ScenarioSceneryResourceBlockBase : GuerillaBlock
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal ScenarioSceneryPaletteBlock[] palette;
        internal ScenarioSceneryBlock[] objects;
        internal int nextSceneryObjectIDSalt;
        internal ScenarioCratePaletteBlock[] palette0;
        internal ScenarioCrateBlock[] objects0;
        internal int nextBlockObjectIDSalt;
        internal GScenarioEditorFolderBlock[] editorFolders;

        public override int SerializedSize
        {
            get { return 72; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioSceneryResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioObjectNamesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSceneryPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSceneryBlock>(binaryReader));
            nextSceneryObjectIDSalt = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCratePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCrateBlock>(binaryReader));
            nextBlockObjectIDSalt = binaryReader.ReadInt32();
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
            palette = ReadBlockArrayData<ScenarioSceneryPaletteBlock>(binaryReader, blamPointers.Dequeue());
            objects = ReadBlockArrayData<ScenarioSceneryBlock>(binaryReader, blamPointers.Dequeue());
            palette0 = ReadBlockArrayData<ScenarioCratePaletteBlock>(binaryReader, blamPointers.Dequeue());
            objects0 = ReadBlockArrayData<ScenarioCrateBlock>(binaryReader, blamPointers.Dequeue());
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
                nextAddress = Guerilla.WriteBlockArray<ScenarioSceneryPaletteBlock>(binaryWriter, palette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSceneryBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(nextSceneryObjectIDSalt);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCratePaletteBlock>(binaryWriter, palette0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCrateBlock>(binaryWriter, objects0, nextAddress);
                binaryWriter.Write(nextBlockObjectIDSalt);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}