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
        public static readonly TagClass Ehi = (TagClass) "*ehi";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*ehi")]
    public partial class ScenarioVehiclesResourceBlock : ScenarioVehiclesResourceBlockBase
    {
        public ScenarioVehiclesResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ScenarioVehiclesResourceBlockBase : GuerillaBlock
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal ScenarioVehiclePaletteBlock[] palette;
        internal ScenarioVehicleBlock[] objects;
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

        public ScenarioVehiclesResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioObjectNamesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioVehiclePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioVehicleBlock>(binaryReader));
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
            palette = ReadBlockArrayData<ScenarioVehiclePaletteBlock>(binaryReader, blamPointers.Dequeue());
            objects = ReadBlockArrayData<ScenarioVehicleBlock>(binaryReader, blamPointers.Dequeue());
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
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehiclePaletteBlock>(binaryWriter, palette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehicleBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(nextObjectIDSalt);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}