using JetBrains.Annotations;

namespace Moonfish
{
    /// <summary>
    ///     Allows mapping between address values in the domain to address values in the codomain
    /// </summary>
    public struct AddressMapFunction
    {
        private readonly int modifier;

        /// <summary>
        ///     Creates the translation constant for virtual to position address conversion.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <param name="address">Address.</param>
        public AddressMapFunction(long position, long address)
        {
            modifier = (int) address - (int) position;
        }

        /// <summary>
        ///     Creates the translation constant for virtual to position address conversion.
        /// </summary>
        public AddressMapFunction(int modifier)
        {
            this.modifier = modifier;
        }

        /// <summary>
        ///     Maps the given address value to codomain.
        /// </summary>
        /// <returns>The address mapped to the codomain.</returns>
        /// <param name="position">The address from the domain.</param>
        [Pure]
        public long Map(long position)
        {
            var address = (int) (position + modifier);

            return address;
        }

        /// <summary>
        /// Inverses the mapping function.
        /// </summary>
        /// <returns>The inverse function.</returns>
        [Pure]
        public AddressMapFunction Inverse()
        {
            return new AddressMapFunction(-modifier);
        }
    }
}