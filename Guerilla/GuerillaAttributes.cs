using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GuerillaPreProcessMethodAttribute : Attribute
    {
        public string BlockName;
    }
}
