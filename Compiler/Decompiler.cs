using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Compiler
{
    public class Decompiler
    {
        public void Decompile(MapStream cache)
        {
            foreach (var tag in cache.Tags) 
            {
                var tagObject = cache[ tag.Identifier ].Deserialize();
            }
        }
    }
}
