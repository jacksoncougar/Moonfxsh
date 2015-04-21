// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ItemPermutation : ItemPermutationBase
    {
        public ItemPermutation( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class ItemPermutationBase : IGuerilla
    {
        /// <summary>
        /// relatively how likely this item will be chosen
        /// </summary>
        internal float weight;

        /// <summary>
        /// which item to
        /// </summary>
        [TagReference( "item" )] internal Moonfish.Tags.TagReference item;

        internal Moonfish.Tags.StringID variantName;

        internal ItemPermutationBase( BinaryReader binaryReader )
        {
            weight = binaryReader.ReadSingle( );
            item = binaryReader.ReadTagReference( );
            variantName = binaryReader.ReadStringID( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( weight );
                binaryWriter.Write( item );
                binaryWriter.Write( variantName );
                return nextAddress;
            }
        }
    };
}