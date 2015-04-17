// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorModelsBlock : DecoratorModelsBlockBase
    {
        public DecoratorModelsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class DecoratorModelsBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID modelName;
        internal short indexStart;
        internal short indexCount;

        internal DecoratorModelsBlockBase( BinaryReader binaryReader )
        {
            modelName = binaryReader.ReadStringID( );
            indexStart = binaryReader.ReadInt16( );
            indexCount = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( modelName );
                binaryWriter.Write( indexStart );
                binaryWriter.Write( indexCount );
                return nextAddress;
            }
        }
    };
}