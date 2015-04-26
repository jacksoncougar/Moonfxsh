// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioWeaponBlock : ScenarioWeaponBlockBase
    {
        public  ScenarioWeaponBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class ScenarioWeaponBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal byte[] indexer;
        internal ScenarioObjectPermutationStructBlock permutationData;
        internal ScenarioWeaponDatumStructBlock weaponData;
        internal  ScenarioWeaponBlockBase(BinaryReader binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            indexer = binaryReader.ReadBytes(4);
            permutationData = new ScenarioObjectPermutationStructBlock(binaryReader);
            weaponData = new ScenarioWeaponDatumStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                binaryWriter.Write(indexer, 0, 4);
                permutationData.Write(binaryWriter);
                weaponData.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
