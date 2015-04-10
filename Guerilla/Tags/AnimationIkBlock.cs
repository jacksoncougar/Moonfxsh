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
    [LayoutAttribute(Size = 8)]
    public class AnimationIkBlockBase
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
            this.marker = binaryReader.ReadStringID();
            this.attachToMarker = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
