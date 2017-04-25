using System;
using System.Diagnostics.Contracts;
using Moonfish.Tags;

namespace Moonfish
{
    /// <summary>
    ///     Describes a section of a stream as a stream of memory at a given base address.
    /// </summary>
    public class AddressMapDescription
    {
        private readonly long length;
        private readonly AddressMapFunction function;

        private readonly int start;

        private Func<long, bool> predicate;

        public AddressMapDescription(int address, int offset,
         Func<long, bool> predicate)
        {
            start = address;
            function = new AddressMapFunction(offset);
            this.predicate = predicate;
        }

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
        public AddressMapDescription(int address, int length,
            int position)
        {
            start = address;
            this.length = length;
            function = new AddressMapFunction(position, address);
        }

        public AddressMapDescription(int address, int length,
            AddressMapFunction function)
        {
            start = address;
            this.length = length;
            this.function = function;
        }

        /// <summary>
        ///     Contains the specified pointer.
        /// </summary>
        /// <returns>Returns true if all data in the pointer is contained</returns>
        /// <param name="pointer">Pointer to arbitrary data.</param>
        public bool Contains(BlamPointer pointer)
        {
            var contained = Contains(pointer.StartAddress, AddressType.Mapped) &&
                            Contains(pointer.EndAddress - 1, AddressType.Mapped);

            return contained;
        }


        public enum AddressType
        {
            /// <summary>
            /// A base stream address value
            /// </summary>
            Raw,
            /// <summary>
            /// A mapped address value.
            /// </summary>
            Mapped
        }
        
        /// <summary>
        ///     Contains the specified address.
        /// </summary>
        /// <param name="address">The address to check.</param>
        /// <param name="type">The type of address being passed to the function.</param>
        /// <returns></returns>
        public bool Contains(long address, AddressType type)
        {
            address = type == AddressType.Mapped
                ? address
                : function.Map(address);

            return predicate?.Invoke(address)?? start <= address && address < start + length;
        }

        public AddressMapFunction GetFunction()
        {
            return function;
        }

        /// <summary>
        ///     Converts the given address value between <see cref="AddressType"/> types.
        /// </summary>/// <param name="value">The address to convert.</param>
        /// <param name="type">The type of address being passed to the function.</param>
        /// <param name="returnType">The type of address to return from the function.</param>
        [Pure]
        public long ConvertPosition(long value, AddressType type,
            AddressType returnType)
        {
            if (type == AddressType.Mapped)
            {
                value = returnType == AddressType.Mapped ? value : function.Inverse().Map(value);
            }
            else
            {
                value = returnType == AddressType.Mapped ? function.Map(value) : value;
            }
            return value;
        }
    }
}