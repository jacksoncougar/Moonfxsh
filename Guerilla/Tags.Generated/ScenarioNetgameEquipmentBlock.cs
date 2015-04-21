// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioNetgameEquipmentBlock : ScenarioNetgameEquipmentBlockBase
    {
        public ScenarioNetgameEquipmentBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 144, Alignment = 4 )]
    public class ScenarioNetgameEquipmentBlockBase : IGuerilla
    {
        internal Flags flags;
        internal GameType1 gameType1;
        internal GameType2 gameType2;
        internal GameType3 gameType3;
        internal GameType4 gameType4;
        internal byte[] invalidName_;
        internal short spawnTimeInSeconds0Default;
        internal short respawnOnEmptyTimeSeconds;
        internal RespawnTimerStarts respawnTimerStarts;
        internal Classification classification;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 position;
        internal ScenarioNetgameEquipmentOrientationStructBlock orientation;
        [TagReference( "null" )] internal Moonfish.Tags.TagReference itemVehicleCollection;
        internal byte[] invalidName_2;

        internal ScenarioNetgameEquipmentBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            gameType1 = ( GameType1 ) binaryReader.ReadInt16( );
            gameType2 = ( GameType2 ) binaryReader.ReadInt16( );
            gameType3 = ( GameType3 ) binaryReader.ReadInt16( );
            gameType4 = ( GameType4 ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            spawnTimeInSeconds0Default = binaryReader.ReadInt16( );
            respawnOnEmptyTimeSeconds = binaryReader.ReadInt16( );
            respawnTimerStarts = ( RespawnTimerStarts ) binaryReader.ReadInt16( );
            classification = ( Classification ) binaryReader.ReadByte( );
            invalidName_0 = binaryReader.ReadBytes( 3 );
            invalidName_1 = binaryReader.ReadBytes( 40 );
            position = binaryReader.ReadVector3( );
            orientation = new ScenarioNetgameEquipmentOrientationStructBlock( binaryReader );
            itemVehicleCollection = binaryReader.ReadTagReference( );
            invalidName_2 = binaryReader.ReadBytes( 48 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( ( Int16 ) gameType1 );
                binaryWriter.Write( ( Int16 ) gameType2 );
                binaryWriter.Write( ( Int16 ) gameType3 );
                binaryWriter.Write( ( Int16 ) gameType4 );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( spawnTimeInSeconds0Default );
                binaryWriter.Write( respawnOnEmptyTimeSeconds );
                binaryWriter.Write( ( Int16 ) respawnTimerStarts );
                binaryWriter.Write( ( Byte ) classification );
                binaryWriter.Write( invalidName_0, 0, 3 );
                binaryWriter.Write( invalidName_1, 0, 40 );
                binaryWriter.Write( position );
                orientation.Write( binaryWriter );
                binaryWriter.Write( itemVehicleCollection );
                binaryWriter.Write( invalidName_2, 0, 48 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            Levitate = 1,
            DestroyExistingOnNewSpawn = 2,
        };

        internal enum GameType1 : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        };

        internal enum GameType2 : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        };

        internal enum GameType3 : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        };

        internal enum GameType4 : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        };

        internal enum RespawnTimerStarts : short
        {
            OnPickUp = 0,
            OnBodyDepletion = 1,
        };

        internal enum Classification : byte
        {
            Weapon = 0,
            PrimaryLightLand = 1,
            SecondaryLightLand = 2,
            PrimaryHeavyLand = 3,
            PrimaryFlying = 4,
            SecondaryHeavyLand = 5,
            PrimaryTurret = 6,
            SecondaryTurret = 7,
            Grenade = 8,
            Powerup = 9,
        };
    };
}