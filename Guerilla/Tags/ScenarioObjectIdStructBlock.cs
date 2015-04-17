// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioObjectIdStructBlock : ScenarioObjectIdStructBlockBase
    {
        public ScenarioObjectIdStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ScenarioObjectIdStructBlockBase : IGuerilla
    {
        internal int uniqueID;
        internal Moonfish.Tags.ShortBlockIndex1 originBSPIndex;
        internal Type type;
        internal Source source;

        internal ScenarioObjectIdStructBlockBase( BinaryReader binaryReader )
        {
            uniqueID = binaryReader.ReadInt32( );
            originBSPIndex = binaryReader.ReadShortBlockIndex1( );
            type = ( Type ) binaryReader.ReadByte( );
            source = ( Source ) binaryReader.ReadByte( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( uniqueID );
                binaryWriter.Write( originBSPIndex );
                binaryWriter.Write( ( Byte ) type );
                binaryWriter.Write( ( Byte ) source );
                return nextAddress;
            }
        }

        internal enum Type : byte
        {
            Biped = 0,
            Vehicle = 1,
            Weapon = 2,
            Equipment = 3,
            Garbage = 4,
            Projectile = 5,
            Scenery = 6,
            Machine = 7,
            Control = 8,
            LightFixture = 9,
            SoundScenery = 10,
            Crate = 11,
            Creature = 12,
        };

        internal enum Source : byte
        {
            Structure = 0,
            Editor = 1,
            Dynamic = 2,
            Legacy = 3,
        };
    };
}