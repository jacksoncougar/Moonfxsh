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
    [LayoutAttribute(Size = 20)]
    public class STextValuePairReferenceBlockUNUSEDBase
    {
        internal ValueType valueType;
        internal BooleanValue booleanValue;
        internal int integerValue;
        internal float fpValue;
        internal Moonfish.Tags.StringID textValueStringId;
        internal Moonfish.Tags.StringID textLabelStringId;
        internal  STextValuePairReferenceBlockUNUSEDBase(BinaryReader binaryReader)
        {
            this.valueType = (ValueType)binaryReader.ReadInt16();
            this.booleanValue = (BooleanValue)binaryReader.ReadInt16();
            this.integerValue = binaryReader.ReadInt32();
            this.fpValue = binaryReader.ReadSingle();
            this.textValueStringId = binaryReader.ReadStringID();
            this.textLabelStringId = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
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
