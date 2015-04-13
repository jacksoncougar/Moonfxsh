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
        public static readonly TagClass McsrClass = (TagClass)"mcsr";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mcsr")]
    public  partial class MouseCursorDefinitionBlock : MouseCursorDefinitionBlockBase
    {
        public  MouseCursorDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MouseCursorDefinitionBlockBase  : IGuerilla
    {
        internal MouseCursorBitmapReferenceBlock[] mouseCursorBitmaps;
        internal float animationSpeedFps;
        internal  MouseCursorDefinitionBlockBase(BinaryReader binaryReader)
        {
            mouseCursorBitmaps = Guerilla.ReadBlockArray<MouseCursorBitmapReferenceBlock>(binaryReader);
            animationSpeedFps = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<MouseCursorBitmapReferenceBlock>(binaryWriter, mouseCursorBitmaps, nextAddress);
                binaryWriter.Write(animationSpeedFps);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
