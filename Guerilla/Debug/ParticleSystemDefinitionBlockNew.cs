// ReSharper disable All
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
        public  ParticleSystemDefinitionBlockNew(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticleSystemDefinitionBlockNewBase(System.IO.BinaryReader binaryReader)
        {
            particle = binaryReader.ReadTagReference();
            location = binaryReader.ReadLongBlockIndex1();
            coordinateSystem = (CoordinateSystem)binaryReader.ReadInt16();
            environment = (Environment)binaryReader.ReadInt16();
            disposition = (Disposition)binaryReader.ReadInt16();
            cameraMode = (CameraMode)binaryReader.ReadInt16();
            sortBias = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            lODInDistance = binaryReader.ReadSingle();
            lODFeatherInDelta = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            lODOutDistance = binaryReader.ReadSingle();
            lODFeatherOutDelta = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            ReadParticleSystemEmitterDefinitionBlockArray(binaryReader);
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
        internal  virtual ParticleSystemEmitterDefinitionBlock[] ReadParticleSystemEmitterDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemEmitterDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemEmitterDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemEmitterDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleSystemEmitterDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(particle);
                binaryWriter.Write(location);
                binaryWriter.Write((Int16)coordinateSystem);
                binaryWriter.Write((Int16)environment);
                binaryWriter.Write((Int16)disposition);
                binaryWriter.Write((Int16)cameraMode);
                binaryWriter.Write(sortBias);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(lODInDistance);
                binaryWriter.Write(lODFeatherInDelta);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(lODOutDistance);
                binaryWriter.Write(lODFeatherOutDelta);
                binaryWriter.Write(invalidName_0, 0, 4);
                WriteParticleSystemEmitterDefinitionBlockArray(binaryWriter);
            }
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
