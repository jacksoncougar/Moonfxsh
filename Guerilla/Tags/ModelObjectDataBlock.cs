// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelObjectDataBlock : ModelObjectDataBlockBase
    {
        public ModelObjectDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class ModelObjectDataBlockBase : IGuerilla
    {
        internal Type type;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 offset;
        internal float radius;

        internal ModelObjectDataBlockBase( BinaryReader binaryReader )
        {
            type = ( Type ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            offset = binaryReader.ReadVector3( );
            radius = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) type );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( offset );
                binaryWriter.Write( radius );
                return nextAddress;
            }
        }

        internal enum Type : short
        {
            NotSet = 0,
            UserDefined = 1,
            AutoGenerated = 2,
        };
    };
}