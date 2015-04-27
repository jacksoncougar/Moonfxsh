// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GloalWindPrimitivesBlock : GloalWindPrimitivesBlockBase
    {
        public GloalWindPrimitivesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class GloalWindPrimitivesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal float radius;
        internal float strength;
        internal WindPrimitiveType windPrimitiveType;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 24; }
        }

        internal GloalWindPrimitivesBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            position = binaryReader.ReadVector3( );
            radius = binaryReader.ReadSingle( );
            strength = binaryReader.ReadSingle( );
            windPrimitiveType = ( WindPrimitiveType ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( position );
                binaryWriter.Write( radius );
                binaryWriter.Write( strength );
                binaryWriter.Write( ( Int16 ) windPrimitiveType );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }

        internal enum WindPrimitiveType : short
        {
            Vortex = 0,
            Gust = 1,
            Implosion = 2,
            Explosion = 3,
        };
    };
}