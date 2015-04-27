// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class OldUnusedStrucurePhysicsBlock : OldUnusedStrucurePhysicsBlockBase
    {
        public  OldUnusedStrucurePhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  OldUnusedStrucurePhysicsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class OldUnusedStrucurePhysicsBlockBase : GuerillaBlock
    {
        internal byte[] moppCode;
        internal OldUnusedObjectIdentifiersBlock[] evironmentObjectIdentifiers;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 moppBoundsMin;
        internal OpenTK.Vector3 moppBoundsMax;
        
        public override int SerializedSize{get { return 44; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  OldUnusedStrucurePhysicsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            moppCode = Guerilla.ReadData(binaryReader);
            evironmentObjectIdentifiers = Guerilla.ReadBlockArray<OldUnusedObjectIdentifiersBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            moppBoundsMin = binaryReader.ReadVector3();
            moppBoundsMax = binaryReader.ReadVector3();
        }
        public  OldUnusedStrucurePhysicsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, moppCode, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OldUnusedObjectIdentifiersBlock>(binaryWriter, evironmentObjectIdentifiers, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(moppBoundsMin);
                binaryWriter.Write(moppBoundsMax);
                return nextAddress;
            }
        }
    };
}
