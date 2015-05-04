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
    public partial class LightmapBucketRawVertexBlock : LightmapBucketRawVertexBlockBase
    {
        public LightmapBucketRawVertexBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class LightmapBucketRawVertexBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 primaryLightmapColor;
        internal OpenTK.Vector3 primaryLightmapIncidentDirection;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LightmapBucketRawVertexBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            primaryLightmapColor = binaryReader.ReadColorR8G8B8();
            primaryLightmapIncidentDirection = binaryReader.ReadVector3();
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
                binaryWriter.Write(primaryLightmapColor);
                binaryWriter.Write(primaryLightmapIncidentDirection);
                return nextAddress;
            }
        }
    };
}