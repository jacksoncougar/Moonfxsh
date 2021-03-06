﻿using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldShortBlockIndex1)]
    [StructLayout(LayoutKind.Sequential, Size = 2)]
    public struct ShortBlockIndex1
    {
        private short index;

        public static implicit operator short(ShortBlockIndex1 shortBlockIndex)
        {
            return shortBlockIndex.index;
        }

        public static implicit operator ShortBlockIndex1(short value)
        {
            return new ShortBlockIndex1 {index = value};
        }

        public override string ToString()
        {
            return index.ToString();
        }
    }
}