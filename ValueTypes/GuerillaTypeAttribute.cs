using System;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [AttributeUsage( AttributeTargets.All, AllowMultiple = true )]
    internal class GuerillaTypeAttribute : Attribute
    {
        public GuerillaTypeAttribute( MoonfishFieldType fieldType )
        {
            FieldType = fieldType;
        }

        public MoonfishFieldType FieldType { get; private set; }
    }
}