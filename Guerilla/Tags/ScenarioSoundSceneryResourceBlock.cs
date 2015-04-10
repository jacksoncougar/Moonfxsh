using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*sce")]
    public  partial class ScenarioSoundSceneryResourceBlock : ScenarioSoundSceneryResourceBlockBase
    {
        public  ScenarioSoundSceneryResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class ScenarioSoundSceneryResourceBlockBase
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal ScenarioSoundSceneryPaletteBlock[] palette;
        internal ScenarioSoundSceneryBlock[] objects;
        internal int nextObjectIDSalt;
        internal GScenarioEditorFolderBlock[] editorFolders;
        internal  ScenarioSoundSceneryResourceBlockBase(BinaryReader binaryReader)
        {
            this.names = ReadScenarioObjectNamesBlockArray(binaryReader);
            this.invalidName_ = ReadDontUseMeScenarioEnvironmentObjectBlockArray(binaryReader);
            this.structureReferences = ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            this.palette = ReadScenarioSoundSceneryPaletteBlockArray(binaryReader);
            this.objects = ReadScenarioSoundSceneryBlockArray(binaryReader);
            this.nextObjectIDSalt = binaryReader.ReadInt32();
            this.editorFolders = ReadGScenarioEditorFolderBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ScenarioObjectNamesBlock[] ReadScenarioObjectNamesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioObjectNamesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioObjectNamesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioObjectNamesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DontUseMeScenarioEnvironmentObjectBlock[] ReadDontUseMeScenarioEnvironmentObjectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DontUseMeScenarioEnvironmentObjectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DontUseMeScenarioEnvironmentObjectBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DontUseMeScenarioEnvironmentObjectBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioStructureBspReferenceBlock[] ReadScenarioStructureBspReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioStructureBspReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioStructureBspReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioStructureBspReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSoundSceneryPaletteBlock[] ReadScenarioSoundSceneryPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSoundSceneryPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSoundSceneryPaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSoundSceneryPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSoundSceneryBlock[] ReadScenarioSoundSceneryBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSoundSceneryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSoundSceneryBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSoundSceneryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GScenarioEditorFolderBlock[] ReadGScenarioEditorFolderBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GScenarioEditorFolderBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GScenarioEditorFolderBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GScenarioEditorFolderBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
