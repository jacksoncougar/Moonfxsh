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
    public partial class InertialMatrixBlock : InertialMatrixBlockBase
    {
        public InertialMatrixBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class InertialMatrixBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 yyZzXyZx;
        internal OpenTK.Vector3 xyZzXxYz;
        internal OpenTK.Vector3 zxYzXxYy;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public InertialMatrixBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            yyZzXyZx = binaryReader.ReadVector3();
            xyZzXxYz = binaryReader.ReadVector3();
            zxYzXxYy = binaryReader.ReadVector3();
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
                binaryWriter.Write(yyZzXyZx);
                binaryWriter.Write(xyZzXxYz);
                binaryWriter.Write(zxYzXxYy);
                return nextAddress;
            }
        }
    };
}