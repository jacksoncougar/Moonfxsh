using System.IO;
using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldPoint_2D)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct Point
    {
        public short X { get; set; }
        public short Y { get; set; }

        public Point(short x, short y)
            : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}