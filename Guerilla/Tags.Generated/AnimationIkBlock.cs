// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationIkBlock : AnimationIkBlockBase
    {
        public  AnimationIkBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationIkBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationIkBlockBase : GuerillaBlock
    {
        /// <summary>
        /// the marker name on the object being attached
        /// </summary>
        internal Moonfish.Tags.StringIdent marker;
        /// <summary>
        /// the marker name object (weapon, vehicle, etc.) the above marker is being attached to
        /// </summary>
        internal Moonfish.Tags.StringIdent attachToMarker;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationIkBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            marker = binaryReader.ReadStringID();
            attachToMarker = binaryReader.ReadStringID();
        }
        public  AnimationIkBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            marker = binaryReader.ReadStringID();
            attachToMarker = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(marker);
                binaryWriter.Write(attachToMarker);
                return nextAddress;
            }
        }
    };
}
