// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class DontUseMeScenarioEnvironmentObjectBlock : DontUseMeScenarioEnvironmentObjectBlockBase
    {
        public DontUseMeScenarioEnvironmentObjectBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class DontUseMeScenarioEnvironmentObjectBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 bSP;
        internal short eMPTYSTRING;
        internal int uniqueID;
        internal byte[] invalidName_;
        internal Moonfish.Tags.TagClass objectDefinitionTag;
        internal int _object;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 64; } }
        public override int Alignment { get { return 4; } }
        public DontUseMeScenarioEnvironmentObjectBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bSP = binaryReader.ReadShortBlockIndex1();
            eMPTYSTRING = binaryReader.ReadInt16();
            uniqueID = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(4);
            objectDefinitionTag = binaryReader.ReadTagClass();
            _object = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadBytes(44);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSP);
                binaryWriter.Write(eMPTYSTRING);
                binaryWriter.Write(uniqueID);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(objectDefinitionTag);
                binaryWriter.Write(_object);
                binaryWriter.Write(invalidName_0, 0, 44);
                return nextAddress;
            }
        }
    };
}
