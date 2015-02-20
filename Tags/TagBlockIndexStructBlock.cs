using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    partial class TagBlockIndexStructBlock
    {
        public byte Length { get { return (byte)(this.length << 1); } }
    }
}
