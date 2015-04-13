// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScalarFunctionStructBlock : ScalarFunctionStructBlockBase
    {
        public  ScalarFunctionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScalarFunctionStructBlockBase  : IGuerilla
    {
        internal MappingFunctionBlock function;
        internal  ScalarFunctionStructBlockBase(BinaryReader binaryReader)
        {
            function = new MappingFunctionBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                function.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
