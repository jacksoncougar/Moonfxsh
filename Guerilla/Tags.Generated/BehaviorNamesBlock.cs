// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BehaviorNamesBlock : BehaviorNamesBlockBase
    {
        public  BehaviorNamesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class BehaviorNamesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 behaviorName;
        
        public override int SerializedSize{get { return 32; }}
        
        internal  BehaviorNamesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            behaviorName = binaryReader.ReadString32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(behaviorName);
                return nextAddress;
            }
        }
    };
}
