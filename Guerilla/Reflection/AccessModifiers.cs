using System;

namespace Moonfish.Guerilla.Reflection
{
    [Flags]
    public enum AccessModifiers
    {
        Private = 1,
        Protected = 2,
        Internal = 4,
        Public = 8,
        Abstract = 16,
        Virtual = 32,
        Partial = 64,
        Override = 128,
        Any = Private | Protected | Internal | Public | Abstract | Virtual | Partial | Override
    }
}