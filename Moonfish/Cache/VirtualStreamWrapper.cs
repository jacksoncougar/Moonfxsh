using System.Collections.Generic;
using System.IO;

namespace Moonfish
{
    /// <summary>
    ///     Cache stream wrapper that allows for sections of the stream to be addressed by memory addresses.
    /// </summary>
    public class VirtualStreamWrapper<T> : Stream where T : Stream
    {
        /// <summary>
        ///     The active sections within the stream.
        /// </summary>
        protected HashSet<VirtualStreamIndex> ActiveSections =
            new HashSet<VirtualStreamIndex>();

        /// <summary>
        ///     The virtual addressed sections within the stream.
        /// </summary>
        protected List<VirtualStreamSectionDescription> MemorySections =
            new List<VirtualStreamSectionDescription>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Moonfish.VirtualStreamWrapper`1" /> class to encapsulate the given
        ///     stream
        /// </summary>
        /// <param name="stream">The stream to wrap.</param>
        public VirtualStreamWrapper(T stream)
        {
            BaseStream = stream;
        }

        /// <summary>
        ///     Gets the wrapped stream.
        /// </summary>
        /// <value>The base stream.</value>
        protected T BaseStream { get; }

        /// <summary>
        ///     Gets or sets the position of the stream
        /// </summary>
        /// <value>The position.</value>
        public sealed override long Position
        {
            get
            {
                var position = BaseStream.Position;

                foreach (var sub in ActiveSections)
                {
                    if (MemorySections[(int) sub].Contains(position, false))
                    {
                        position =
                            MemorySections[(int) sub].ConvertPosition(position,
                                false, true);
                        break;
                    }
                }

                return position;
            }
            set { Seek(value, SeekOrigin.Begin); }
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
        public override long Length => BaseStream.Length;

        /// <summary>
        ///     Creates a virtual section within the stream.
        /// </summary>
        /// <param name="start">The position in this stream where the section starts</param>
        /// <param name="length">The length of the virtual section.</param>
        /// <param name="active">If set to <c>true</c> the created virtual section will be active.</param>
        /// <param name="address">The virtual address where the section starts.</param>
        /// <remarks>
        ///     When a section is active is will be checked during calls that change the
        ///     position. If the section contains the value the streams position will be changed.
        /// </remarks>
        public VirtualStreamIndex CreateVirtualSection(int address, int length,
            int start, bool active)
        {
            VirtualStreamSectionDescription sectionDescription;

            sectionDescription = new VirtualStreamSectionDescription(address,
                length, start);

            return AddVirtualSection(sectionDescription, active);
        }

        /// <summary>
        ///     Creates a virtual section within the stream.
        /// </summary>
        /// <param name="address">The virtual address where the section starts</param>
        /// <param name="length">The length of the virtual section.</param>
        /// <param name="magic">The AddressModifier of the virtual section</param>
        /// <param name="active">If set to <c>true</c> the created virtual section will be active.</param>
        public VirtualStreamIndex CreateVirtualSection(int address, int length,
            AddressModifier magic, bool active)
        {
            VirtualStreamSectionDescription sectionDescription;

            sectionDescription = new VirtualStreamSectionDescription(address,
                length, magic);

            return AddVirtualSection(sectionDescription, active);
        }

        private VirtualStreamIndex AddVirtualSection(
            VirtualStreamSectionDescription sectionDescription, bool active)
        {
            VirtualStreamIndex sub;

            MemorySections.Add(sectionDescription);
            sub =
                (VirtualStreamIndex) MemorySections.IndexOf(sectionDescription);

            if (active)
            {
                ActiveSections.Add(sub);
            }

            return sub;
        }

        /// <summary>
        ///     Enables the given virtual stream so its addressing becomes valid.
        /// </summary>
        /// <param name="ident"></param>
        public void EnableVirtualSection(VirtualStreamIndex ident)
            => ActiveSections.Add(ident);

        /// <summary>
        ///     Disables the given virtual stream so its addressing becomes invalid.
        /// </summary>
        /// <remarks>
        ///     e.g if you try to seek to an address within this virtual stream that
        ///     is not within the basestream a seek exception should occur.
        /// </remarks>
        /// <param name="ident"></param>
        public void DisableVirtualSection(VirtualStreamIndex ident)
            => ActiveSections.Remove(ident);

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
                foreach (var sub in ActiveSections)
                {
                    if (MemorySections[(int) sub].Contains(offset, true))
                    {
                        offset =
                            MemorySections[(int) sub].ConvertPosition(offset,
                                true, false);
                        break;
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

        public override void SetLength(long value)
            => BaseStream.SetLength(value);

        public override int Read(byte[] buffer, int offset, int count)
            => BaseStream.Read(buffer, offset, count);

        public override void Write(byte[] buffer, int offset, int count)
            => BaseStream.Write(buffer, offset, count);
    }
}