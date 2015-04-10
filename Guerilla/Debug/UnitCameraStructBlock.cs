// ReSharper disable All
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
        public  UnitCameraStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  UnitCameraStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            cameraMarkerName = binaryReader.ReadStringID();
            cameraSubmergedMarkerName = binaryReader.ReadStringID();
            pitchAutoLevel = binaryReader.ReadSingle();
            pitchRange = binaryReader.ReadRange();
            ReadUnitCameraTrackBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual UnitCameraTrackBlock[] ReadUnitCameraTrackBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUnitCameraTrackBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(cameraMarkerName);
                binaryWriter.Write(cameraSubmergedMarkerName);
                binaryWriter.Write(pitchAutoLevel);
                binaryWriter.Write(pitchRange);
                WriteUnitCameraTrackBlockArray(binaryWriter);
            }
        }
    };
}
