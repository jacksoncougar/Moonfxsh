using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldWordBlockFlags)]
    [StructLayout(LayoutKind.Sequential, Size = 2)]
    public struct BlockFlags16
    {
        public enum BlockType : byte
        {
            Biped = 0,
            Vehicle,
            Weapon,
            Equipment,
            Garbage,
            Projectile,
            Scenery,
            Machine,
            Control,
            LightFixture,
            SoundScenery,
            Crate,
            Creature,
        };

        public enum BlockSource : byte
        {
            Structure = 0,
            Editor,
            Dynamic,
            Legacy
        }

        public BlockType Type;
        public BlockSource Source;

        public BlockFlags16(short flags)
        {
            Type = ( BlockType ) ( flags >> 8 );
            Source = ( BlockSource ) ( flags & 0xFF );
        }

        public override string ToString()
        {
            return $@"Type: {Type} Source: {Source}";
        }
    }
}