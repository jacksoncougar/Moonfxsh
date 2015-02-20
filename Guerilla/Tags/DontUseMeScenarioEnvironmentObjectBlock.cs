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
        public  DontUseMeScenarioEnvironmentObjectBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DontUseMeScenarioEnvironmentObjectBlockBase(BinaryReader binaryReader)
        {
            this.bSP = binaryReader.ReadShortBlockIndex1();
            this.eMPTYSTRING = binaryReader.ReadInt16();
            this.uniqueID = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.objectDefinitionTag = binaryReader.ReadTagClass();
            this._object = binaryReader.ReadInt32();
            this.invalidName_0 = binaryReader.ReadBytes(44);
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
    };
}
