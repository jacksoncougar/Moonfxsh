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
    public partial class PrimaryLightStructBlock : PrimaryLightStructBlockBase
    {
        public PrimaryLightStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class PrimaryLightStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 minLightmapColor;
        internal Moonfish.Tags.ColourR8G8B8 maxLightmapColor;

        /// <summary>
        /// degrees from up the direct light cannot be
        /// </summary>
        internal float exclusionAngleFromUp;

        internal MappingFunctionBlock function;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PrimaryLightStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            minLightmapColor = binaryReader.ReadColorR8G8B8();
            maxLightmapColor = binaryReader.ReadColorR8G8B8();
            exclusionAngleFromUp = binaryReader.ReadSingle();
            function = new MappingFunctionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(function.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            function.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(minLightmapColor);
                binaryWriter.Write(maxLightmapColor);
                binaryWriter.Write(exclusionAngleFromUp);
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}