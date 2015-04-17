// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitCameraStructBlock : UnitCameraStructBlockBase
    {
        public UnitCameraStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 28, Alignment = 4 )]
    public class UnitCameraStructBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID cameraMarkerName;
        internal Moonfish.Tags.StringID cameraSubmergedMarkerName;
        internal float pitchAutoLevel;
        internal Moonfish.Model.Range pitchRange;
        internal UnitCameraTrackBlock[] cameraTracks;

        internal UnitCameraStructBlockBase( BinaryReader binaryReader )
        {
            cameraMarkerName = binaryReader.ReadStringID( );
            cameraSubmergedMarkerName = binaryReader.ReadStringID( );
            pitchAutoLevel = binaryReader.ReadSingle( );
            pitchRange = binaryReader.ReadRange( );
            cameraTracks = Guerilla.ReadBlockArray<UnitCameraTrackBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( cameraMarkerName );
                binaryWriter.Write( cameraSubmergedMarkerName );
                binaryWriter.Write( pitchAutoLevel );
                binaryWriter.Write( pitchRange );
                nextAddress = Guerilla.WriteBlockArray<UnitCameraTrackBlock>( binaryWriter, cameraTracks, nextAddress );
                return nextAddress;
            }
        }
    };
}