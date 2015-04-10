using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudOverlaysBlock : WeaponHudOverlaysBlockBase
    {
        public  WeaponHudOverlaysBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class WeaponHudOverlaysBlockBase
    {
        internal StateAttachedTo stateAttachedTo;
        internal byte[] invalidName_;
        internal CanUseOnMapType canUseOnMapType;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference overlayBitmap;
        internal WeaponHudOverlayBlock[] overlays;
        internal byte[] invalidName_2;
        internal  WeaponHudOverlaysBlockBase(BinaryReader binaryReader)
        {
            this.stateAttachedTo = (StateAttachedTo)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(28);
            this.overlayBitmap = binaryReader.ReadTagReference();
            this.overlays = ReadWeaponHudOverlayBlockArray(binaryReader);
            this.invalidName_2 = binaryReader.ReadBytes(40);
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
        internal  virtual WeaponHudOverlayBlock[] ReadWeaponHudOverlayBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudOverlayBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudOverlayBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudOverlayBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum StateAttachedTo : short
        
        {
            InventoryAmmo = 0,
            LoadedAmmo = 1,
            Heat = 2,
            Age = 3,
            SecondaryWeaponInventoryAmmo = 4,
            SecondaryWeaponLoadedAmmo = 5,
            DistanceToTarget = 6,
            ElevationToTarget = 7,
        };
        internal enum CanUseOnMapType : short
        
        {
            Any = 0,
            Solo = 1,
            Multiplayer = 2,
        };
    };
}
