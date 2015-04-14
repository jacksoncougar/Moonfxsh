// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GameGlobalsDamageBlock : GameGlobalsDamageBlockBase
    {
        public  GameGlobalsDamageBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class GameGlobalsDamageBlockBase  : IGuerilla
    {
        internal DamageGroupBlock[] damageGroups;
        internal  GameGlobalsDamageBlockBase(BinaryReader binaryReader)
        {
            damageGroups = Guerilla.ReadBlockArray<DamageGroupBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DamageGroupBlock>(binaryWriter, damageGroups, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
