// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PoweredMassPointBlock : PoweredMassPointBlockBase
    {
        public PoweredMassPointBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 128, Alignment = 4 )]
    public class PoweredMassPointBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal float antigravStrength;
        internal float antigravOffset;
        internal float antigravHeight;
        internal float antigravDampFraction;
        internal float antigravNormalK1;
        internal float antigravNormalK0;
        internal Moonfish.Tags.StringID damageSourceRegionName;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 128; }
        }

        internal PoweredMassPointBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadString32( );
            flags = ( Flags ) binaryReader.ReadInt32( );
            antigravStrength = binaryReader.ReadSingle( );
            antigravOffset = binaryReader.ReadSingle( );
            antigravHeight = binaryReader.ReadSingle( );
            antigravDampFraction = binaryReader.ReadSingle( );
            antigravNormalK1 = binaryReader.ReadSingle( );
            antigravNormalK0 = binaryReader.ReadSingle( );
            damageSourceRegionName = binaryReader.ReadStringID( );
            invalidName_ = binaryReader.ReadBytes( 64 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( antigravStrength );
                binaryWriter.Write( antigravOffset );
                binaryWriter.Write( antigravHeight );
                binaryWriter.Write( antigravDampFraction );
                binaryWriter.Write( antigravNormalK1 );
                binaryWriter.Write( antigravNormalK0 );
                binaryWriter.Write( damageSourceRegionName );
                binaryWriter.Write( invalidName_, 0, 64 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            GroundFriction = 1,
            WaterFriction = 2,
            AirFriction = 4,
            WaterLift = 8,
            AirLift = 16,
            Thrust = 32,
            Antigrav = 64,
            GetsDamageFromRegion = 128,
        };
    };
}