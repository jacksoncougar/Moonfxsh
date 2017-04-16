namespace Moonfish
{
    /// <summary>
    ///     Address modifier that when added to a stream position value results in a virtual address,
    ///     and when subtracted from a virtual address results in a stream position value.
    ///     Known as magic.
    /// </summary>
    public struct AddressModifier
    {
        private readonly int magic;

        /// <summary>
        ///     Creates the translation constant for virtual to position address conversion.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <param name="address">Address.</param>
        public AddressModifier(long position, long address)
        {
            magic = (int) address - (int) position;
        }

        /// <summary>
        ///     Creates the translation constant for virtual to position address conversion.
        /// </summary>
        public AddressModifier(int magic)
        {
            this.magic = magic;
        }

        /// <summary>
        ///     Translates the given stream position into equivilent virtual address.
        /// </summary>
        /// <returns>The virtual address.</returns>
        /// <param name="position">The stream position.</param>
        public long ToVirtualAddress(long position)
        {
            var address = (int) (position + magic);

            return address;
        }

        /// <summary>
        ///     Translates the given virtual address into an equivilent stream position.
        /// </summary>
        /// <returns>The stream position.</returns>
        /// <param name="address">The virtual address.</param>
        public long ToStreamPosition(long address)
        {
            var position = (int) (address - magic);

            return position;
        }
    }
}