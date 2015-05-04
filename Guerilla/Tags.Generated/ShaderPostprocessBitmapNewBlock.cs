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
    public partial class ShaderPostprocessBitmapNewBlock : ShaderPostprocessBitmapNewBlockBase
    {
        public ShaderPostprocessBitmapNewBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderPostprocessBitmapNewBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.TagIdent bitmapGroup;
        internal int bitmapIndex;
        internal float logBitmapDimension;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public ShaderPostprocessBitmapNewBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmapGroup = binaryReader.ReadTagIdent();
            bitmapIndex = binaryReader.ReadInt32();
            logBitmapDimension = binaryReader.ReadSingle();
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
                binaryWriter.Write(bitmapGroup);
                binaryWriter.Write(bitmapIndex);
                binaryWriter.Write(logBitmapDimension);
                return nextAddress;
            }
        }
    };
}
