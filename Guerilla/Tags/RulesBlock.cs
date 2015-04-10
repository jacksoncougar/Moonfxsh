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
        public  RulesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  RulesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.tintColor = binaryReader.ReadColorR8G8B8();
            this.invalidName_ = binaryReader.ReadBytes(32);
            this.states = ReadStatesBlockArray(binaryReader);
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
        internal  virtual StatesBlock[] ReadStatesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StatesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StatesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StatesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
