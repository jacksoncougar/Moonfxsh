// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class STextValuePairBlocksBlockUNUSED : STextValuePairBlocksBlockUNUSEDBase
    {
        public  STextValuePairBlocksBlockUNUSED(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class STextValuePairBlocksBlockUNUSEDBase  : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal STextValuePairReferenceBlockUNUSED[] textValuePairs;
        internal  STextValuePairBlocksBlockUNUSEDBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            textValuePairs = Guerilla.ReadBlockArray<STextValuePairReferenceBlockUNUSED>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<STextValuePairReferenceBlockUNUSED>(binaryWriter, textValuePairs, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
