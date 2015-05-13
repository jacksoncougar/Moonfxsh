using System.Collections.Generic;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class GuerillaBlockAllocator
    {
        private int baseAddress;
        public Dictionary<object, BlamPointer> LayoutDictionary;

        GuerillaBlockAllocator(int address)
        {
            baseAddress = address;
            LayoutDictionary = new Dictionary<object, BlamPointer>(1000);
        }

        public void Allocate<T>(T guerillaBlock) where T : GuerillaBlock
        {
            
        }
    };
}