using System.Diagnostics.Contracts;
using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish
{
    public enum MapType
    {
        Multiplayer = 1,
        MainMenu = 2,
        Shared = 3,
        SinglePlayerShared = 4,
    }

    public enum Version
    {
        XBOX_RETAIL,
        PC_RETAIL,
    }

    /* * *
     * Unicode Handling
     * ----------------
     * Store an index pointing to a table which maps to a UTF8 string for each language.
     * For each Unicode there will be a memory usage of 4 + ( language_count * 4 ) used for indexers
     * 
     * [StringID] -> [index] : 0 -> [Language Switch Mappings] -> [English] -> UTF8 String
     * 
     * Using a dictionary to map the string_id value to an index in the language map
     * using a custom struct to hold to language mappings
     * using a list to hold the UTF8 strings
     * 
     * * */

    internal struct UnicodeItem
    {
        private int[] _indices;

        private int[] Indices
        {
            get { return _indices; }
        }
    }

    public struct UnicodeValueNamePair
    {
        //depre.//
        public StringID Name;
        public string Value;

        public override string ToString( )
        {
            return string.Format( "{0}:{1} : \"{2}\"", Name.Index, Name.Length, Value );
        }
    }

    public struct VirtualMappedAddress
    {
        public int Address;
        public int Length;
        public int Magic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address">Address Value</param>
        /// <param name="isVirtualAddress">If true Address Value is a virtual address else Address Value is file address</param>
        /// <returns>true if address points to this map</returns>
        public bool ContainsFileOffset( long address )
        {
            return Contains( address, false );
        }

        [Pure]
        public bool ContainsVirtualOffset( long address )
        {
            return Contains( address );
        }

        public bool Contains( BlamPointer pointer )
        {
            var failed = false;
            foreach ( var address in pointer )
            {
                failed |= !Contains( address );
                if ( failed ) break;
            }

            failed |= !Contains( pointer.EndAddress - 1 );

            return !failed;
        }

        [Pure]
        private bool Contains( long address, bool isVirtualAddress = true )
        {
            var virtualOffset = isVirtualAddress ? 0 : Magic;
            var fileAddress = ( int ) address + virtualOffset;
            var beginAddress = Address;
            var endAddress = beginAddress + Length;
            return fileAddress >= beginAddress && fileAddress < endAddress;
        }

        [Pure]
        public int GetOffset( int address, bool addressIsVirtualAddress = true, bool returnVirtualAddress = false )
        {
            if ( addressIsVirtualAddress )
            {
                address = returnVirtualAddress ? address : address - Magic;
            }
            else
            {
                address = returnVirtualAddress ? address + Magic : address;
            }
            return address;
        }
    }

    public interface IMap
    {
        /// <summary>
        /// Returns a TagBlock from the current class
        /// </summary>
        /// <returns></returns>
        dynamic Deserialize( );

        /// <summary>
        /// Access meta information about the tag
        /// </summary>
        Tag Meta { get; set; }

        byte[] TagData { get; }
    }

    public class Tag
    {
        public TagClass Class;
        public string Path { get; set; }
        public TagIdent Identifier;
        public int VirtualAddress;
        public int Length;

        internal bool Contains( int address )
        {
            return ( address >= VirtualAddress && address < VirtualAddress + Length );
        }
    }
}