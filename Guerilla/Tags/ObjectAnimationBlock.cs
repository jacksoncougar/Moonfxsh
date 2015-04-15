// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectAnimationBlock : ObjectAnimationBlockBase
    {
        public  ObjectAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ObjectAnimationBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationIndexStructBlock animation;
        internal byte[] invalidName_;
        internal FunctionControls functionControls;
        internal Moonfish.Tags.StringID function;
        internal byte[] invalidName_0;
        internal  ObjectAnimationBlockBase(BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            animation = new AnimationIndexStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            functionControls = (FunctionControls)binaryReader.ReadInt16();
            function = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(4);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                animation.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)functionControls);
                binaryWriter.Write(function);
                binaryWriter.Write(invalidName_0, 0, 4);
                return nextAddress;
            }
        }
        internal enum FunctionControls : short
        {
            Frame = 0,
            Scale = 1,
        };
    };
}
