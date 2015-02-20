using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MagazineObjects : MagazineObjectsBase
    {
        public  MagazineObjects(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class MagazineObjectsBase
    {
        internal short rounds;
        internal byte[] invalidName_;
        [TagReference("eqip")]
        internal Moonfish.Tags.TagReference equipment;
        internal  MagazineObjectsBase(BinaryReader binaryReader)
        {
            this.rounds = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.equipment = binaryReader.ReadTagReference();
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
