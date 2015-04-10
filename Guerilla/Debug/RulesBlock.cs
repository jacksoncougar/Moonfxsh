// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RulesBlock : RulesBlockBase
    {
        public  RulesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class RulesBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ColorR8G8B8 tintColor;
        internal byte[] invalidName_;
        internal StatesBlock[] states;
        internal  RulesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            tintColor = binaryReader.ReadColorR8G8B8();
            invalidName_ = binaryReader.ReadBytes(32);
            ReadStatesBlockArray(binaryReader);
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
        internal  virtual StatesBlock[] ReadStatesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StatesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StatesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StatesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStatesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(tintColor);
                binaryWriter.Write(invalidName_, 0, 32);
                WriteStatesBlockArray(binaryWriter);
            }
        }
    };
}
