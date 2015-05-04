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
    public partial class ScenarioLightFixtureStructBlock : ScenarioLightFixtureStructBlockBase
    {
        public ScenarioLightFixtureStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioLightFixtureStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 color;
        internal float intensity;
        internal float falloffAngleDegrees;
        internal float cutoffAngleDegrees;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioLightFixtureStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            color = binaryReader.ReadColorR8G8B8();
            intensity = binaryReader.ReadSingle();
            falloffAngleDegrees = binaryReader.ReadSingle();
            cutoffAngleDegrees = binaryReader.ReadSingle();
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
                binaryWriter.Write(color);
                binaryWriter.Write(intensity);
                binaryWriter.Write(falloffAngleDegrees);
                binaryWriter.Write(cutoffAngleDegrees);
                return nextAddress;
            }
        }
    };
}