// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleModelVerticesBlock : ParticleModelVerticesBlockBase
    {
        public  ParticleModelVerticesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ParticleModelVerticesBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 normal;
        internal OpenTK.Vector3 tangent;
        internal OpenTK.Vector3 binormal;
        internal OpenTK.Vector2 texcoord;
        internal  ParticleModelVerticesBlockBase(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            normal = binaryReader.ReadVector3();
            tangent = binaryReader.ReadVector3();
            binormal = binaryReader.ReadVector3();
            texcoord = binaryReader.ReadVector2();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
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
