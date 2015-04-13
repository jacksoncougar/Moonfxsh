// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationGraphContentsStructBlock : AnimationGraphContentsStructBlockBase
    {
        public  AnimationGraphContentsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class AnimationGraphContentsStructBlockBase  : IGuerilla
    {
        internal AnimationModeBlock[] modesAABBCC;
        internal VehicleSuspensionBlock[] vehicleSuspensionCCAABB;
        internal ObjectAnimationBlock[] objectOverlaysCCAABB;
        internal  AnimationGraphContentsStructBlockBase(BinaryReader binaryReader)
        {
            modesAABBCC = Guerilla.ReadBlockArray<AnimationModeBlock>(binaryReader);
            vehicleSuspensionCCAABB = Guerilla.ReadBlockArray<VehicleSuspensionBlock>(binaryReader);
            objectOverlaysCCAABB = Guerilla.ReadBlockArray<ObjectAnimationBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<AnimationModeBlock>(binaryWriter, modesAABBCC, nextAddress);
                Guerilla.WriteBlockArray<VehicleSuspensionBlock>(binaryWriter, vehicleSuspensionCCAABB, nextAddress);
                Guerilla.WriteBlockArray<ObjectAnimationBlock>(binaryWriter, objectOverlaysCCAABB, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
