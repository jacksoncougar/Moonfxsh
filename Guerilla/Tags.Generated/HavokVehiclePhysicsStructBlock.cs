// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class HavokVehiclePhysicsStructBlock : HavokVehiclePhysicsStructBlockBase
    {
        public HavokVehiclePhysicsStructBlock() : base()
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
        public override int SerializedSize { get { return 84; } }
        public override int Alignment { get { return 4; } }
        public HavokVehiclePhysicsStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<AntiGravityPointDefinitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<FrictionPointDefinitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<VehiclePhantomShapeBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            antiGravityPoints = ReadBlockArrayData<AntiGravityPointDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            frictionPoints = ReadBlockArrayData<FrictionPointDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            shapePhantomShape = ReadBlockArrayData<VehiclePhantomShapeBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
