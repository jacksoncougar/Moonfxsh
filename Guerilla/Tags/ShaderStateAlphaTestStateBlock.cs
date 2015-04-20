// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderStateAlphaTestStateBlock : ShaderStateAlphaTestStateBlockBase
    {
        public ShaderStateAlphaTestStateBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ShaderStateAlphaTestStateBlockBase : IGuerilla
    {
        internal Flags flags;
        internal AlphaCompareFunction alphaCompareFunction;
        internal short alphaTestRef0255;
        internal byte[] invalidName_;

        internal ShaderStateAlphaTestStateBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt16( );
            alphaCompareFunction = ( AlphaCompareFunction ) binaryReader.ReadInt16( );
            alphaTestRef0255 = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( ( Int16 ) alphaCompareFunction );
                binaryWriter.Write( alphaTestRef0255 );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            AlphaTestEnabled = 1,
            SampleAlphaToCoverage = 2,
            SampleAlphaToOne = 4,
        };

        internal enum AlphaCompareFunction : short
        {
            Never = 0,
            Less = 1,
            Equal = 2,
            LessOrEqual = 3,
            Greater = 4,
            NotEqual = 5,
            GreaterOrEqual = 6,
            Always = 7,
        };
    };
}