using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleSystemDefinitionBlockNew : ParticleSystemDefinitionBlockNewBase
    {
        public  ParticleSystemDefinitionBlockNew(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class ParticleSystemDefinitionBlockNewBase
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference particle;
        internal Moonfish.Tags.LongBlockIndex1 location;
        internal CoordinateSystem coordinateSystem;
        internal Environment environment;
        internal Disposition disposition;
        internal CameraMode cameraMode;
        /// <summary>
        /// use values between -10 and 10 to move closer and farther from camera (positive is closer)
        /// </summary>
        internal short sortBias;
        internal Flags flags;
        /// <summary>
        /// defaults to 0.0
        /// </summary>
        internal float lODInDistance;
        /// <summary>
        /// defaults to 0.0
        /// </summary>
        internal float lODFeatherInDelta;
        internal byte[] invalidName_;
        /// <summary>
        /// defaults to 30.0
        /// </summary>
        internal float lODOutDistance;
        /// <summary>
        /// defaults to 10.0
        /// </summary>
        internal float lODFeatherOutDelta;
        internal byte[] invalidName_0;
        internal ParticleSystemEmitterDefinitionBlock[] emitters;
        internal  ParticleSystemDefinitionBlockNewBase(BinaryReader binaryReader)
        {
            this.particle = binaryReader.ReadTagReference();
            this.location = binaryReader.ReadLongBlockIndex1();
            this.coordinateSystem = (CoordinateSystem)binaryReader.ReadInt16();
            this.environment = (Environment)binaryReader.ReadInt16();
            this.disposition = (Disposition)binaryReader.ReadInt16();
            this.cameraMode = (CameraMode)binaryReader.ReadInt16();
            this.sortBias = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.lODInDistance = binaryReader.ReadSingle();
            this.lODFeatherInDelta = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.lODOutDistance = binaryReader.ReadSingle();
            this.lODFeatherOutDelta = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.emitters = ReadParticleSystemEmitterDefinitionBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ParticleSystemEmitterDefinitionBlock[] ReadParticleSystemEmitterDefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemEmitterDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemEmitterDefinitionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemEmitterDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum CoordinateSystem : short
        
        {
            World = 0,
            Local = 1,
            Parent = 2,
        };
        internal enum Environment : short
        
        {
            AnyEnvironment = 0,
            AirOnly = 1,
            WaterOnly = 2,
            SpaceOnly = 3,
        };
        internal enum Disposition : short
        
        {
            EitherMode = 0,
            ViolentModeOnly = 1,
            NonviolentModeOnly = 2,
        };
        internal enum CameraMode : short
        
        {
            IndependentOfCameraMode = 0,
            OnlyInFirstPerson = 1,
            OnlyInThirdPerson = 2,
            BothFirstAndThird = 3,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Glow = 1,
            Cinematics = 2,
            LoopingParticle = 4,
            DisabledForDebugging = 8,
            InheritEffectVelocity = 16,
            DontRenderSystem = 32,
            RenderWhenZoomed = 64,
            SpreadBetweenTicks = 128,
            PersistentParticle = 256,
            ExpensiveVisibility = 512,
        };
    };
}
