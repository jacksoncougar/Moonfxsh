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
        public  UnitCameraStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UnitCameraStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class UnitCameraStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent cameraMarkerName;
        internal Moonfish.Tags.StringIdent cameraSubmergedMarkerName;
        internal float pitchAutoLevel;
        internal Moonfish.Model.Range pitchRange;
        internal UnitCameraTrackBlock[] cameraTracks;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UnitCameraStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            cameraMarkerName = binaryReader.ReadStringID();
            cameraSubmergedMarkerName = binaryReader.ReadStringID();
            pitchAutoLevel = binaryReader.ReadSingle();
            pitchRange = binaryReader.ReadRange();
            cameraTracks = Guerilla.ReadBlockArray<UnitCameraTrackBlock>(binaryReader);
        }
        public  UnitCameraStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            cameraMarkerName = binaryReader.ReadStringID();
            cameraSubmergedMarkerName = binaryReader.ReadStringID();
            pitchAutoLevel = binaryReader.ReadSingle();
            pitchRange = binaryReader.ReadRange();
            cameraTracks = Guerilla.ReadBlockArray<UnitCameraTrackBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(cameraMarkerName);
                binaryWriter.Write(cameraSubmergedMarkerName);
                binaryWriter.Write(pitchAutoLevel);
                binaryWriter.Write(pitchRange);
                nextAddress = Guerilla.WriteBlockArray<UnitCameraTrackBlock>(binaryWriter, cameraTracks, nextAddress);
                return nextAddress;
            }
        }
    };
}
