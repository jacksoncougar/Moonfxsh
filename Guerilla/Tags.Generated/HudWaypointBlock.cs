// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudWaypointBlock : HudWaypointBlockBase
    {
        public  HudWaypointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HudWaypointBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class HudWaypointBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal short onscreenSequenceIndex;
        internal short occludedSequenceIndex;
        internal short offscreenSequenceIndex;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HudWaypointBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            onscreenSequenceIndex = binaryReader.ReadInt16();
            occludedSequenceIndex = binaryReader.ReadInt16();
            offscreenSequenceIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  HudWaypointBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            onscreenSequenceIndex = binaryReader.ReadInt16();
            occludedSequenceIndex = binaryReader.ReadInt16();
            offscreenSequenceIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmap);
                binaryWriter.Write(shader);
                binaryWriter.Write(onscreenSequenceIndex);
                binaryWriter.Write(occludedSequenceIndex);
                binaryWriter.Write(offscreenSequenceIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
