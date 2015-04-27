// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class QuantizedOrientationStructBlock : QuantizedOrientationStructBlockBase
    {
        public QuantizedOrientationStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class QuantizedOrientationStructBlockBase : IGuerilla
    {
        internal short rotationX;
        internal short rotationY;
        internal short rotationZ;
        internal short rotationW;
        internal OpenTK.Vector3 defaultTranslation;
        internal float defaultScale;

        internal QuantizedOrientationStructBlockBase( BinaryReader binaryReader )
        {
            rotationX = binaryReader.ReadInt16( );
            rotationY = binaryReader.ReadInt16( );
            rotationZ = binaryReader.ReadInt16( );
            rotationW = binaryReader.ReadInt16( );
            defaultTranslation = binaryReader.ReadVector3( );
            defaultScale = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( rotationX );
                binaryWriter.Write( rotationY );
                binaryWriter.Write( rotationZ );
                binaryWriter.Write( rotationW );
                binaryWriter.Write( defaultTranslation );
                binaryWriter.Write( defaultScale );
                return nextAddress;
            }
        }
    };
}