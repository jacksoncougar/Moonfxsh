// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiErrorCategoryBlock : UiErrorCategoryBlockBase
    {
        public  UiErrorCategoryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UiErrorCategoryBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class UiErrorCategoryBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent categoryName;
        internal Flags flags;
        internal DefaultButton defaultButton;
        internal byte[] invalidName_;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference stringTag;
        internal Moonfish.Tags.StringIdent defaultTitle;
        internal Moonfish.Tags.StringIdent defaultMessage;
        internal Moonfish.Tags.StringIdent defaultOk;
        internal Moonfish.Tags.StringIdent defaultCancel;
        internal UiErrorBlock[] errorBlock;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UiErrorCategoryBlockBase(BinaryReader binaryReader): base(binaryReader)
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
            errorBlock = Guerilla.ReadBlockArray<UiErrorBlock>(binaryReader);
        }
        public  UiErrorCategoryBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
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
            errorBlock = Guerilla.ReadBlockArray<UiErrorBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteBlockArray<UiErrorBlock>(binaryWriter, errorBlock, nextAddress);
                return nextAddress;
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
