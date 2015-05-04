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
    public partial class ShaderPostprocessOverlayNewBlock : ShaderPostprocessOverlayNewBlockBase
    {
        public ShaderPostprocessOverlayNewBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ShaderPostprocessOverlayNewBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent inputName;
        internal Moonfish.Tags.StringIdent rangeName;
        internal float timePeriodInSeconds;
        internal ScalarFunctionStructBlock function;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public ShaderPostprocessOverlayNewBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            inputName = binaryReader.ReadStringID();
            rangeName = binaryReader.ReadStringID();
            timePeriodInSeconds = binaryReader.ReadSingle();
            function = new ScalarFunctionStructBlock();
            blamPointers.Concat(function.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            function.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(inputName);
                binaryWriter.Write(rangeName);
                binaryWriter.Write(timePeriodInSeconds);
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
