// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationIkBlock : AnimationIkBlockBase
    {
        public  AnimationIkBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationIkBlockBase  : IGuerilla
    {
        /// <summary>
        /// the marker name on the object being attached
        /// </summary>
        internal Moonfish.Tags.StringID marker;
        /// <summary>
        /// the marker name object (weapon, vehicle, etc.) the above marker is being attached to
        /// </summary>
        internal Moonfish.Tags.StringID attachToMarker;
        internal  AnimationIkBlockBase(BinaryReader binaryReader)
        {
            marker = binaryReader.ReadStringID();
            attachToMarker = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
