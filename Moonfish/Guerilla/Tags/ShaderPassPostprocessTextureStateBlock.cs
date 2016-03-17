using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPassPostprocessTextureStateBlock
    {
        public static ShaderPassPostprocessTextureStateBlock Default => new ShaderPassPostprocessTextureStateBlock
        {
            fieldskip = new byte[]
            {
                0x32, 0x24, 0x40, 0x00, 0x01, 0x01, 0x01, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            }
        };
    };
}
