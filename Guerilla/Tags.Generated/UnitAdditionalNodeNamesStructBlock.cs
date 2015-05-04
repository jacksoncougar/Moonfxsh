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
    public partial class UnitAdditionalNodeNamesStructBlock : UnitAdditionalNodeNamesStructBlockBase
    {
        public UnitAdditionalNodeNamesStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class UnitAdditionalNodeNamesStructBlockBase : GuerillaBlock
    {
        /// <summary>
        /// if found, use this gun marker
        /// </summary>
        internal Moonfish.Tags.StringIdent preferredGunNode;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public UnitAdditionalNodeNamesStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            preferredGunNode = binaryReader.ReadStringID();
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
                binaryWriter.Write(preferredGunNode);
                return nextAddress;
            }
        }
    };
}
