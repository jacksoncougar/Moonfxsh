// ReSharper disable All
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
        public  UiErrorCategoryBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  UiErrorCategoryBlockBase(System.IO.BinaryReader binaryReader)
        {
            categoryName = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            defaultButton = (DefaultButton)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            stringTag = binaryReader.ReadTagReference();
            defaultTitle = binaryReader.ReadStringID();
            defaultMessage = binaryReader.ReadStringID();
            defaultOk = binaryReader.ReadStringID();
            defaultCancel = binaryReader.ReadStringID();
            ReadUiErrorBlockArray(binaryReader);
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
        internal  virtual UiErrorBlock[] ReadUiErrorBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiErrorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiErrorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiErrorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUiErrorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(categoryName);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Byte)defaultButton);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(stringTag);
                binaryWriter.Write(defaultTitle);
                binaryWriter.Write(defaultMessage);
                binaryWriter.Write(defaultOk);
                binaryWriter.Write(defaultCancel);
                WriteUiErrorBlockArray(binaryWriter);
            }
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
