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
        public  AnimationGraphContentsStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class AnimationGraphContentsStructBlockBase
    {
        internal AnimationModeBlock[] modesAABBCC;
        internal VehicleSuspensionBlock[] vehicleSuspensionCCAABB;
        internal ObjectAnimationBlock[] objectOverlaysCCAABB;
        internal  AnimationGraphContentsStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadAnimationModeBlockArray(binaryReader);
            ReadVehicleSuspensionBlockArray(binaryReader);
            ReadObjectAnimationBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual AnimationModeBlock[] ReadAnimationModeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationModeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationModeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationModeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VehicleSuspensionBlock[] ReadVehicleSuspensionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VehicleSuspensionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VehicleSuspensionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VehicleSuspensionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ObjectAnimationBlock[] ReadObjectAnimationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationModeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVehicleSuspensionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteAnimationModeBlockArray(binaryWriter);
                WriteVehicleSuspensionBlockArray(binaryWriter);
                WriteObjectAnimationBlockArray(binaryWriter);
            }
        }
    };
}
