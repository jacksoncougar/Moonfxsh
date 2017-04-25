using System;
using System.Collections.Generic;
using System.IO;

namespace Moonfish
{
    /// <summary>
    /// Abstract class for manipulating the addresses in a stream. 
    /// Provides methods to remove a range of addresses or alias a range of addresses
    /// </summary>
    /// <typeparam name="T">The the stream object to wrap</typeparam>
    /// <seealso cref="System.IO.Stream" />
    public class StreamAddressWrapper<T> : Stream where T : Stream
    {
        /// <summary>
        ///     The virtual addressed sections within the stream.
        /// </summary>
        private readonly List<AddressMapDescription> maps = new List<AddressMapDescription>();

        protected StreamAddressWrapper(T stream)
        {
            BaseStream = stream;
        }

        protected virtual IEnumerable<AddressMapDescription> AddressMaps
        {
            get { return maps; }
        }

        /// <summary>
        ///     Gets the wrapped stream.
        /// </summary>
        /// <value>The base stream.</value>
        protected T BaseStream { get; }

        /// <summary>
        /// Removes the specified address range from the stream addressing.
        /// </summary>
        /// <param name="address">The address to start removing from.</param>
        /// <param name="length">The length in bytes to remove.</param>
        public void RemoveAddresses(int address, int length)
        {
            maps.Add(new AddressMapDescription(address, -length, (long value) => value >= address));
        }

        /// <summary>
        /// Aliases the specified address range
        /// </summary>
        /// <param name="srcAddress">The source address used by the underlying stream.</param>
        /// <param name="destAddress">The destination address to alias the source address as.</param>
        /// <param name="length">The length in bytes from <param name="srcAddress"> to alias.</param></param>
        public void AliasAddressess(int srcAddress, int destAddress, int length)
        {
            maps.Add(new AddressMapDescription(destAddress, length, srcAddress));
        }

        /// <summary>
        ///     Gets or sets the position of the stream
        /// </summary>
        /// <value>The position.</value>
        public sealed override long Position
        {
            get
            {
                var position = BaseStream.Position;

                position = ApplyAddressMaps(position);

                return position;
            }
            set { Seek(value, SeekOrigin.Begin); }
        }

        private long ApplyAddressMaps(long position)
        {
            foreach (var map in AddressMaps)
            {
                if (map.Contains(position, AddressMapDescription.AddressType.Raw))
                {
                    position = map.GetFunction().Map(position);
                }
            }
            return position;
        }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection" /> can read.
        /// </summary>
        /// <value><c>true</c> if can read; otherwise, <c>false</c>.</value>
        public override bool CanRead => BaseStream.CanRead;

        /// <summary>
        ///     Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection" /> can seek.
        /// </summary>
        /// <value><c>true</c> if can seek; otherwise, <c>false</c>.</value>
        public override bool CanSeek => BaseStream.CanSeek;

        /// <summary>
        ///     Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection" /> can write.
        /// </summary>
        /// <value><c>true</c> if can write; otherwise, <c>false</c>.</value>
        public override bool CanWrite => BaseStream.CanWrite;

        /// <summary>
        ///     Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public override long Length => ApplyAddressMaps(BaseStream.Length);

        /// <summary>
        ///     Sets the position within the current stream.
        /// </summary>
        /// <returns>The new position within the current stream.</returns>
        /// <param name="offset">A byte offset relative to the <paramref name="origin" />paramter</param>
        /// <param name="origin">
        ///     A value of type <see cref="SeekOrigin" /> indicating the reference point used to obtain the new
        ///     position.
        /// </param>
        public sealed override long Seek(long offset, SeekOrigin origin)
        {
            long position;

            // if this is an absolute position and not contained in the stream it could be an address.
            if (origin == SeekOrigin.Begin)
            {
                foreach (var map in AddressMaps)
                {
                    if (map.Contains(offset, AddressMapDescription.AddressType.Mapped))
                    {
                        offset = map.GetFunction().Inverse().Map(offset);
                    }
                }
            }

            position = BaseStream.Seek(offset, origin);

            return position;
        }

        /// <summary>
        ///     Flush this instance.
        /// </summary>
        public override void Flush() => BaseStream.Flush();

        public override void SetLength(long value) => BaseStream.SetLength(value);

        public override int Read(byte[] buffer, int offset, int count) => BaseStream.Read(buffer, offset, count);

        public override void Write(byte[] buffer, int offset, int count) => BaseStream.Write(buffer, offset, count);
    }
}