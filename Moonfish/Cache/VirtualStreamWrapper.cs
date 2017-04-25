using System.Collections.Generic;
using System.IO;

namespace Moonfish
{
    /// <summary>
    ///     Stream wrapper that allows for sections of the stream to be addressed by memory addresses.
    /// </summary>
    public class VirtualStreamWrapper<T> : StreamAddressWrapper<T> where T : Stream
    {
        /// <summary>
        ///     The active sections within the stream.
        /// </summary>
        private readonly HashSet<VirtualStreamIndex> activeSections = new HashSet<VirtualStreamIndex>();

        private readonly List<AddressMapDescription> virtualAddressMap =
            new List<AddressMapDescription>();

        protected override IEnumerable<AddressMapDescription> AddressMaps
        {
            get
            {
                foreach (var index in activeSections)
                {
                    yield return virtualAddressMap[(int) index];
                }
                foreach (var map in base.AddressMaps)
                {
                    yield return map;
                }
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Moonfish.VirtualStreamWrapper`1" /> class to encapsulate the given
        ///     stream
        /// </summary>
        /// <param name="stream">The stream to wrap.</param>
        public VirtualStreamWrapper(T stream) : base(stream)
        {
            return;
        }

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
        public VirtualStreamIndex CreateVirtualSection(int address, int length, int start, bool active)
        {
            AddressMapDescription sectionDescription;

            sectionDescription = new AddressMapDescription(address, length, start);

            return AddVirtualSection(sectionDescription, active);
        }

        /// <summary>
        ///     Creates a virtual section within the stream.
        /// </summary>
        /// <param name="address">The virtual address where the section starts</param>
        /// <param name="length">The length of the virtual section.</param>
        /// <param name="magic">The AddressModifier of the virtual section</param>
        /// <param name="active">If set to <c>true</c> the created virtual section will be active.</param>
        public VirtualStreamIndex CreateVirtualSection(int address, int length, AddressMapFunction magic, bool active)
        {
            AddressMapDescription sectionDescription;

            sectionDescription = new AddressMapDescription(address, length, magic);

            return AddVirtualSection(sectionDescription, active);
        }

        private VirtualStreamIndex AddVirtualSection(AddressMapDescription sectionDescription, bool active)
        {
            VirtualStreamIndex sub;

            virtualAddressMap.Add(sectionDescription);
            sub = (VirtualStreamIndex) virtualAddressMap.IndexOf(sectionDescription);

            if (active)
            {
                activeSections.Add(sub);
            }

            return sub;
        }

        /// <summary>
        ///     Enables the given virtual stream so its addressing becomes valid.
        /// </summary>
        /// <param name="ident"></param>
        public void EnableVirtualSection(VirtualStreamIndex ident) => activeSections.Add(ident);

        /// <summary>
        ///     Disables the given virtual stream so its addressing becomes invalid.
        /// </summary>
        /// <remarks>
        ///     e.g if you try to seek to an address within this virtual stream that
        ///     is not within the basestream a seek exception should occur.
        /// </remarks>
        /// <param name="ident"></param>
        public void DisableVirtualSection(VirtualStreamIndex ident) => activeSections.Remove(ident);
    };
}