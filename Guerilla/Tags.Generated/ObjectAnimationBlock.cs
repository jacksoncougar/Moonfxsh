// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ObjectAnimationBlock : ObjectAnimationBlockBase
    {
        public  ObjectAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ObjectAnimationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ObjectAnimationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal AnimationIndexStructBlock animation;
        internal byte[] invalidName_;
        internal FunctionControls functionControls;
        internal Moonfish.Tags.StringIdent function;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ObjectAnimationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            label = binaryReader.ReadStringID();
            animation = new AnimationIndexStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            functionControls = (FunctionControls)binaryReader.ReadInt16();
            function = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(4);
        }
        public  ObjectAnimationBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            animation = new AnimationIndexStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            functionControls = (FunctionControls)binaryReader.ReadInt16();
            function = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(4);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
