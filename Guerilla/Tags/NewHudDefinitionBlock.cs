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
        public static readonly TagClass NhdtClass = (TagClass)"nhdt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("nhdt")]
    public  partial class NewHudDefinitionBlock : NewHudDefinitionBlockBase
    {
        public  NewHudDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class NewHudDefinitionBlockBase  : IGuerilla
    {
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference dONOTUSE;
        internal HudBitmapWidgets[] bitmapWidgets;
        internal HudTextWidgets[] textWidgets;
        internal NewHudDashlightDataStructBlock dashlightData;
        internal HudScreenEffectWidgets[] screenEffectWidgets;
        internal  NewHudDefinitionBlockBase(BinaryReader binaryReader)
        {
            dONOTUSE = binaryReader.ReadTagReference();
            bitmapWidgets = Guerilla.ReadBlockArray<HudBitmapWidgets>(binaryReader);
            textWidgets = Guerilla.ReadBlockArray<HudTextWidgets>(binaryReader);
            dashlightData = new NewHudDashlightDataStructBlock(binaryReader);
            screenEffectWidgets = Guerilla.ReadBlockArray<HudScreenEffectWidgets>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dONOTUSE);
                Guerilla.WriteBlockArray<HudBitmapWidgets>(binaryWriter, bitmapWidgets, nextAddress);
                Guerilla.WriteBlockArray<HudTextWidgets>(binaryWriter, textWidgets, nextAddress);
                dashlightData.Write(binaryWriter);
                Guerilla.WriteBlockArray<HudScreenEffectWidgets>(binaryWriter, screenEffectWidgets, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
