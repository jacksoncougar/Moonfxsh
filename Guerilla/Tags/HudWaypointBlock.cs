using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudWaypointBlock : HudWaypointBlockBase
    {
        public  HudWaypointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class HudWaypointBlockBase
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal short onscreenSequenceIndex;
        internal short occludedSequenceIndex;
        internal short offscreenSequenceIndex;
        internal byte[] invalidName_;
        internal  HudWaypointBlockBase(BinaryReader binaryReader)
        {
            this.bitmap = binaryReader.ReadTagReference();
            this.shader = binaryReader.ReadTagReference();
            this.onscreenSequenceIndex = binaryReader.ReadInt16();
            this.occludedSequenceIndex = binaryReader.ReadInt16();
            this.offscreenSequenceIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
