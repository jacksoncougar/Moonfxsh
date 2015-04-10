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
        public  BeamBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class BeamBlockBase
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
        internal  BeamBlockBase(System.IO.BinaryReader binaryReader)
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
                binaryWriter.Write(shader);
                binaryWriter.Write(location);
                binaryWriter.Write(invalidName_, 0, 2);
                color.Write(binaryWriter);
                alpha.Write(binaryWriter);
                width.Write(binaryWriter);
                length.Write(binaryWriter);
                yaw.Write(binaryWriter);
                pitch.Write(binaryWriter);
            }
        }
    };
}
