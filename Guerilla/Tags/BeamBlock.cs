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
        internal  BeamBlockBase(BinaryReader binaryReader)
        {
            this.shader = binaryReader.ReadTagReference();
            this.location = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.color = new ColorFunctionStructBlock(binaryReader);
            this.alpha = new ScalarFunctionStructBlock(binaryReader);
            this.width = new ScalarFunctionStructBlock(binaryReader);
            this.length = new ScalarFunctionStructBlock(binaryReader);
            this.yaw = new ScalarFunctionStructBlock(binaryReader);
            this.pitch = new ScalarFunctionStructBlock(binaryReader);
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
