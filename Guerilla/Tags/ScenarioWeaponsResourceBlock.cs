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
        public static readonly TagClass *EapClass = (TagClass)"*eap";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*eap")]
    public  partial class ScenarioWeaponsResourceBlock : ScenarioWeaponsResourceBlockBase
    {
        public  ScenarioWeaponsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ScenarioWeaponsResourceBlockBase  : IGuerilla
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal ScenarioWeaponPaletteBlock[] palette;
        internal ScenarioWeaponBlock[] objects;
        internal int nextObjectIDSalt;
        internal GScenarioEditorFolderBlock[] editorFolders;
        internal  ScenarioWeaponsResourceBlockBase(BinaryReader binaryReader)
        {
            names = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
            invalidName_ = Guerilla.ReadBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader);
            structureReferences = Guerilla.ReadBlockArray<ScenarioStructureBspReferenceBlock>(binaryReader);
            palette = Guerilla.ReadBlockArray<ScenarioWeaponPaletteBlock>(binaryReader);
            objects = Guerilla.ReadBlockArray<ScenarioWeaponBlock>(binaryReader);
            nextObjectIDSalt = binaryReader.ReadInt32();
            editorFolders = Guerilla.ReadBlockArray<GScenarioEditorFolderBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, names, nextAddress);
                Guerilla.WriteBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryWriter, invalidName_, nextAddress);
                Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, structureReferences, nextAddress);
                Guerilla.WriteBlockArray<ScenarioWeaponPaletteBlock>(binaryWriter, palette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioWeaponBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(nextObjectIDSalt);
                Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
