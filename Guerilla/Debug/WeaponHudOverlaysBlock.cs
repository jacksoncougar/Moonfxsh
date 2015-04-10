// ReSharper disable All
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
        public  WeaponHudOverlaysBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  WeaponHudOverlaysBlockBase(System.IO.BinaryReader binaryReader)
        {
            stateAttachedTo = (StateAttachedTo)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(28);
            overlayBitmap = binaryReader.ReadTagReference();
            ReadWeaponHudOverlayBlockArray(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(40);
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
        internal  virtual WeaponHudOverlayBlock[] ReadWeaponHudOverlayBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponHudOverlayBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)stateAttachedTo);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)canUseOnMapType);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(overlayBitmap);
                WriteWeaponHudOverlayBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_2, 0, 40);
            }
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
