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
    public partial class ParticleModelVerticesBlock : ParticleModelVerticesBlockBase
    {
        public ParticleModelVerticesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ParticleModelVerticesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 normal;
        internal OpenTK.Vector3 tangent;
        internal OpenTK.Vector3 binormal;
        internal OpenTK.Vector2 texcoord;

        public override int SerializedSize
        {
            get { return 56; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ParticleModelVerticesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            normal = binaryReader.ReadVector3();
            tangent = binaryReader.ReadVector3();
            binormal = binaryReader.ReadVector3();
            texcoord = binaryReader.ReadVector2();
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
                binaryWriter.Write(position);
                binaryWriter.Write(normal);
                binaryWriter.Write(tangent);
                binaryWriter.Write(binormal);
                binaryWriter.Write(texcoord);
                return nextAddress;
            }
        }
    };
}