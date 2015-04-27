// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioCutsceneCameraPointBlock : ScenarioCutsceneCameraPointBlockBase
    {
        public ScenarioCutsceneCameraPointBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 64, Alignment = 4 )]
    public class ScenarioCutsceneCameraPointBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Type type;
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 orientation;
        internal float unused;

        public override int SerializedSize
        {
            get { return 64; }
        }

        internal ScenarioCutsceneCameraPointBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt16( );
            type = ( Type ) binaryReader.ReadInt16( );
            name = binaryReader.ReadString32( );
            position = binaryReader.ReadVector3( );
            orientation = binaryReader.ReadVector3( );
            unused = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( ( Int16 ) type );
                binaryWriter.Write( name );
                binaryWriter.Write( position );
                binaryWriter.Write( orientation );
                binaryWriter.Write( unused );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            EditAsRelative = 1,
        };

        internal enum Type : short
        {
            Normal = 0,
            IgnoreTargetOrientation = 1,
            Dolly = 2,
            IgnoreTargetUpdates = 3,
        };
    };
}