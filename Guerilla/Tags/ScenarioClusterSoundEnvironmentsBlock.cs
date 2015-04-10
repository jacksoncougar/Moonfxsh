using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioClusterSoundEnvironmentsBlock : ScenarioClusterSoundEnvironmentsBlockBase
    {
        public  ScenarioClusterSoundEnvironmentsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class ScenarioClusterSoundEnvironmentsBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal byte[] invalidName_;
        internal  ScenarioClusterSoundEnvironmentsBlockBase(BinaryReader binaryReader)
        {
            this.type = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
