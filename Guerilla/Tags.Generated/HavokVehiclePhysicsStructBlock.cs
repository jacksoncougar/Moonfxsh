// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HavokVehiclePhysicsStructBlock : HavokVehiclePhysicsStructBlockBase
    {
        public  HavokVehiclePhysicsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HavokVehiclePhysicsStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class HavokVehiclePhysicsStructBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 84; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HavokVehiclePhysicsStructBlockBase(BinaryReader binaryReader): base(binaryReader)
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
            antiGravityPoints = Guerilla.ReadBlockArray<AntiGravityPointDefinitionBlock>(binaryReader);
            frictionPoints = Guerilla.ReadBlockArray<FrictionPointDefinitionBlock>(binaryReader);
            shapePhantomShape = Guerilla.ReadBlockArray<VehiclePhantomShapeBlock>(binaryReader);
        }
        public  HavokVehiclePhysicsStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteBlockArray<AntiGravityPointDefinitionBlock>(binaryWriter, antiGravityPoints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<FrictionPointDefinitionBlock>(binaryWriter, frictionPoints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VehiclePhantomShapeBlock>(binaryWriter, shapePhantomShape, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Invalid = 1,
        };
    };
}
