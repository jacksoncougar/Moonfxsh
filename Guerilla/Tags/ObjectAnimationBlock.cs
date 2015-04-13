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
    [LayoutAttribute(Size = 20)]
    public class ObjectAnimationBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationIndexStructBlock animation;
        internal byte[] invalidName_;
        internal FunctionControls functionControls;
        internal Moonfish.Tags.StringID function;
        internal byte[] invalidName_0;
        internal  ObjectAnimationBlockBase(BinaryReader binaryReader)
        {
            this.label = binaryReader.ReadStringID();
            this.animation = new AnimationIndexStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.functionControls = (FunctionControls)binaryReader.ReadInt16();
            this.function = binaryReader.ReadStringID();
            this.invalidName_0 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal enum FunctionControls : short
        
        {
            Frame = 0,
            Scale = 1,
        };
    };
}
