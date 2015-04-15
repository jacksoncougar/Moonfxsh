using System;

namespace Moonfish.Guerilla
{
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public class GuerillaPreProcessMethodAttribute : Attribute
    {
        public string BlockName;
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GuerillaPreProcessFieldsMethodAttribute : Attribute
    {
        public string BlockName;
    }
}
