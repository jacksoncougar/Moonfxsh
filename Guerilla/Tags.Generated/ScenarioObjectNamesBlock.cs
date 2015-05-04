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
    public partial class ScenarioObjectNamesBlock : ScenarioObjectNamesBlockBase
    {
        public ScenarioObjectNamesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class ScenarioObjectNamesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ShortBlockIndex1 eMPTYSTRING;
        internal Moonfish.Tags.ShortBlockIndex2 eMPTYSTRING0;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioObjectNamesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            eMPTYSTRING = binaryReader.ReadShortBlockIndex1();
            eMPTYSTRING0 = binaryReader.ReadShortBlockIndex2();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(eMPTYSTRING);
                binaryWriter.Write(eMPTYSTRING0);
                return nextAddress;
            }
        }
    };
}