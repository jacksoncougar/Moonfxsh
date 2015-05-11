// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SecondaryLightStructBlock : SecondaryLightStructBlockBase
    {
        public SecondaryLightStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class SecondaryLightStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 minLightmapColor;
        internal Moonfish.Tags.ColourR8G8B8 maxLightmapColor;
        internal Moonfish.Tags.ColourR8G8B8 minDiffuseSample;
        internal Moonfish.Tags.ColourR8G8B8 maxDiffuseSample;

        /// <summary>
        /// degrees
        /// </summary>
        internal float zAxisRotation;

        internal MappingFunctionBlock function;

        public override int SerializedSize
        {
            get { return 60; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SecondaryLightStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            minLightmapColor = binaryReader.ReadColorR8G8B8();
            maxLightmapColor = binaryReader.ReadColorR8G8B8();
            minDiffuseSample = binaryReader.ReadColorR8G8B8();
            maxDiffuseSample = binaryReader.ReadColorR8G8B8();
            zAxisRotation = binaryReader.ReadSingle();
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
                binaryWriter.Write(minDiffuseSample);
                binaryWriter.Write(maxDiffuseSample);
                binaryWriter.Write(zAxisRotation);
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}