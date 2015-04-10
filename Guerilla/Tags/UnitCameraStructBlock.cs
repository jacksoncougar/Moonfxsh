using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitCameraStructBlock : UnitCameraStructBlockBase
    {
        public  UnitCameraStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class UnitCameraStructBlockBase
    {
        internal Moonfish.Tags.StringID cameraMarkerName;
        internal Moonfish.Tags.StringID cameraSubmergedMarkerName;
        internal float pitchAutoLevel;
        internal Moonfish.Model.Range pitchRange;
        internal UnitCameraTrackBlock[] cameraTracks;
        internal  UnitCameraStructBlockBase(BinaryReader binaryReader)
        {
            this.cameraMarkerName = binaryReader.ReadStringID();
            this.cameraSubmergedMarkerName = binaryReader.ReadStringID();
            this.pitchAutoLevel = binaryReader.ReadSingle();
            this.pitchRange = binaryReader.ReadRange();
            this.cameraTracks = ReadUnitCameraTrackBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual UnitCameraTrackBlock[] ReadUnitCameraTrackBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitCameraTrackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitCameraTrackBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitCameraTrackBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
