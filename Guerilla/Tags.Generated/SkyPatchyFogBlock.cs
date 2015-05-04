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
    public partial class SkyPatchyFogBlock : SkyPatchyFogBlockBase
    {
        public SkyPatchyFogBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class SkyPatchyFogBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 color;
        internal byte[] invalidName_;
        internal OpenTK.Vector2 density01;
        internal Moonfish.Model.Range distanceWorldUnits;
        internal byte[] invalidName_0;
        [TagReference("fpch")]
        internal Moonfish.Tags.TagReference patchyFog;
        public override int SerializedSize { get { return 80; } }
        public override int Alignment { get { return 4; } }
        public SkyPatchyFogBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            color = binaryReader.ReadColorR8G8B8();
            invalidName_ = binaryReader.ReadBytes(12);
            density01 = binaryReader.ReadVector2();
            distanceWorldUnits = binaryReader.ReadRange();
            invalidName_0 = binaryReader.ReadBytes(32);
            patchyFog = binaryReader.ReadTagReference();
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
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(density01);
                binaryWriter.Write(distanceWorldUnits);
                binaryWriter.Write(invalidName_0, 0, 32);
                binaryWriter.Write(patchyFog);
                return nextAddress;
            }
        }
    };
}
