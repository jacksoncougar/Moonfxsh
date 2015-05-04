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
    public partial class RealVector4dBlock : RealVector4dBlockBase
    {
        public RealVector4dBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class RealVector4dBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 vector3;
        internal float w;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public RealVector4dBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            vector3 = binaryReader.ReadVector3();
            w = binaryReader.ReadSingle();
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
                binaryWriter.Write(vector3);
                binaryWriter.Write(w);
                return nextAddress;
            }
        }
    };
}
