// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AntiGravityPointDefinitionBlock : AntiGravityPointDefinitionBlockBase
    {
        public AntiGravityPointDefinitionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 76, Alignment = 4 )]
    public class AntiGravityPointDefinitionBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID markerName;
        internal Flags flags;
        internal float antigravStrength;
        internal float antigravOffset;
        internal float antigravHeight;
        internal float antigravDampFactor;
        internal float antigravNormalK1;
        internal float antigravNormalK0;
        internal float radius;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.StringID damageSourceRegionName;
        internal float defaultStateError;
        internal float minorDamageError;
        internal float mediumDamageError;
        internal float majorDamageError;
        internal float destroyedStateError;

        internal AntiGravityPointDefinitionBlockBase( BinaryReader binaryReader )
        {
            markerName = binaryReader.ReadStringID( );
            flags = ( Flags ) binaryReader.ReadInt32( );
            antigravStrength = binaryReader.ReadSingle( );
            antigravOffset = binaryReader.ReadSingle( );
            antigravHeight = binaryReader.ReadSingle( );
            antigravDampFactor = binaryReader.ReadSingle( );
            antigravNormalK1 = binaryReader.ReadSingle( );
            antigravNormalK0 = binaryReader.ReadSingle( );
            radius = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 12 );
            invalidName_0 = binaryReader.ReadBytes( 2 );
            invalidName_1 = binaryReader.ReadBytes( 2 );
            damageSourceRegionName = binaryReader.ReadStringID( );
            defaultStateError = binaryReader.ReadSingle( );
            minorDamageError = binaryReader.ReadSingle( );
            mediumDamageError = binaryReader.ReadSingle( );
            majorDamageError = binaryReader.ReadSingle( );
            destroyedStateError = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( markerName );
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( antigravStrength );
                binaryWriter.Write( antigravOffset );
                binaryWriter.Write( antigravHeight );
                binaryWriter.Write( antigravDampFactor );
                binaryWriter.Write( antigravNormalK1 );
                binaryWriter.Write( antigravNormalK0 );
                binaryWriter.Write( radius );
                binaryWriter.Write( invalidName_, 0, 12 );
                binaryWriter.Write( invalidName_0, 0, 2 );
                binaryWriter.Write( invalidName_1, 0, 2 );
                binaryWriter.Write( damageSourceRegionName );
                binaryWriter.Write( defaultStateError );
                binaryWriter.Write( minorDamageError );
                binaryWriter.Write( mediumDamageError );
                binaryWriter.Write( majorDamageError );
                binaryWriter.Write( destroyedStateError );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            GetsDamageFromRegion = 1,
        };
    };
}