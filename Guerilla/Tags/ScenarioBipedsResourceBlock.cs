using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("*ipd")]
    public  partial class ScenarioBipedsResourceBlock : ScenarioBipedsResourceBlockBase
    {
        public  ScenarioBipedsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class ScenarioBipedsResourceBlockBase
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal ScenarioBipedPaletteBlock[] palette;
        internal ScenarioBipedBlock[] objects;
        internal int nextObjectIDSalt;
        internal GScenarioEditorFolderBlock[] editorFolders;
        internal  ScenarioBipedsResourceBlockBase(BinaryReader binaryReader)
        {
            this.names = ReadScenarioObjectNamesBlockArray(binaryReader);
            this.invalidName_ = ReadDontUseMeScenarioEnvironmentObjectBlockArray(binaryReader);
            this.structureReferences = ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            this.palette = ReadScenarioBipedPaletteBlockArray(binaryReader);
            this.objects = ReadScenarioBipedBlockArray(binaryReader);
            this.nextObjectIDSalt = binaryReader.ReadInt32();
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
        internal  virtual ScenarioBipedPaletteBlock[] ReadScenarioBipedPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioBipedPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioBipedPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioBipedPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioBipedBlock[] ReadScenarioBipedBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioBipedBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioBipedBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioBipedBlock(binaryReader);
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
