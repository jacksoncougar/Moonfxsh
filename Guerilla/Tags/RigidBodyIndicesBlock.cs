// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RigidBodyIndicesBlock : RigidBodyIndicesBlockBase
    {
        public  RigidBodyIndicesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class RigidBodyIndicesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 rigidBody;
        internal  RigidBodyIndicesBlockBase(BinaryReader binaryReader)
        {
            rigidBody = binaryReader.ReadShortBlockIndex1();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(rigidBody);
                return nextAddress;
            }
        }
    };
}
