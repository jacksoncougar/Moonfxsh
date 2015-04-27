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
        public static readonly TagClass Cen = (TagClass)"*cen";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*cen")]
    public partial class ScenarioSceneryResourceBlock : ScenarioSceneryResourceBlockBase
    {
        public  ScenarioSceneryResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioSceneryResourceBlock(): base()
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
        
        public override int SerializedSize{get { return 72; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioSceneryResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            names = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
            invalidName_ = Guerilla.ReadBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader);
            structureReferences = Guerilla.ReadBlockArray<ScenarioStructureBspReferenceBlock>(binaryReader);
            palette = Guerilla.ReadBlockArray<ScenarioSceneryPaletteBlock>(binaryReader);
            objects = Guerilla.ReadBlockArray<ScenarioSceneryBlock>(binaryReader);
            nextSceneryObjectIDSalt = binaryReader.ReadInt32();
            palette0 = Guerilla.ReadBlockArray<ScenarioCratePaletteBlock>(binaryReader);
            objects0 = Guerilla.ReadBlockArray<ScenarioCrateBlock>(binaryReader);
            nextBlockObjectIDSalt = binaryReader.ReadInt32();
            editorFolders = Guerilla.ReadBlockArray<GScenarioEditorFolderBlock>(binaryReader);
        }
        public  ScenarioSceneryResourceBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            names = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
            invalidName_ = Guerilla.ReadBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader);
            structureReferences = Guerilla.ReadBlockArray<ScenarioStructureBspReferenceBlock>(binaryReader);
            palette = Guerilla.ReadBlockArray<ScenarioSceneryPaletteBlock>(binaryReader);
            objects = Guerilla.ReadBlockArray<ScenarioSceneryBlock>(binaryReader);
            nextSceneryObjectIDSalt = binaryReader.ReadInt32();
            palette0 = Guerilla.ReadBlockArray<ScenarioCratePaletteBlock>(binaryReader);
            objects0 = Guerilla.ReadBlockArray<ScenarioCrateBlock>(binaryReader);
            nextBlockObjectIDSalt = binaryReader.ReadInt32();
            editorFolders = Guerilla.ReadBlockArray<GScenarioEditorFolderBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, names, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryWriter, invalidName_, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, structureReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSceneryPaletteBlock>(binaryWriter, palette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSceneryBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(nextSceneryObjectIDSalt);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCratePaletteBlock>(binaryWriter, palette0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCrateBlock>(binaryWriter, objects0, nextAddress);
                binaryWriter.Write(nextBlockObjectIDSalt);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders, nextAddress);
                return nextAddress;
            }
        }
    };
}
