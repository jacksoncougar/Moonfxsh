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
        public static readonly TagClass Dgr = (TagClass) "dgr*";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dgr*")]
    public partial class ScenarioDevicesResourceBlock : ScenarioDevicesResourceBlockBase
    {
        public ScenarioDevicesResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 100, Alignment = 4)]
    public class ScenarioDevicesResourceBlockBase : GuerillaBlock
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal DeviceGroupBlock[] deviceGroups;
        internal ScenarioMachineBlock[] machines;
        internal ScenarioMachinePaletteBlock[] machinesPalette;
        internal ScenarioControlBlock[] controls;
        internal ScenarioControlPaletteBlock[] controlsPalette;
        internal ScenarioLightFixtureBlock[] lightFixtures;
        internal ScenarioLightFixturePaletteBlock[] lightFixturesPalette;
        internal int nextMachineIdSalt;
        internal int nextControlIDSalt;
        internal int nextLightFixtureIDSalt;
        internal GScenarioEditorFolderBlock[] editorFolders;

        public override int SerializedSize
        {
            get { return 100; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioDevicesResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioObjectNamesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DeviceGroupBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioMachineBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioMachinePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioControlBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioControlPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioLightFixtureBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioLightFixturePaletteBlock>(binaryReader));
            nextMachineIdSalt = binaryReader.ReadInt32();
            nextControlIDSalt = binaryReader.ReadInt32();
            nextLightFixtureIDSalt = binaryReader.ReadInt32();
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
            deviceGroups = ReadBlockArrayData<DeviceGroupBlock>(binaryReader, blamPointers.Dequeue());
            machines = ReadBlockArrayData<ScenarioMachineBlock>(binaryReader, blamPointers.Dequeue());
            machinesPalette = ReadBlockArrayData<ScenarioMachinePaletteBlock>(binaryReader, blamPointers.Dequeue());
            controls = ReadBlockArrayData<ScenarioControlBlock>(binaryReader, blamPointers.Dequeue());
            controlsPalette = ReadBlockArrayData<ScenarioControlPaletteBlock>(binaryReader, blamPointers.Dequeue());
            lightFixtures = ReadBlockArrayData<ScenarioLightFixtureBlock>(binaryReader, blamPointers.Dequeue());
            lightFixturesPalette = ReadBlockArrayData<ScenarioLightFixturePaletteBlock>(binaryReader,
                blamPointers.Dequeue());
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
                nextAddress = Guerilla.WriteBlockArray<DeviceGroupBlock>(binaryWriter, deviceGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioMachineBlock>(binaryWriter, machines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioMachinePaletteBlock>(binaryWriter, machinesPalette,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioControlBlock>(binaryWriter, controls, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioControlPaletteBlock>(binaryWriter, controlsPalette,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightFixtureBlock>(binaryWriter, lightFixtures,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightFixturePaletteBlock>(binaryWriter,
                    lightFixturesPalette, nextAddress);
                binaryWriter.Write(nextMachineIdSalt);
                binaryWriter.Write(nextControlIDSalt);
                binaryWriter.Write(nextLightFixtureIDSalt);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}