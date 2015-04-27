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
        public static readonly TagClass Dgr = (TagClass)"dgr*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dgr*")]
    public partial class ScenarioDevicesResourceBlock : ScenarioDevicesResourceBlockBase
    {
        public  ScenarioDevicesResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioDevicesResourceBlock(): base()
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
        
        public override int SerializedSize{get { return 100; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioDevicesResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            names = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
            invalidName_ = Guerilla.ReadBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader);
            structureReferences = Guerilla.ReadBlockArray<ScenarioStructureBspReferenceBlock>(binaryReader);
            deviceGroups = Guerilla.ReadBlockArray<DeviceGroupBlock>(binaryReader);
            machines = Guerilla.ReadBlockArray<ScenarioMachineBlock>(binaryReader);
            machinesPalette = Guerilla.ReadBlockArray<ScenarioMachinePaletteBlock>(binaryReader);
            controls = Guerilla.ReadBlockArray<ScenarioControlBlock>(binaryReader);
            controlsPalette = Guerilla.ReadBlockArray<ScenarioControlPaletteBlock>(binaryReader);
            lightFixtures = Guerilla.ReadBlockArray<ScenarioLightFixtureBlock>(binaryReader);
            lightFixturesPalette = Guerilla.ReadBlockArray<ScenarioLightFixturePaletteBlock>(binaryReader);
            nextMachineIdSalt = binaryReader.ReadInt32();
            nextControlIDSalt = binaryReader.ReadInt32();
            nextLightFixtureIDSalt = binaryReader.ReadInt32();
            editorFolders = Guerilla.ReadBlockArray<GScenarioEditorFolderBlock>(binaryReader);
        }
        public  ScenarioDevicesResourceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, names, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryWriter, invalidName_, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, structureReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DeviceGroupBlock>(binaryWriter, deviceGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioMachineBlock>(binaryWriter, machines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioMachinePaletteBlock>(binaryWriter, machinesPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioControlBlock>(binaryWriter, controls, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioControlPaletteBlock>(binaryWriter, controlsPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightFixtureBlock>(binaryWriter, lightFixtures, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightFixturePaletteBlock>(binaryWriter, lightFixturesPalette, nextAddress);
                binaryWriter.Write(nextMachineIdSalt);
                binaryWriter.Write(nextControlIDSalt);
                binaryWriter.Write(nextLightFixtureIDSalt);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders, nextAddress);
                return nextAddress;
            }
        }
    };
}
