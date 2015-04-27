// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectTemplateComponentBlock : PlatformSoundEffectTemplateComponentBlockBase
    {
        public PlatformSoundEffectTemplateComponentBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class PlatformSoundEffectTemplateComponentBlockBase : GuerillaBlock
    {
        internal ValueType valueType;
        internal float defaultValue;
        internal float minimumValue;
        internal float maximumValue;

        public override int SerializedSize
        {
            get { return 16; }
        }

        internal PlatformSoundEffectTemplateComponentBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            valueType = ( ValueType ) binaryReader.ReadInt32( );
            defaultValue = binaryReader.ReadSingle( );
            minimumValue = binaryReader.ReadSingle( );
            maximumValue = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) valueType );
                binaryWriter.Write( defaultValue );
                binaryWriter.Write( minimumValue );
                binaryWriter.Write( maximumValue );
                return nextAddress;
            }
        }

        internal enum ValueType : int
        {
            Zero = 0,
            Time = 1,
            Scale = 2,
            Rolloff = 3,
        };
    };
}