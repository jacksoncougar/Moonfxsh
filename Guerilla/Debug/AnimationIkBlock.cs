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
        public  AnimationIkBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationIkBlockBase(System.IO.BinaryReader binaryReader)
        {
            marker = binaryReader.ReadStringID();
            attachToMarker = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(marker);
                binaryWriter.Write(attachToMarker);
            }
        }
    };
}
