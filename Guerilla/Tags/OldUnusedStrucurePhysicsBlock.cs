using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class OldUnusedStrucurePhysicsBlock : OldUnusedStrucurePhysicsBlockBase
    {
        public  OldUnusedStrucurePhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class OldUnusedStrucurePhysicsBlockBase
    {
        internal byte[] moppCode;
        internal OldUnusedObjectIdentifiersBlock[] evironmentObjectIdentifiers;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 moppBoundsMin;
        internal OpenTK.Vector3 moppBoundsMax;
        internal  OldUnusedStrucurePhysicsBlockBase(BinaryReader binaryReader)
        {
            this.moppCode = ReadData(binaryReader);
            this.evironmentObjectIdentifiers = ReadOldUnusedObjectIdentifiersBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.moppBoundsMin = binaryReader.ReadVector3();
            this.moppBoundsMax = binaryReader.ReadVector3();
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
        internal  virtual OldUnusedObjectIdentifiersBlock[] ReadOldUnusedObjectIdentifiersBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OldUnusedObjectIdentifiersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OldUnusedObjectIdentifiersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OldUnusedObjectIdentifiersBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
