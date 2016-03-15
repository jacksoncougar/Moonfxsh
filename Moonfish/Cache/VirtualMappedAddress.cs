using System.Diagnostics.Contracts;
using Moonfish.Tags;

namespace Moonfish
{
    public struct VirtualMappedAddress
    {
        public int Address;
        public int Length;
        public int Magic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address">Address Value</param>
        /// <param name="isVirtualAddress">If true Address Value is a virtual address else Address Value is file address</param>
        /// <returns>true if address points to this map</returns>
        public bool ContainsFileOffset(long address)
        {
            return Contains(address, false);
        }

        [Pure]
        public bool ContainsVirtualOffset(long address)
        {
            return Contains(address);
        }

        public bool Contains(BlamPointer pointer)
        {
            var failed = false;
            foreach (var address in pointer)
            {
                failed |= !Contains(address);
                if (failed) break;
            }

            failed |= !Contains(pointer.EndAddress - 1);

            return !failed;
        }

        [Pure]
        private bool Contains(long address, bool isVirtualAddress = true)
        {
            var virtualOffset = isVirtualAddress ? 0 : Magic;
            var fileAddress = (int) address + virtualOffset;
            var beginAddress = Address;
            var endAddress = beginAddress + Length;
            return fileAddress >= beginAddress && fileAddress < endAddress;
        }

        [Pure]
        public int GetOffset(int address, bool addressIsVirtualAddress = true, bool returnVirtualAddress = false)
        {
            if (addressIsVirtualAddress)
            {
                address = returnVirtualAddress ? address : address - Magic;
            }
            else
            {
                address = returnVirtualAddress ? address + Magic : address;
            }
            return address;
        }
    }
}