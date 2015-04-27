// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TriggerReferences : TriggerReferencesBase
    {
        public TriggerReferences( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class TriggerReferencesBase : GuerillaBlock
    {
        internal TriggerFlags triggerFlags;
        internal Moonfish.Tags.ShortBlockIndex1 trigger;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal TriggerReferencesBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            triggerFlags = ( TriggerFlags ) binaryReader.ReadInt32( );
            trigger = binaryReader.ReadShortBlockIndex1( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) triggerFlags );
                binaryWriter.Write( trigger );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum TriggerFlags : int
        {
            Not = 1,
        };
    };
}