// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MagazineObjects : MagazineObjectsBase
    {
        public  MagazineObjects(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MagazineObjects(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MagazineObjectsBase : GuerillaBlock
    {
        internal short rounds;
        internal byte[] invalidName_;
        [TagReference("eqip")]
        internal Moonfish.Tags.TagReference equipment;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MagazineObjectsBase(BinaryReader binaryReader): base(binaryReader)
        {
            rounds = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            equipment = binaryReader.ReadTagReference();
        }
        public  MagazineObjectsBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            rounds = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            equipment = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(rounds);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(equipment);
                return nextAddress;
            }
        }
    };
}
