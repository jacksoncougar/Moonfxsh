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
    public partial class ScenarioInterpolatorBlock : ScenarioInterpolatorBlockBase
    {
        public ScenarioInterpolatorBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioInterpolatorBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Moonfish.Tags.StringIdent acceleratorNameInterpolator;
        internal Moonfish.Tags.StringIdent multiplierNameInterpolator;
        internal ScalarFunctionStructBlock function;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public ScenarioInterpolatorBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            acceleratorNameInterpolator = binaryReader.ReadStringID();
            multiplierNameInterpolator = binaryReader.ReadStringID();
            function = new ScalarFunctionStructBlock();
            blamPointers.Concat(function.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            function.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(acceleratorNameInterpolator);
                binaryWriter.Write(multiplierNameInterpolator);
                function.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress;
            }
        }
    };
}
