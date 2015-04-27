// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Effe = ( TagClass ) "effe";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "effe" )]
    public partial class EffectBlock : EffectBlockBase
    {
        public EffectBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 48, Alignment = 4 )]
    public class EffectBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 loopStartEvent;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal EffectLocationsBlock[] locations;
        internal EffectEventBlock[] events;
        [TagReference( "lsnd" )] internal Moonfish.Tags.TagReference loopingSound;
        internal Moonfish.Tags.ShortBlockIndex1 location;
        internal byte[] invalidName_1;
        internal float alwaysPlayDistance;
        internal float neverPlayDistance;

        public override int SerializedSize
        {
            get { return 48; }
        }

        internal EffectBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            loopStartEvent = binaryReader.ReadShortBlockIndex1( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            invalidName_0 = binaryReader.ReadBytes( 4 );
            locations = Guerilla.ReadBlockArray<EffectLocationsBlock>( binaryReader );
            events = Guerilla.ReadBlockArray<EffectEventBlock>( binaryReader );
            loopingSound = binaryReader.ReadTagReference( );
            location = binaryReader.ReadShortBlockIndex1( );
            invalidName_1 = binaryReader.ReadBytes( 2 );
            alwaysPlayDistance = binaryReader.ReadSingle( );
            neverPlayDistance = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( loopStartEvent );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( invalidName_0, 0, 4 );
                nextAddress = Guerilla.WriteBlockArray<EffectLocationsBlock>( binaryWriter, locations, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<EffectEventBlock>( binaryWriter, events, nextAddress );
                binaryWriter.Write( loopingSound );
                binaryWriter.Write( location );
                binaryWriter.Write( invalidName_1, 0, 2 );
                binaryWriter.Write( alwaysPlayDistance );
                binaryWriter.Write( neverPlayDistance );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            DeletedWhenAttachmentDeactivates = 1,
        };
    };
}