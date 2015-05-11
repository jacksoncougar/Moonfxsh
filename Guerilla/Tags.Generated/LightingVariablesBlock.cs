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
    public partial class LightingVariablesBlock : LightingVariablesBlockBase
    {
        public LightingVariablesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 144, Alignment = 4)]
    public class LightingVariablesBlockBase : GuerillaBlock
    {
        internal ObjectAffected objectAffected;
        internal float lightmapBrightnessOffset;
        internal PrimaryLightStructBlock primaryLight;
        internal SecondaryLightStructBlock secondaryLight;
        internal AmbientLightStructBlock ambientLight;
        internal LightmapShadowsStructBlock lightmapShadows;

        public override int SerializedSize
        {
            get { return 144; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LightingVariablesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            objectAffected = (ObjectAffected) binaryReader.ReadInt32();
            lightmapBrightnessOffset = binaryReader.ReadSingle();
            primaryLight = new PrimaryLightStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(primaryLight.ReadFields(binaryReader)));
            secondaryLight = new SecondaryLightStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(secondaryLight.ReadFields(binaryReader)));
            ambientLight = new AmbientLightStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(ambientLight.ReadFields(binaryReader)));
            lightmapShadows = new LightmapShadowsStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(lightmapShadows.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            primaryLight.ReadPointers(binaryReader, blamPointers);
            secondaryLight.ReadPointers(binaryReader, blamPointers);
            ambientLight.ReadPointers(binaryReader, blamPointers);
            lightmapShadows.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) objectAffected);
                binaryWriter.Write(lightmapBrightnessOffset);
                primaryLight.Write(binaryWriter);
                secondaryLight.Write(binaryWriter);
                ambientLight.Write(binaryWriter);
                lightmapShadows.Write(binaryWriter);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum ObjectAffected : int
        {
            All = 1,
            Biped = 2,
            Vehicle = 4,
            Weapon = 8,
            Equipment = 16,
            Garbage = 32,
            Projectile = 64,
            Scenery = 128,
            Machine = 256,
            Control = 512,
            LightFixture = 1024,
            SoundScenery = 2048,
            Crate = 4096,
            Creature = 8192,
        };
    };
}