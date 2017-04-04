using System;
using System.Diagnostics.Contracts;
using System.IO;
using Moonfish.Tags;

namespace Moonfish
{
	/// <summary>
	/// Address translation constant that when added to a stream position value results in a virtual address, 
	/// and when subtracted from a virtual address results in a stream position value.
	/// 
	/// Known as magic.
	/// </summary>
	public struct AddressTranslationConstant
	{
		long magic;

		/// <summary>
		/// Creates the translation constant for virtual to position address conversion.
		/// </summary>
		/// <returns>The translation constant</returns>
		/// <param name="position">Position.</param>
		/// <param name="address">Address.</param>
		public AddressTranslationConstant(long position, long address)
		{
			magic = address - position;
		}

		/// <summary>
		/// Translates the given stream position into equivilent virtual address.
		/// </summary>
		/// <returns>The virtual address.</returns>
		/// <param name="position">The stream position.</param>
		public long ToVirtualAddress(long position)
		{
			var address = position + magic;

			return address;
		}

		/// <summary>
		/// Translates the given virtual address into an equivilent stream position.
		/// </summary>
		/// <returns>The stream position.</returns>
		/// <param name="address">The virtual address.</param>
		public long ToStreamPosition(long address)
		{
			var position = address - magic;

			return position;
		}
	}
	
}