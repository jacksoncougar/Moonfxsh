// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioObjectDatumStructBlock : ScenarioObjectDatumStructBlockBase
    {
        public  ScenarioObjectDatumStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class ScenarioObjectDatumStructBlockBase
    {
        internal PlacementFlags placementFlags;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 rotation;
        internal float scale;
        internal TransformFlags transformFlags;
        internal Moonfish.Tags.BlockFlags16 manualBSPFlags;
        internal ScenarioObjectIdStructBlock objectID;
        internal BSPPolicy bSPPolicy;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 editorFolder;
        internal  ScenarioObjectDatumStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            placementFlags = (PlacementFlags)binaryReader.ReadInt32();
            position = binaryReader.ReadVector3();
            rotation = binaryReader.ReadVector3();
            scale = binaryReader.ReadSingle();
            transformFlags = (TransformFlags)binaryReader.ReadInt16();
            manualBSPFlags = binaryReader.ReadBlockFlags16();
            objectID = new ScenarioObjectIdStructBlock(binaryReader);
            bSPPolicy = (BSPPolicy)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            editorFolder = binaryReader.ReadShortBlockIndex1();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)placementFlags);
                binaryWriter.Write(position);
                binaryWriter.Write(rotation);
                binaryWriter.Write(scale);
                binaryWriter.Write((Int16)transformFlags);
                binaryWriter.Write(manualBSPFlags);
                objectID.Write(binaryWriter);
                binaryWriter.Write((Byte)bSPPolicy);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(editorFolder);
            }
        }
        [FlagsAttribute]
        internal enum PlacementFlags : int
        
        {
            NotAutomatically = 1,
            Unused = 2,
            Unused0 = 4,
            Unused1 = 8,
            LockTypeToEnvObject = 16,
            LockTransformToEnvObject = 32,
            NeverPlaced = 64,
            LockNameToEnvObject = 128,
            CreateAtRest = 256,
        };
        [FlagsAttribute]
        internal enum TransformFlags : short
        
        {
            Mirrored = 1,
        };
        internal enum BSPPolicy : byte
        
        {
            Default = 0,
            AlwaysPlaced = 1,
            ManualBSPPlacement = 2,
        };
    };
}
