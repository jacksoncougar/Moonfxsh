using System.Collections.Generic;
using System.IO;

namespace Moonfish.Cache
{
	/// <summary>
	/// Cache stream wrapper that allows for sections of the stream to be addressed by memory addresses.
	/// </summary>
	public class CacheStreamWrapper<T> : Stream where T : Stream
	{
		/// <summary>
		/// Gets the wrapped stream.
		/// </summary>
		/// <value>The base stream.</value>
		protected T BaseStream { get; private set; }

		/// <summary>
		/// The virtual addressed sections within the stream.
		/// </summary>
		protected List<VirtualStreamSection> MemorySections = new List<VirtualStreamSection>();

		/// <summary>
		/// The active sections within the stream.
		/// </summary>
		protected HashSet<EVirtualStream> ActiveSections = new HashSet<EVirtualStream>();

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Moonfish.Cache.CacheStreamWrapper`1"/> class to encapsulate the given stream
		/// </summary>
		/// <param name="stream">The stream to wrap.</param>
		public CacheStreamWrapper(T stream)
		{
			BaseStream = stream;
		}

		/// <summary>
		/// Creates a virtual section within the stream.
		/// </summary>
		/// <param name="start">The position in this stream where the section starts</param>
		/// <param name="length">The length of the virtual section.</param>
		/// <param name="active">If set to <c>true</c> the created virtual section will be active.</param>
		/// <param name="address">The virtual address where the section starts.</param>
		/// <remarks>
		/// When a section is active is will be checked during calls that change the 
		/// position. If the section contains the value the streams position will be changed.
		/// </remarks>
		public EVirtualStream CreateVirtualSection(int address, int length, int start, bool active)
		{
			VirtualStreamSection section;

			section = new VirtualStreamSection(address, length, start, this);

			return AddVirtualSection(section, active);
		}

		/// <summary>
		/// Creates a virtual section within the stream.
		/// </summary>
		/// <param name="address">The virtual address where the section starts</param>
		/// <param name="length">The length of the virtual section.</param>
		/// <param name="magic">The AddressModifier of the virtual section</param>
		/// <param name="active">If set to <c>true</c> the created virtual section will be active.</param>
		public EVirtualStream CreateVirtualSection(int address, int length, AddressModifier magic, bool active)
		{
			VirtualStreamSection section;

			section = new VirtualStreamSection(address, length, magic, this);

			return AddVirtualSection(section, active);
		}

		private EVirtualStream AddVirtualSection(VirtualStreamSection section, bool active)
		{
			EVirtualStream sub;
			
			MemorySections.Add(section);
			sub = (EVirtualStream) MemorySections.IndexOf(section);

			if (active)
			{
				ActiveSections.Add(sub);
			}

			return sub;
		}

		public void EnableVirtualSection(EVirtualStream ident) => ActiveSections.Add(ident);
		public void DisableVirtualSection(EVirtualStream ident) => ActiveSections.Remove(ident);

		/// <summary>
		/// Gets or sets the position of the stream
		/// </summary>
		/// <value>The position.</value>
		public override long Position
		{
			get
			{
				var position = BaseStream.Position;

				foreach (var sub in ActiveSections)
				{
					if (MemorySections[(int)sub].Contains(position, false))
					{
						position = MemorySections[(int)sub].ConvertPosition(position, false, true);
						break;
					}
				}

				return position;
			}
			set
			{
				Seek(value, SeekOrigin.Begin);
			}
		}

		/// <summary>
		/// Sets the position within the current stream.
		/// </summary>
		/// <returns>The new position within the current stream.</returns>
		/// <param name="offset">A byte offset relative to the <paramref name="origin"/>paramter</param>
		/// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the reference point used to obtain the new position.</param>
		public override long Seek(long offset, SeekOrigin origin)
		{
			long position;

			// if this is an absolute position and not contained in the stream it could be an address.
			if (origin == SeekOrigin.Begin && !(0 <= offset && offset < Length))
			{
				foreach (var sub in ActiveSections)
				{
					if (MemorySections[(int)sub].Contains(offset, true))
					{
						offset = MemorySections[(int)sub].ConvertPosition(offset, true, false);
						break;
					}
				}
			}

			position = BaseStream.Seek(offset, origin);


			return position;
		}
		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection"/> can read.
		/// </summary>
		/// <value><c>true</c> if can read; otherwise, <c>false</c>.</value>
		public override bool CanRead => BaseStream.CanRead;

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection"/> can seek.
		/// </summary>
		/// <value><c>true</c> if can seek; otherwise, <c>false</c>.</value>
		public override bool CanSeek => BaseStream.CanSeek;

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Moonfish.VirtualMappedStreamSection"/> can write.
		/// </summary>
		/// <value><c>true</c> if can write; otherwise, <c>false</c>.</value>
		public override bool CanWrite => BaseStream.CanWrite;

		/// <summary>
		/// Gets the length.
		/// </summary>
		/// <value>The length.</value>
		public override long Length => BaseStream.Length;

		/// <summary>
		/// Flush this instance.
		/// </summary>
		public override void Flush() => BaseStream.Flush();

		public override void SetLength(long value) => BaseStream.SetLength(value);

		public override int Read(byte[] buffer, int offset, int count)
		=> BaseStream.Read(buffer, offset, count);

		public override void Write(byte[] buffer, int offset, int count)
		=> BaseStream.Write(buffer, offset, count);
	};
	
}