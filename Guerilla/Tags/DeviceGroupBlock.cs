// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DeviceGroupBlock : DeviceGroupBlockBase
    {
        public DeviceGroupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 40, Alignment = 4 )]
    public class DeviceGroupBlockBase : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal float initialValue01;
        internal Flags flags;

        internal DeviceGroupBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadString32( );
            initialValue01 = binaryReader.ReadSingle( );
            flags = ( Flags ) binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( initialValue01 );
                binaryWriter.Write( ( Int32 ) flags );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            CanChangeOnlyOnce = 1,
        };
    };
}