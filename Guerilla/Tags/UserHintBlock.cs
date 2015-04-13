// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintBlock : UserHintBlockBase
    {
        public  UserHintBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class UserHintBlockBase  : IGuerilla
    {
        internal UserHintPointBlock[] pointGeometry;
        internal UserHintRayBlock[] rayGeometry;
        internal UserHintLineSegmentBlock[] lineSegmentGeometry;
        internal UserHintParallelogramBlock[] parallelogramGeometry;
        internal UserHintPolygonBlock[] polygonGeometry;
        internal UserHintJumpBlock[] jumpHints;
        internal UserHintClimbBlock[] climbHints;
        internal UserHintWellBlock[] wellHints;
        internal UserHintFlightBlock[] flightHints;
        internal  UserHintBlockBase(BinaryReader binaryReader)
        {
            pointGeometry = Guerilla.ReadBlockArray<UserHintPointBlock>(binaryReader);
            rayGeometry = Guerilla.ReadBlockArray<UserHintRayBlock>(binaryReader);
            lineSegmentGeometry = Guerilla.ReadBlockArray<UserHintLineSegmentBlock>(binaryReader);
            parallelogramGeometry = Guerilla.ReadBlockArray<UserHintParallelogramBlock>(binaryReader);
            polygonGeometry = Guerilla.ReadBlockArray<UserHintPolygonBlock>(binaryReader);
            jumpHints = Guerilla.ReadBlockArray<UserHintJumpBlock>(binaryReader);
            climbHints = Guerilla.ReadBlockArray<UserHintClimbBlock>(binaryReader);
            wellHints = Guerilla.ReadBlockArray<UserHintWellBlock>(binaryReader);
            flightHints = Guerilla.ReadBlockArray<UserHintFlightBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<UserHintPointBlock>(binaryWriter, pointGeometry, nextAddress);
                Guerilla.WriteBlockArray<UserHintRayBlock>(binaryWriter, rayGeometry, nextAddress);
                Guerilla.WriteBlockArray<UserHintLineSegmentBlock>(binaryWriter, lineSegmentGeometry, nextAddress);
                Guerilla.WriteBlockArray<UserHintParallelogramBlock>(binaryWriter, parallelogramGeometry, nextAddress);
                Guerilla.WriteBlockArray<UserHintPolygonBlock>(binaryWriter, polygonGeometry, nextAddress);
                Guerilla.WriteBlockArray<UserHintJumpBlock>(binaryWriter, jumpHints, nextAddress);
                Guerilla.WriteBlockArray<UserHintClimbBlock>(binaryWriter, climbHints, nextAddress);
                Guerilla.WriteBlockArray<UserHintWellBlock>(binaryWriter, wellHints, nextAddress);
                Guerilla.WriteBlockArray<UserHintFlightBlock>(binaryWriter, flightHints, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
