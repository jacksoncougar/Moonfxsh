using System;
using System.Diagnostics.Contracts;
using System.IO;
using Moonfish.Tags;

namespace Moonfish
{
	/// <summary>
	/// Class for treating a section of a stream as a stream of memory at a given base address.
	/// </summary>
	public class VirtualStreamSection
    {
		public VirtualStreamSection(int address, int length, int position, Stream basestream)
		{
			start = address;
			this.length = length;
			magic = new AddressModifier(position, address);
			baseStream = basestream;
		}

		public VirtualStreamSection(int address, int length, AddressModifier magic, Stream basestream)
		{
			start = address;
			this.length = length;
			this.magic = magic;
			baseStream = basestream;
		}

		private Stream baseStream;
		private int start;
		private long length;
		private AddressModifier magic;

		/// <summary>
		/// Contains the specified pointer.
		/// </summary>
		/// <returns>Returns true if all data in the pointer is contained</returns>
		/// <param name="pointer">Pointer to arbitrary data.</param>
        public bool Contains(BlamPointer pointer)
        {
			var contained = Contains(pointer.StartAddress) && Contains(pointer.EndAddress - 1);

            return contained;
        }

        public bool Contains(long address, bool isVirtualAddress = true)
        {
			address = isVirtualAddress ? address : magic.ToVirtualAddress(address);

			return start <= address && address < start + length;
        }
		/// <summary>
		/// Converts the given value between a virtual memory address and absolute stream position
		/// </summary>
		/// <returns>virtual memory address if <paramref name="returnVirtual"/> is <c>true</c>, otherwise the stream position</returns>
		/// <param name="value">value to convert.</param>
		/// <param name="isvirtual">If set to <c>true</c> the given <paramref name="value"/> is a virtual memory address, otherwise it is a stream position.</param>
		/// <param name="returnVirtual">If set to <c>true</c> returns the virtual memory address, otherwise returns the stream position.</param>
        [Pure]
		public long ConvertPosition(long value, bool isvirtual = true, bool returnVirtual = false)
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