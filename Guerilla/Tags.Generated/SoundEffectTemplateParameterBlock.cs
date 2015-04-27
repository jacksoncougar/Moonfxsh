// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectTemplateParameterBlock : SoundEffectTemplateParameterBlockBase
    {
        public SoundEffectTemplateParameterBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 36, Alignment = 4 )]
    public class SoundEffectTemplateParameterBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Type type;
        internal Flags flags;
        internal int hardwareOffset;
        internal int defaultEnumIntegerValue;
        internal float defaultScalarValue;
        internal MappingFunctionBlock defaultFunction;
        internal float minimumScalarValue;
        internal float maximumScalarValue;

        internal SoundEffectTemplateParameterBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            type = ( Type ) binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            hardwareOffset = binaryReader.ReadInt32( );
            defaultEnumIntegerValue = binaryReader.ReadInt32( );
            defaultScalarValue = binaryReader.ReadSingle( );
            defaultFunction = new MappingFunctionBlock( binaryReader );
            minimumScalarValue = binaryReader.ReadSingle( );
            maximumScalarValue = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( ( Int16 ) type );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( hardwareOffset );
                binaryWriter.Write( defaultEnumIntegerValue );
                binaryWriter.Write( defaultScalarValue );
                defaultFunction.Write( binaryWriter );
                binaryWriter.Write( minimumScalarValue );
                binaryWriter.Write( maximumScalarValue );
                return nextAddress;
            }
        }

        internal enum Type : short
        {
            Integer = 0,
            Real = 1,
            FilterType = 2,
        };

        [FlagsAttribute]
        internal enum Flags : short
        {
            ExposeAsFunction = 1,
        };
    };
}