using System;

namespace Moonfish.Graphics
{
    [Flags]
    internal enum CollisionGroup : short
    {

        None = 0,
        Level = 2,
        Objects = 3,
    }
}