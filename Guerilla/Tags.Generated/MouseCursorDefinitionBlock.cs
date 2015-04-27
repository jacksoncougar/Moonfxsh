// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mcsr = (TagClass)"mcsr";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mcsr")]
    public partial class MouseCursorDefinitionBlock : MouseCursorDefinitionBlockBase
    {
        public  MouseCursorDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MouseCursorDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MouseCursorDefinitionBlockBase : GuerillaBlock
    {
        internal MouseCursorBitmapReferenceBlock[] mouseCursorBitmaps;
        internal float animationSpeedFps;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MouseCursorDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            mouseCursorBitmaps = Guerilla.ReadBlockArray<MouseCursorBitmapReferenceBlock>(binaryReader);
            animationSpeedFps = binaryReader.ReadSingle();
        }
        public  MouseCursorDefinitionBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MouseCursorBitmapReferenceBlock>(binaryWriter, mouseCursorBitmaps, nextAddress);
                binaryWriter.Write(animationSpeedFps);
                return nextAddress;
            }
        }
    };
}
