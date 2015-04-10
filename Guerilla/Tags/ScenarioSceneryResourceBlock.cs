using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*cen")]
    public  partial class ScenarioSceneryResourceBlock : ScenarioSceneryResourceBlockBase
    {
        public  ScenarioSceneryResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class ScenarioSceneryResourceBlockBase
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
        internal  ScenarioSceneryResourceBlockBase(BinaryReader binaryReader)
        {
            this.names = ReadScenarioObjectNamesBlockArray(binaryReader);
            this.invalidName_ = ReadDontUseMeScenarioEnvironmentObjectBlockArray(binaryReader);
            this.structureReferences = ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            this.palette = ReadScenarioSceneryPaletteBlockArray(binaryReader);
            this.objects = ReadScenarioSceneryBlockArray(binaryReader);
            this.nextSceneryObjectIDSalt = binaryReader.ReadInt32();
            this.palette0 = ReadScenarioCratePaletteBlockArray(binaryReader);
            this.objects0 = ReadScenarioCrateBlockArray(binaryReader);
            this.nextBlockObjectIDSalt = binaryReader.ReadInt32();
            this.editorFolders = ReadGScenarioEditorFolderBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual ScenarioObjectNamesBlock[] ReadScenarioObjectNamesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioObjectNamesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioObjectNamesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
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
            var array = new DontUseMeScenarioEnvironmentObjectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
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
            var array = new ScenarioStructureBspReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioStructureBspReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSceneryPaletteBlock[] ReadScenarioSceneryPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSceneryPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSceneryPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSceneryPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSceneryBlock[] ReadScenarioSceneryBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSceneryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSceneryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSceneryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCratePaletteBlock[] ReadScenarioCratePaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCratePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCratePaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCratePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCrateBlock[] ReadScenarioCrateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCrateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCrateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCrateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GScenarioEditorFolderBlock[] ReadGScenarioEditorFolderBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GScenarioEditorFolderBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GScenarioEditorFolderBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GScenarioEditorFolderBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
