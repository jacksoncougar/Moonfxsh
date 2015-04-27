// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationEntryBlock : AnimationEntryBlockBase
    {
        public  AnimationEntryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationEntryBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationEntryBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationIndexStructBlock animation;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationEntryBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            label = binaryReader.ReadStringID();
            animation = new AnimationIndexStructBlock(binaryReader);
        }
        public  AnimationEntryBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                animation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
