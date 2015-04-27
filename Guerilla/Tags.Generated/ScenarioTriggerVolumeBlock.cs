// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioTriggerVolumeBlock : ScenarioTriggerVolumeBlockBase
    {
        public ScenarioTriggerVolumeBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 68, Alignment = 4 )]
    public class ScenarioTriggerVolumeBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 objectName;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID nodeName;
        internal EMPTYSTRING[] eMPTYSTRING;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 extents;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 killTriggerVolume;
        internal byte[] invalidName_1;

        internal ScenarioTriggerVolumeBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            objectName = binaryReader.ReadShortBlockIndex1( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            nodeName = binaryReader.ReadStringID( );
            eMPTYSTRING = new[]
            {
                new EMPTYSTRING( binaryReader ), new EMPTYSTRING( binaryReader ), new EMPTYSTRING( binaryReader ),
                new EMPTYSTRING( binaryReader ), new EMPTYSTRING( binaryReader ), new EMPTYSTRING( binaryReader ),
            };
            position = binaryReader.ReadVector3( );
            extents = binaryReader.ReadVector3( );
            invalidName_0 = binaryReader.ReadBytes( 4 );
            killTriggerVolume = binaryReader.ReadShortBlockIndex1( );
            invalidName_1 = binaryReader.ReadBytes( 2 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( objectName );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( nodeName );
                eMPTYSTRING[ 0 ].Write( binaryWriter );
                eMPTYSTRING[ 1 ].Write( binaryWriter );
                eMPTYSTRING[ 2 ].Write( binaryWriter );
                eMPTYSTRING[ 3 ].Write( binaryWriter );
                eMPTYSTRING[ 4 ].Write( binaryWriter );
                eMPTYSTRING[ 5 ].Write( binaryWriter );
                binaryWriter.Write( position );
                binaryWriter.Write( extents );
                binaryWriter.Write( invalidName_0, 0, 4 );
                binaryWriter.Write( killTriggerVolume );
                binaryWriter.Write( invalidName_1, 0, 2 );
                return nextAddress;
            }
        }

        [LayoutAttribute( Size = 4, Alignment = 1 )]
        public class EMPTYSTRING : IGuerilla
        {
            internal float eMPTYSTRING;

            internal EMPTYSTRING( BinaryReader binaryReader )
            {
                eMPTYSTRING = binaryReader.ReadSingle( );
            }

            public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( eMPTYSTRING );
                    return nextAddress;
                }
            }
        };
    };
}