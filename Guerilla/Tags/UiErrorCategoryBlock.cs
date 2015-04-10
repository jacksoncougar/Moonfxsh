using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UiErrorCategoryBlock : UiErrorCategoryBlockBase
    {
        public  UiErrorCategoryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class UiErrorCategoryBlockBase
    {
        internal Moonfish.Tags.StringID categoryName;
        internal Flags flags;
        internal DefaultButton defaultButton;
        internal byte[] invalidName_;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference stringTag;
        internal Moonfish.Tags.StringID defaultTitle;
        internal Moonfish.Tags.StringID defaultMessage;
        internal Moonfish.Tags.StringID defaultOk;
        internal Moonfish.Tags.StringID defaultCancel;
        internal UiErrorBlock[] errorBlock;
        internal  UiErrorCategoryBlockBase(BinaryReader binaryReader)
        {
            this.categoryName = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.defaultButton = (DefaultButton)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.stringTag = binaryReader.ReadTagReference();
            this.defaultTitle = binaryReader.ReadStringID();
            this.defaultMessage = binaryReader.ReadStringID();
            this.defaultOk = binaryReader.ReadStringID();
            this.defaultCancel = binaryReader.ReadStringID();
            this.errorBlock = ReadUiErrorBlockArray(binaryReader);
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
        internal  virtual UiErrorBlock[] ReadUiErrorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiErrorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiErrorBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiErrorBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            UseLargeDialog = 1,
        };
        internal enum DefaultButton : byte
        
        {
            NoDefault = 0,
            DefaultOk = 1,
            DefaultCancel = 2,
        };
    };
}
