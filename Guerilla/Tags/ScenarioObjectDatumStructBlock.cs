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
        public  ScenarioObjectDatumStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioObjectDatumStructBlockBase(BinaryReader binaryReader)
        {
            this.placementFlags = (PlacementFlags)binaryReader.ReadInt32();
            this.position = binaryReader.ReadVector3();
            this.rotation = binaryReader.ReadVector3();
            this.scale = binaryReader.ReadSingle();
            this.transformFlags = (TransformFlags)binaryReader.ReadInt16();
            this.manualBSPFlags = binaryReader.ReadBlockFlags16();
            this.objectID = new ScenarioObjectIdStructBlock(binaryReader);
            this.bSPPolicy = (BSPPolicy)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.editorFolder = binaryReader.ReadShortBlockIndex1();
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
