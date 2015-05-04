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
    public partial class ObjectFunctionBlock : ObjectFunctionBlockBase
    {
        public ObjectFunctionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ObjectFunctionBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Moonfish.Tags.StringIdent importName;
        internal Moonfish.Tags.StringIdent exportName;
        /// <summary>
        /// if the specified function is off, so is this function
        /// </summary>
        internal Moonfish.Tags.StringIdent turnOffWith;
        /// <summary>
        /// function must exceed this value (after mapping) to be active 0. means do nothing
        /// </summary>
        internal float minValue;
        internal MappingFunctionBlock defaultFunction;
        internal Moonfish.Tags.StringIdent scaleBy;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public ObjectFunctionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            importName = binaryReader.ReadStringID();
            exportName = binaryReader.ReadStringID();
            turnOffWith = binaryReader.ReadStringID();
            minValue = binaryReader.ReadSingle();
            defaultFunction = new MappingFunctionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(defaultFunction.ReadFields(binaryReader)));
            scaleBy = binaryReader.ReadStringID();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            defaultFunction.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
