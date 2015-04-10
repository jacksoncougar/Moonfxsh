// ReSharper disable All
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
        public  ScenarioSoundSceneryResourceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioSoundSceneryResourceBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadScenarioObjectNamesBlockArray(binaryReader);
            ReadDontUseMeScenarioEnvironmentObjectBlockArray(binaryReader);
            ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            ReadScenarioSoundSceneryPaletteBlockArray(binaryReader);
            ReadScenarioSoundSceneryBlockArray(binaryReader);
            nextObjectIDSalt = binaryReader.ReadInt32();
            ReadGScenarioEditorFolderBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioObjectNamesBlock[] ReadScenarioObjectNamesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual DontUseMeScenarioEnvironmentObjectBlock[] ReadDontUseMeScenarioEnvironmentObjectBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioStructureBspReferenceBlock[] ReadScenarioStructureBspReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioSoundSceneryPaletteBlock[] ReadScenarioSoundSceneryPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSoundSceneryPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSoundSceneryPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSoundSceneryPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSoundSceneryBlock[] ReadScenarioSoundSceneryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSoundSceneryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSoundSceneryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSoundSceneryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GScenarioEditorFolderBlock[] ReadGScenarioEditorFolderBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioObjectNamesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDontUseMeScenarioEnvironmentObjectBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioStructureBspReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSoundSceneryPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSoundSceneryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGScenarioEditorFolderBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteScenarioObjectNamesBlockArray(binaryWriter);
                WriteDontUseMeScenarioEnvironmentObjectBlockArray(binaryWriter);
                WriteScenarioStructureBspReferenceBlockArray(binaryWriter);
                WriteScenarioSoundSceneryPaletteBlockArray(binaryWriter);
                WriteScenarioSoundSceneryBlockArray(binaryWriter);
                binaryWriter.Write(nextObjectIDSalt);
                WriteGScenarioEditorFolderBlockArray(binaryWriter);
            }
        }
    };
}
