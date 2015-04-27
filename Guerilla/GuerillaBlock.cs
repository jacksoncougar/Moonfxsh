using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla
{
    public abstract class GuerillaBlock
    {
        protected GuerillaBlock( BinaryReader binaryReader )
        {
        }

        public abstract int Write( BinaryWriter binaryWriter, int nextAddress );
    }
}
