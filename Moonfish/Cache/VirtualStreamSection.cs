using System.Diagnostics.Contracts;
using Moonfish.Tags;

namespace Moonfish
{
    /// <summary>
    ///     Describes a section of a stream as a stream of memory at a given base address.
    /// </summary>
    public class VirtualStreamSectionDescription
    {
        private readonly long length;
        private readonly AddressModifier magic;

        private readonly int start;

        /// <summary>
        ///     Creates a description of a virtual stream section.
        /// </summary>
        /// <remarks>
        ///     Creates a mapping so that (1) and (2) are valid:
        ///     (1) position == address
        ///     (2) position + length - 1 == address + length - 1.
        /// </remarks>
        /// <param name="address">The virtual address the beginning of the section maps to.</param>
        /// <param name="length">The length of the section to map to the virtual address.</param>
        /// <param name="position">The position in the basestream to begin mapping from.</param>
        public VirtualStreamSectionDescription(int address, int length,
            int position)
        {
            start = address;
            this.length = length;
            magic = new AddressModifier(position, address);
        }

        public VirtualStreamSectionDescription(int address, int length,
            AddressModifier magic)
        {
            start = address;
            this.length = length;
            this.magic = magic;
        }

        /// <summary>
        ///     Contains the specified pointer.
        /// </summary>
        /// <returns>Returns true if all data in the pointer is contained</returns>
        /// <param name="pointer">Pointer to arbitrary data.</param>
        public bool Contains(BlamPointer pointer)
        {
            var contained = Contains(pointer.StartAddress) &&
                            Contains(pointer.EndAddress - 1);

            return contained;
        }

        /// <summary>
        ///     Contains the specified address.
        /// </summary>
        /// <param name="address">The address to check</param>
        /// <param name="isVirtualAddress">True if this address a virtual address or false otherwise</param>
        /// <returns></returns>
        public bool Contains(long address, bool isVirtualAddress = true)
        {
            address = isVirtualAddress
                ? address
                : magic.ToVirtualAddress(address);

            return start <= address && address < start + length;
        }

        /// <summary>
        ///     Converts the given value between a virtual memory address and absolute stream position
        /// </summary>
        /// <returns>virtual memory address if <paramref name="returnVirtual" /> is <c>true</c>, otherwise the stream position</returns>
        /// <param name="value">value to convert.</param>
        /// <param name="isvirtual">
        ///     If set to <c>true</c> the given <paramref name="value" /> is a virtual memory address,
        ///     otherwise it is a stream position.
        /// </param>
        /// <param name="returnVirtual">
        ///     If set to <c>true</c> returns the virtual memory address, otherwise returns the stream
        ///     position.
        /// </param>
        [Pure]
        public long ConvertPosition(long value, bool isvirtual = true,
            bool returnVirtual = false)
        {
            if (isvirtual)
            {
                value = returnVirtual ? value : magic.ToStreamPosition(value);
            }
            else
            {
                value = returnVirtual ? magic.ToVirtualAddress(value) : value;
            }
            return value;
        }
    }
}