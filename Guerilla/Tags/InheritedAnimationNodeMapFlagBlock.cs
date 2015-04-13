// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class InheritedAnimationNodeMapFlagBlock : InheritedAnimationNodeMapFlagBlockBase
    {
        public  InheritedAnimationNodeMapFlagBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class InheritedAnimationNodeMapFlagBlockBase  : IGuerilla
    {
        internal int localNodeFlags;
        internal  InheritedAnimationNodeMapFlagBlockBase(BinaryReader binaryReader)
        {
            localNodeFlags = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(localNodeFlags);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
