using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Fasterflect;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Cache
{
	/// <summary>
	/// Cache stream wrapper that allows for sections of the stream to be addressed by memory addresses.
	/// </summary>
	public abstract class CacheStreamWrapper<T> : Stream where T : Stream
	{
		private readonly T baseStream;

		/// <summary>
		/// The virtual addressed sections within the stream.
		/// </summary>
		protected List<VirtualStreamSection> memorySections = new List<VirtualStreamSection>();

		/// <summary>
		/// The active sections within the stream.
		/// </summary>
		protected HashSet<int> activeSections = new HashSet<int>();

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Moonfish.Cache.CacheStreamWrapper`1"/> class to encapsulate the given stream
		/// </summary>
		/// <param name="stream">The stream to wrap.</param>
		protected CacheStreamWrapper(T stream)
		{
			baseStream = stream;
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
		protected int CreateVirtualSection(int start, int length, int address, bool active)
		{
			VirtualStreamSection section;
			int sub;

			section = new VirtualStreamSection(address, length, start, this);

			memorySections.Add(section);
			sub = memorySections.IndexOf(section);

			if (active)
			{
				activeSections.Add(sub);
			}

			return sub;
		}

		protected void CreateVirtualSection(int address, int length, AddressModifier magic, bool active)
		{
			
		}
		protected void EnableVirtualSection(int index) => activeSections.Add(index);
		protected void DisableVirtualSection(int index) => activeSections.Remove(index);

		/// <summary>
		/// Gets or sets the position of the stream
		/// </summary>
		/// <value>The position.</value>
		public override long Position
		{
			get
			{
				var position = baseStream.Position;

				foreach (var sub in activeSections)
				{
					if (memorySections[sub].Contains(position, false))
					{
						position = memorySections[sub].Position;
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
			long position = -1; // keep the compiler happy...

			// if this is an absolute position and not contained in the stream it could be an address.
			if (origin == SeekOrigin.Begin && !(0 <= offset && offset < Length))
			{
				foreach (var sub in activeSections)
				{
					if (memorySections[sub].Contains(offset, false))
					{
						position = memorySections[sub].Seek(offset, origin);
						break;
					}
				}
			}
			else
			{
				position = baseStream.Seek(offset, origin);
			}

			return position;
		}
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
		public override long Length => baseStream.Length;

		/// <summary>
		/// Flush this instance.
		/// </summary>
		public override void Flush() => baseStream.Flush();

		public override void SetLength(long value) => baseStream.SetLength(value);

		public override int Read(byte[] buffer, int offset, int count)
		=> baseStream.Read(buffer, offset, count);

		public override void Write(byte[] buffer, int offset, int count)
		=> baseStream.Write(buffer, offset, count);
	};
	
}