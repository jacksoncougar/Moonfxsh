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
        public static readonly TagClass Sce = (TagClass)"*sce";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*sce")]
    public partial class ScenarioSoundSceneryResourceBlock : ScenarioSoundSceneryResourceBlockBase
    {
        public  ScenarioSoundSceneryResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioSoundSceneryResourceBlock(): base()
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
        
        public override int SerializedSize{get { return 52; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioSoundSceneryResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            names = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
            invalidName_ = Guerilla.ReadBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader);
            structureReferences = Guerilla.ReadBlockArray<ScenarioStructureBspReferenceBlock>(binaryReader);
            palette = Guerilla.ReadBlockArray<ScenarioSoundSceneryPaletteBlock>(binaryReader);
            objects = Guerilla.ReadBlockArray<ScenarioSoundSceneryBlock>(binaryReader);
            nextObjectIDSalt = binaryReader.ReadInt32();
            editorFolders = Guerilla.ReadBlockArray<GScenarioEditorFolderBlock>(binaryReader);
        }
        public  ScenarioSoundSceneryResourceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, names, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryWriter, invalidName_, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, structureReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSoundSceneryPaletteBlock>(binaryWriter, palette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSoundSceneryBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(nextObjectIDSalt);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders, nextAddress);
                return nextAddress;
            }
        }
    };
}
