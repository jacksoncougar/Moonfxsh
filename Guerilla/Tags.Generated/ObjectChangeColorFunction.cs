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
    public partial class ObjectChangeColorFunction : ObjectChangeColorFunctionBase
    {
        public ObjectChangeColorFunction() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class ObjectChangeColorFunctionBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal ScaleFlags scaleFlags;
        internal Moonfish.Tags.ColourR8G8B8 colorLowerBound;
        internal Moonfish.Tags.ColourR8G8B8 colorUpperBound;
        internal Moonfish.Tags.StringIdent darkenBy;
        internal Moonfish.Tags.StringIdent scaleBy;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public ObjectChangeColorFunctionBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            scaleFlags = (ScaleFlags)binaryReader.ReadInt32();
            colorLowerBound = binaryReader.ReadColorR8G8B8();
            colorUpperBound = binaryReader.ReadColorR8G8B8();
            darkenBy = binaryReader.ReadStringID();
            scaleBy = binaryReader.ReadStringID();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Int32)scaleFlags);
                binaryWriter.Write(colorLowerBound);
                binaryWriter.Write(colorUpperBound);
                binaryWriter.Write(darkenBy);
                binaryWriter.Write(scaleBy);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum ScaleFlags : int
        {
            BlendInHsvBlendsColorsInHsvRatherThanRgbSpace = 1,
            MoreColorsBlendsColorsThroughMoreHuesGoesTheLongWayAroundTheColorWheel = 2,
        };
    };
}
