// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HavokVehiclePhysicsStructBlock : HavokVehiclePhysicsStructBlockBase
    {
        public  HavokVehiclePhysicsStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class HavokVehiclePhysicsStructBlockBase
    {
        internal Flags flags;
        /// <summary>
        ///  for friction based vehicles only
        /// </summary>
        internal float groundFriction;
        /// <summary>
        ///  for friction based vehicles only
        /// </summary>
        internal float groundDepth;
        /// <summary>
        ///  for friction based vehicles only
        /// </summary>
        internal float groundDampFactor;
        /// <summary>
        ///  for friction based vehicles only
        /// </summary>
        internal float groundMovingFriction;
        /// <summary>
        /// degrees 0-90
        /// </summary>
        internal float groundMaximumSlope0;
        /// <summary>
        /// degrees 0-90.  and greater than slope 0
        /// </summary>
        internal float groundMaximumSlope1;
        internal byte[] invalidName_;
        /// <summary>
        /// lift per WU.
        /// </summary>
        internal float antiGravityBankLift;
        /// <summary>
        /// how quickly we bank when we steer
        /// </summary>
        internal float steeringBankReactionScale;
        /// <summary>
        /// value of 0 defaults to 1.  .5 is half gravity
        /// </summary>
        internal float gravityScale;
        /// <summary>
        /// generated from the radius of the hkConvexShape for this vehicle
        /// </summary>
        internal float radius;
        internal AntiGravityPointDefinitionBlock[] antiGravityPoints;
        internal FrictionPointDefinitionBlock[] frictionPoints;
        internal VehiclePhantomShapeBlock[] shapePhantomShape;
        internal  HavokVehiclePhysicsStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            groundFriction = binaryReader.ReadSingle();
            groundDepth = binaryReader.ReadSingle();
            groundDampFactor = binaryReader.ReadSingle();
            groundMovingFriction = binaryReader.ReadSingle();
            groundMaximumSlope0 = binaryReader.ReadSingle();
            groundMaximumSlope1 = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(16);
            antiGravityBankLift = binaryReader.ReadSingle();
            steeringBankReactionScale = binaryReader.ReadSingle();
            gravityScale = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            ReadAntiGravityPointDefinitionBlockArray(binaryReader);
            ReadFrictionPointDefinitionBlockArray(binaryReader);
            ReadVehiclePhantomShapeBlockArray(binaryReader);
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
        internal  virtual AntiGravityPointDefinitionBlock[] ReadAntiGravityPointDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AntiGravityPointDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AntiGravityPointDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AntiGravityPointDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual FrictionPointDefinitionBlock[] ReadFrictionPointDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FrictionPointDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FrictionPointDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FrictionPointDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VehiclePhantomShapeBlock[] ReadVehiclePhantomShapeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VehiclePhantomShapeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VehiclePhantomShapeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VehiclePhantomShapeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAntiGravityPointDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteFrictionPointDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVehiclePhantomShapeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(groundFriction);
                binaryWriter.Write(groundDepth);
                binaryWriter.Write(groundDampFactor);
                binaryWriter.Write(groundMovingFriction);
                binaryWriter.Write(groundMaximumSlope0);
                binaryWriter.Write(groundMaximumSlope1);
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(antiGravityBankLift);
                binaryWriter.Write(steeringBankReactionScale);
                binaryWriter.Write(gravityScale);
                binaryWriter.Write(radius);
                WriteAntiGravityPointDefinitionBlockArray(binaryWriter);
                WriteFrictionPointDefinitionBlockArray(binaryWriter);
                WriteVehiclePhantomShapeBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Invalid = 1,
        };
    };
}
