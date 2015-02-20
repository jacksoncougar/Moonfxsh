using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HsGlobalsBlock : HsGlobalsBlockBase
    {
        public  HsGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class HsGlobalsBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Type type;
        internal byte[] invalidName_;
        internal int initializationExpressionIndex;
        internal  HsGlobalsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.initializationExpressionIndex = binaryReader.ReadInt32();
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
        internal enum Type : short
        
        {
            Unparsed = 0,
            SpecialForm = 1,
            FunctionName = 2,
            Passthrough = 3,
            Void = 4,
            Boolean = 5,
            Real = 6,
            Short = 7,
            Long = 8,
            String = 9,
            Script = 10,
            StringId = 11,
            UnitSeatMapping = 12,
            TriggerVolume = 13,
            CutsceneFlag = 14,
            CutsceneCameraPoint = 15,
            CutsceneTitle = 16,
            CutsceneRecording = 17,
            DeviceGroup = 18,
            Ai = 19,
            AiCommandList = 20,
            AiCommandScript = 21,
            AiBehavior = 22,
            AiOrders = 23,
            StartingProfile = 24,
            Conversation = 25,
            StructureBsp = 26,
            Navpoint = 27,
            PointReference = 28,
            Style = 29,
            HudMessage = 30,
            ObjectList = 31,
            Sound = 32,
            Effect = 33,
            Damage = 34,
            LoopingSound = 35,
            AnimationGraph = 36,
            DamageEffect = 37,
            ObjectDefinition = 38,
            Bitmap = 39,
            Shader = 40,
            RenderModel = 41,
            StructureDefinition = 42,
            LightmapDefinition = 43,
            GameDifficulty = 44,
            Team = 45,
            ActorType = 46,
            HudCorner = 47,
            ModelState = 48,
            NetworkEvent = 49,
            Object = 50,
            Unit = 51,
            Vehicle = 52,
            Weapon = 53,
            Device = 54,
            Scenery = 55,
            ObjectName = 56,
            UnitName = 57,
            VehicleName = 58,
            WeaponName = 59,
            DeviceName = 60,
            SceneryName = 61,
        };
    };
}
