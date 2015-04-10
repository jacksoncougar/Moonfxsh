// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DontUseMeScenarioEnvironmentObjectBlock : DontUseMeScenarioEnvironmentObjectBlockBase
    {
        public  DontUseMeScenarioEnvironmentObjectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class DontUseMeScenarioEnvironmentObjectBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 bSP;
        internal short eMPTYSTRING;
        internal int uniqueID;
        internal byte[] invalidName_;
        internal Moonfish.Tags.TagClass objectDefinitionTag;
        internal int _object;
        internal byte[] invalidName_0;
        internal  DontUseMeScenarioEnvironmentObjectBlockBase(System.IO.BinaryReader binaryReader)
        {
            bSP = binaryReader.ReadShortBlockIndex1();
            eMPTYSTRING = binaryReader.ReadInt16();
            uniqueID = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(4);
            objectDefinitionTag = binaryReader.ReadTagClass();
            _object = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadBytes(44);
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSP);
                binaryWriter.Write(eMPTYSTRING);
                binaryWriter.Write(uniqueID);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(objectDefinitionTag);
                binaryWriter.Write(_object);
                binaryWriter.Write(invalidName_0, 0, 44);
            }
        }
    };
}
