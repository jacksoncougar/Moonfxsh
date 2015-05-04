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
    public partial class SkyLightBlock : SkyLightBlockBase
    {
        public SkyLightBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class SkyLightBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 directionVector;
        internal OpenTK.Vector2 direction;
        [TagReference("lens")] internal Moonfish.Tags.TagReference lensFlare;
        internal SkyLightFogBlock[] fog;
        internal SkyLightFogBlock[] fogOpposite;
        internal SkyRadiosityLightBlock[] radiosity;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SkyLightBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            directionVector = binaryReader.ReadVector3();
            direction = binaryReader.ReadVector2();
            lensFlare = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<SkyLightFogBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SkyLightFogBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SkyRadiosityLightBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            fog = ReadBlockArrayData<SkyLightFogBlock>(binaryReader, blamPointers.Dequeue());
            fogOpposite = ReadBlockArrayData<SkyLightFogBlock>(binaryReader, blamPointers.Dequeue());
            radiosity = ReadBlockArrayData<SkyRadiosityLightBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(directionVector);
                binaryWriter.Write(direction);
                binaryWriter.Write(lensFlare);
                nextAddress = Guerilla.WriteBlockArray<SkyLightFogBlock>(binaryWriter, fog, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyLightFogBlock>(binaryWriter, fogOpposite, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyRadiosityLightBlock>(binaryWriter, radiosity, nextAddress);
                return nextAddress;
            }
        }
    };
}