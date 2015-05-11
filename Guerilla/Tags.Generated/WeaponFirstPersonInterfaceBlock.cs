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
    public partial class WeaponFirstPersonInterfaceBlock : WeaponFirstPersonInterfaceBlockBase
    {
        public WeaponFirstPersonInterfaceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class WeaponFirstPersonInterfaceBlockBase : GuerillaBlock
    {
        [TagReference("mode")] internal Moonfish.Tags.TagReference firstPersonModel;
        [TagReference("jmad")] internal Moonfish.Tags.TagReference firstPersonAnimations;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public WeaponFirstPersonInterfaceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            firstPersonModel = binaryReader.ReadTagReference();
            firstPersonAnimations = binaryReader.ReadTagReference();
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
                binaryWriter.Write(firstPersonModel);
                binaryWriter.Write(firstPersonAnimations);
                return nextAddress;
            }
        }
    };
}