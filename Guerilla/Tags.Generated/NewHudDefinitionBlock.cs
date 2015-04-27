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
        public static readonly TagClass Nhdt = (TagClass)"nhdt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("nhdt")]
    public partial class NewHudDefinitionBlock : NewHudDefinitionBlockBase
    {
        public  NewHudDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  NewHudDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class NewHudDefinitionBlockBase : GuerillaBlock
    {
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference dONOTUSE;
        internal HudBitmapWidgets[] bitmapWidgets;
        internal HudTextWidgets[] textWidgets;
        internal NewHudDashlightDataStructBlock dashlightData;
        internal HudScreenEffectWidgets[] screenEffectWidgets;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  NewHudDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            dONOTUSE = binaryReader.ReadTagReference();
            bitmapWidgets = Guerilla.ReadBlockArray<HudBitmapWidgets>(binaryReader);
            textWidgets = Guerilla.ReadBlockArray<HudTextWidgets>(binaryReader);
            dashlightData = new NewHudDashlightDataStructBlock(binaryReader);
            screenEffectWidgets = Guerilla.ReadBlockArray<HudScreenEffectWidgets>(binaryReader);
        }
        public  NewHudDefinitionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            dONOTUSE = binaryReader.ReadTagReference();
            bitmapWidgets = Guerilla.ReadBlockArray<HudBitmapWidgets>(binaryReader);
            textWidgets = Guerilla.ReadBlockArray<HudTextWidgets>(binaryReader);
            dashlightData = new NewHudDashlightDataStructBlock(binaryReader);
            screenEffectWidgets = Guerilla.ReadBlockArray<HudScreenEffectWidgets>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dONOTUSE);
                nextAddress = Guerilla.WriteBlockArray<HudBitmapWidgets>(binaryWriter, bitmapWidgets, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudTextWidgets>(binaryWriter, textWidgets, nextAddress);
                dashlightData.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<HudScreenEffectWidgets>(binaryWriter, screenEffectWidgets, nextAddress);
                return nextAddress;
            }
        }
    };
}
