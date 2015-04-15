// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectFunctionBlock : ObjectFunctionBlockBase
    {
        public  ObjectFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ObjectFunctionBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal Moonfish.Tags.StringID importName;
        internal Moonfish.Tags.StringID exportName;
        /// <summary>
        /// if the specified function is off, so is this function
        /// </summary>
        internal Moonfish.Tags.StringID turnOffWith;
        /// <summary>
        /// function must exceed this value (after mapping) to be active 0. means do nothing
        /// </summary>
        internal float minValue;
        internal MappingFunctionBlock defaultFunction;
        internal Moonfish.Tags.StringID scaleBy;
        internal  ObjectFunctionBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            importName = binaryReader.ReadStringID();
            exportName = binaryReader.ReadStringID();
            turnOffWith = binaryReader.ReadStringID();
            minValue = binaryReader.ReadSingle();
            defaultFunction = new MappingFunctionBlock(binaryReader);
            scaleBy = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(importName);
                binaryWriter.Write(exportName);
                binaryWriter.Write(turnOffWith);
                binaryWriter.Write(minValue);
                defaultFunction.Write(binaryWriter);
                binaryWriter.Write(scaleBy);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            InvertResultOfFunctionIsOneMinusActualResult = 1,
            MappingDoesNotControlsActiveTheCurveMappingCanMakeTheFunctionActiveInactive = 2,
            AlwaysActiveFunctionDoesNotDeactivateWhenAtOrBelowLowerBound = 4,
            RandomTimeOffsetFunctionOffsetsPeriodicFunctionInputByRandomValueBetween0And1 = 8,
        };
    };
}
