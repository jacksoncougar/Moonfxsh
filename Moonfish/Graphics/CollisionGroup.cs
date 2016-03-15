using System;

namespace Moonfish.Graphics
{
    [Flags]
    internal enum CollisionGroup : short
    {

        None = 0,
        Level = 1,
        Objects = 1 << 1,
        Static = 1 << 2,
    }
}