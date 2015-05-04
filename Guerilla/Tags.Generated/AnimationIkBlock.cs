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
    public partial class AnimationIkBlock : AnimationIkBlockBase
    {
        public AnimationIkBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationIkBlockBase : GuerillaBlock
    {
        /// <summary>
        /// the marker name on the object being attached
        /// </summary>
        internal Moonfish.Tags.StringIdent marker;
        /// <summary>
        /// the marker name object (weapon, vehicle, etc.) the above marker is being attached to
        /// </summary>
        internal Moonfish.Tags.StringIdent attachToMarker;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public AnimationIkBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            marker = binaryReader.ReadStringID();
            attachToMarker = binaryReader.ReadStringID();
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
                binaryWriter.Write(marker);
                binaryWriter.Write(attachToMarker);
                return nextAddress;
            }
        }
    };
}
