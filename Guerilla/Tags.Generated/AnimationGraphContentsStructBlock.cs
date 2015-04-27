// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationGraphContentsStructBlock : AnimationGraphContentsStructBlockBase
    {
        public  AnimationGraphContentsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationGraphContentsStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class AnimationGraphContentsStructBlockBase : GuerillaBlock
    {
        internal AnimationModeBlock[] modesAABBCC;
        internal VehicleSuspensionBlock[] vehicleSuspensionCCAABB;
        internal ObjectAnimationBlock[] objectOverlaysCCAABB;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationGraphContentsStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            modesAABBCC = Guerilla.ReadBlockArray<AnimationModeBlock>(binaryReader);
            vehicleSuspensionCCAABB = Guerilla.ReadBlockArray<VehicleSuspensionBlock>(binaryReader);
            objectOverlaysCCAABB = Guerilla.ReadBlockArray<ObjectAnimationBlock>(binaryReader);
        }
        public  AnimationGraphContentsStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<AnimationModeBlock>(binaryWriter, modesAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VehicleSuspensionBlock>(binaryWriter, vehicleSuspensionCCAABB, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ObjectAnimationBlock>(binaryWriter, objectOverlaysCCAABB, nextAddress);
                return nextAddress;
            }
        }
    };
}
