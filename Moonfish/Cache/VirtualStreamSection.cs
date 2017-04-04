using System;
using System.Diagnostics.Contracts;
using System.IO;
using Moonfish.Tags;

namespace Moonfish
{
	/// <summary>
	/// Class for treating a section of a stream as a stream of memory at a given base address.
	/// </summary>
	public class VirtualMappedStreamSection : Stream
    {
		public VirtualMappedStreamSection(int address, int length, int baseaddress, Stream basestream)
		{
			start = address;
			this.length = length;
			baseAddress = baseaddress;
			baseStream = basestream;
		}

		private Stream baseStream;
		private int start;
		private long length;
		private int baseAddress;

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection"/> can read.
		/// </summary>
		/// <value><c>true</c> if can read; otherwise, <c>false</c>.</value>
		public override bool CanRead => baseStream.CanRead;

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection"/> can seek.
		/// </summary>
		/// <value><c>true</c> if can seek; otherwise, <c>false</c>.</value>
		public override bool CanSeek => baseStream.CanSeek;

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection"/> can write.
		/// </summary>
		/// <value><c>true</c> if can write; otherwise, <c>false</c>.</value>
		public override bool CanWrite => baseStream.CanWrite;

		/// <summary>
		/// Gets the length.
		/// </summary>
		/// <value>The length.</value>
		public override long Length => length;

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public override long Position
		{
			/// <summary>
			/// Gets the position in the virtual memory stream
			/// </summary>
			/// <returns>The position in the virtual memory stream.</returns>
			get
			{
				return ConvertPosition(baseStream.Position, false, true);
			}
			/// <summary>
			/// Sets the position.
			/// </summary>
			/// <param name="value">Value.</param>
			set
			{
				baseStream.Seek(value, SeekOrigin.Begin);
			}
		}

		private bool ContainsFileOffset(long address)
        {
            return Contains(address, false);
        }

        [Pure]
		private bool ContainsVirtualOffset(long address)
        {
            return Contains(address);
        }

		/// <summary>
		/// Seek the specified address and origin.
		/// </summary>
		/// <returns>The seek.</returns>
		/// <param name="address">Address.</param>
		/// <param name="origin">Origin.</param>
		public override long Seek(long offset, SeekOrigin origin)
		{
			offset = ConvertPosition(offset, true, false);
			return baseStream.Seek(offset, origin);
		}

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

        [Pure]
        public bool Contains(long address, bool isVirtualAddress = true)
        {
            var virtualOffset = isVirtualAddress ? 0 : baseAddress;
            var fileAddress = (int) address + virtualOffset;

			return fileAddress >= address && fileAddress < address + Length;
        }
		/// <summary>
		/// Converts the given value between a virtual memory address and absolute stream position
		/// </summary>
		/// <returns>virtual memory address if <paramref name="returnvirtual"/> is <c>true</c>, otherwise the stream position</returns>
		/// <param name="value">value to convert.</param>
		/// <param name="isvirtual">If set to <c>true</c> the given <paramref name="value"/> is a virtual memory address, otherwise it is a stream position.</param>
		/// <param name="returnvirtual">If set to <c>true</c> returns the virtual memory address, otherwise returns the stream position.</param>
        [Pure]
		public long ConvertPosition(long value, bool isvirtual = true, bool returnvirtual = false)
		{
            if (isvirtual)
            {
                value = returnvirtual ? value : value - baseAddress;
            }
            else
            {
                value = returnvirtual ? value + baseAddress : value;
            }
            return value;
        }

		/// <summary>
		/// Flush this instance.
		/// </summary>
		public override void Flush() => baseStream.Flush();

		public override void SetLength(long value)
		{
			length = value;
		}

		public override int Read(byte[] buffer, int offset, int count)
		=> baseStream.Read(buffer, offset, count);

		public override void Write(byte[] buffer, int offset, int count)
		=> baseStream.Write(buffer, offset, count);
	}
}