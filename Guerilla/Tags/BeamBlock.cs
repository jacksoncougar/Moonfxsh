// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BeamBlock : BeamBlockBase
    {
        public  BeamBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class BeamBlockBase  : IGuerilla
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal Moonfish.Tags.ShortBlockIndex1 location;
        internal byte[] invalidName_;
        internal ColorFunctionStructBlock color;
        internal ScalarFunctionStructBlock alpha;
        internal ScalarFunctionStructBlock width;
        internal ScalarFunctionStructBlock length;
        internal ScalarFunctionStructBlock yaw;
        internal ScalarFunctionStructBlock pitch;
        internal  BeamBlockBase(BinaryReader binaryReader)
        {
            shader = binaryReader.ReadTagReference();
            location = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            color = new ColorFunctionStructBlock(binaryReader);
            alpha = new ScalarFunctionStructBlock(binaryReader);
            width = new ScalarFunctionStructBlock(binaryReader);
            length = new ScalarFunctionStructBlock(binaryReader);
            yaw = new ScalarFunctionStructBlock(binaryReader);
            pitch = new ScalarFunctionStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shader);
                binaryWriter.Write(location);
                binaryWriter.Write(invalidName_, 0, 2);
                color.Write(binaryWriter);
                alpha.Write(binaryWriter);
                width.Write(binaryWriter);
                length.Write(binaryWriter);
                yaw.Write(binaryWriter);
                pitch.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
