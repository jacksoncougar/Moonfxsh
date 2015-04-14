// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class STextValuePairReferenceBlockUNUSED : STextValuePairReferenceBlockUNUSEDBase
    {
        public  STextValuePairReferenceBlockUNUSED(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class STextValuePairReferenceBlockUNUSEDBase  : IGuerilla
    {
        internal ValueType valueType;
        internal BooleanValue booleanValue;
        internal int integerValue;
        internal float fpValue;
        internal Moonfish.Tags.StringID textValueStringId;
        internal Moonfish.Tags.StringID textLabelStringId;
        internal  STextValuePairReferenceBlockUNUSEDBase(BinaryReader binaryReader)
        {
            valueType = (ValueType)binaryReader.ReadInt16();
            booleanValue = (BooleanValue)binaryReader.ReadInt16();
            integerValue = binaryReader.ReadInt32();
            fpValue = binaryReader.ReadSingle();
            textValueStringId = binaryReader.ReadStringID();
            textLabelStringId = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)valueType);
                binaryWriter.Write((Int16)booleanValue);
                binaryWriter.Write(integerValue);
                binaryWriter.Write(fpValue);
                binaryWriter.Write(textValueStringId);
                binaryWriter.Write(textLabelStringId);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum ValueType : short
        {
            IntegerNumber = 0,
            FloatingPointNumber = 1,
            Boolean = 2,
            TextString = 3,
        };
        internal enum BooleanValue : short
        {
            FALSE = 0,
            TRUE = 1,
        };
    };
}
