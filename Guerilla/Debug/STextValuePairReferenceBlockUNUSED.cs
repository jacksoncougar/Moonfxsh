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
        public  STextValuePairReferenceBlockUNUSED(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class STextValuePairReferenceBlockUNUSEDBase
    {
        internal ValueType valueType;
        internal BooleanValue booleanValue;
        internal int integerValue;
        internal float fpValue;
        internal Moonfish.Tags.StringID textValueStringId;
        internal Moonfish.Tags.StringID textLabelStringId;
        internal  STextValuePairReferenceBlockUNUSEDBase(System.IO.BinaryReader binaryReader)
        {
            valueType = (ValueType)binaryReader.ReadInt16();
            booleanValue = (BooleanValue)binaryReader.ReadInt16();
            integerValue = binaryReader.ReadInt32();
            fpValue = binaryReader.ReadSingle();
            textValueStringId = binaryReader.ReadStringID();
            textLabelStringId = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)valueType);
                binaryWriter.Write((Int16)booleanValue);
                binaryWriter.Write(integerValue);
                binaryWriter.Write(fpValue);
                binaryWriter.Write(textValueStringId);
                binaryWriter.Write(textLabelStringId);
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
