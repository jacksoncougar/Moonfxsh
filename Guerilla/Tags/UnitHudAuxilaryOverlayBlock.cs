using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitHudAuxilaryOverlayBlock : UnitHudAuxilaryOverlayBlockBase
    {
        public  UnitHudAuxilaryOverlayBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 120)]
    public class UnitHudAuxilaryOverlayBlockBase
    {
        internal Moonfish.Tags.Point anchorOffset;
        internal float widthScale;
        internal float heightScale;
        internal ScalingFlags scalingFlags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceBitmap;
        internal Moonfish.Tags.ColourA1R1G1B1 defaultColor;
        internal Moonfish.Tags.ColourA1R1G1B1 flashingColor;
        internal float flashPeriod;
        /// <summary>
        /// time between flashes
        /// </summary>
        internal float flashDelay;
        internal short numberOfFlashes;
        internal FlashFlags flashFlags;
        /// <summary>
        /// time of each flash
        /// </summary>
        internal float flashLength;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor;
        internal byte[] invalidName_1;
        internal short sequenceIndex;
        internal byte[] invalidName_2;
        internal GlobalHudMultitextureOverlayDefinition[] multitexOverlay;
        internal byte[] invalidName_3;
        internal Type type;
        internal Flags flags;
        internal byte[] invalidName_4;
        internal  UnitHudAuxilaryOverlayBlockBase(BinaryReader binaryReader)
        {
            this.anchorOffset = binaryReader.ReadPoint();
            this.widthScale = binaryReader.ReadSingle();
            this.heightScale = binaryReader.ReadSingle();
            this.scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(20);
            this.interfaceBitmap = binaryReader.ReadTagReference();
            this.defaultColor = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod = binaryReader.ReadSingle();
            this.flashDelay = binaryReader.ReadSingle();
            this.numberOfFlashes = binaryReader.ReadInt16();
            this.flashFlags = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength = binaryReader.ReadSingle();
            this.disabledColor = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.sequenceIndex = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.multitexOverlay = ReadGlobalHudMultitextureOverlayDefinitionArray(binaryReader);
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_4 = binaryReader.ReadBytes(24);
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
        internal  virtual GlobalHudMultitextureOverlayDefinition[] ReadGlobalHudMultitextureOverlayDefinitionArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalHudMultitextureOverlayDefinition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalHudMultitextureOverlayDefinition[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalHudMultitextureOverlayDefinition(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum ScalingFlags : short
        
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum FlashFlags : short
        
        {
            ReverseDefaultFlashingColors = 1,
        };
        internal enum Type : short
        
        {
            TeamIcon = 0,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            UseTeamColor = 1,
        };
    };
}
