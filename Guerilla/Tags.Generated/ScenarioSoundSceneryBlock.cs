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
    public partial class ScenarioSoundSceneryBlock : ScenarioSoundSceneryBlockBase
    {
        public ScenarioSoundSceneryBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class ScenarioSoundSceneryBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal SoundSceneryDatumStructBlock soundScenery;

        public override int SerializedSize
        {
            get { return 80; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioSoundSceneryBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(objectData.ReadFields(binaryReader)));
            soundScenery = new SoundSceneryDatumStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(soundScenery.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            objectData.ReadPointers(binaryReader, blamPointers);
            soundScenery.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                soundScenery.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}