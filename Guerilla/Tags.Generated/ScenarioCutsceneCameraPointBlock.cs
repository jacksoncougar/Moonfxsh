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
    public partial class ScenarioCutsceneCameraPointBlock : ScenarioCutsceneCameraPointBlockBase
    {
        public ScenarioCutsceneCameraPointBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class ScenarioCutsceneCameraPointBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Type type;
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 orientation;
        internal float unused;

        public override int SerializedSize
        {
            get { return 64; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioCutsceneCameraPointBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt16();
            type = (Type) binaryReader.ReadInt16();
            name = binaryReader.ReadString32();
            position = binaryReader.ReadVector3();
            orientation = binaryReader.ReadVector3();
            unused = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write((Int16) type);
                binaryWriter.Write(name);
                binaryWriter.Write(position);
                binaryWriter.Write(orientation);
                binaryWriter.Write(unused);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            EditAsRelative = 1,
        };

        internal enum Type : short
        {
            Normal = 0,
            IgnoreTargetOrientation = 1,
            Dolly = 2,
            IgnoreTargetUpdates = 3,
        };
    };
}