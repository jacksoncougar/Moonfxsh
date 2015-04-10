// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectChangeColorFunction : ObjectChangeColorFunctionBase
    {
        public  ObjectChangeColorFunction(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class ObjectChangeColorFunctionBase
    {
        internal byte[] invalidName_;
        internal ScaleFlags scaleFlags;
        internal Moonfish.Tags.ColorR8G8B8 colorLowerBound;
        internal Moonfish.Tags.ColorR8G8B8 colorUpperBound;
        internal Moonfish.Tags.StringID darkenBy;
        internal Moonfish.Tags.StringID scaleBy;
        internal  ObjectChangeColorFunctionBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            scaleFlags = (ScaleFlags)binaryReader.ReadInt32();
            colorLowerBound = binaryReader.ReadColorR8G8B8();
            colorUpperBound = binaryReader.ReadColorR8G8B8();
            darkenBy = binaryReader.ReadStringID();
            scaleBy = binaryReader.ReadStringID();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Int32)scaleFlags);
                binaryWriter.Write(colorLowerBound);
                binaryWriter.Write(colorUpperBound);
                binaryWriter.Write(darkenBy);
                binaryWriter.Write(scaleBy);
            }
        }
        [FlagsAttribute]
        internal enum ScaleFlags : int
        
        {
            BlendInHsvBlendsColorsInHsvRatherThanRgbSpace = 1,
            MoreColorsBlendsColorsThroughMoreHuesGoesTheLongWayAroundTheColorWheel = 2,
        };
    };
}
