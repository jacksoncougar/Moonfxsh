using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalHudMultitextureOverlayDefinition : GlobalHudMultitextureOverlayDefinitionBase
    {
        public  GlobalHudMultitextureOverlayDefinition(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 452)]
    public class GlobalHudMultitextureOverlayDefinitionBase
    {
        internal byte[] invalidName_;
        internal short type;
        internal FramebufferBlendFunc framebufferBlendFunc;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal PrimaryAnchor primaryAnchor;
        internal SecondaryAnchor secondaryAnchor;
        internal TertiaryAnchor tertiaryAnchor;
        internal InvalidName0To1BlendFunc invalidName_0To1BlendFunc;
        internal InvalidName1To2BlendFunc invalidName_1To2BlendFunc;
        internal byte[] invalidName_2;
        internal OpenTK.Vector2 primaryScale;
        internal OpenTK.Vector2 secondaryScale;
        internal OpenTK.Vector2 tertiaryScale;
        internal OpenTK.Vector2 primaryOffset;
        internal OpenTK.Vector2 secondaryOffset;
        internal OpenTK.Vector2 tertiaryOffset;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference primary;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference secondary;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference tertiary;
        internal PrimaryWrapMode primaryWrapMode;
        internal SecondaryWrapMode secondaryWrapMode;
        internal TertiaryWrapMode tertiaryWrapMode;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal GlobalHudMultitextureOverlayEffectorDefinition[] effectors;
        internal byte[] invalidName_5;
        internal  GlobalHudMultitextureOverlayDefinitionBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.type = binaryReader.ReadInt16();
            this.framebufferBlendFunc = (FramebufferBlendFunc)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(32);
            this.primaryAnchor = (PrimaryAnchor)binaryReader.ReadInt16();
            this.secondaryAnchor = (SecondaryAnchor)binaryReader.ReadInt16();
            this.tertiaryAnchor = (TertiaryAnchor)binaryReader.ReadInt16();
            this.invalidName_0To1BlendFunc = (InvalidName0To1BlendFunc)binaryReader.ReadInt16();
            this.invalidName_1To2BlendFunc = (InvalidName1To2BlendFunc)binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.primaryScale = binaryReader.ReadVector2();
            this.secondaryScale = binaryReader.ReadVector2();
            this.tertiaryScale = binaryReader.ReadVector2();
            this.primaryOffset = binaryReader.ReadVector2();
            this.secondaryOffset = binaryReader.ReadVector2();
            this.tertiaryOffset = binaryReader.ReadVector2();
            this.primary = binaryReader.ReadTagReference();
            this.secondary = binaryReader.ReadTagReference();
            this.tertiary = binaryReader.ReadTagReference();
            this.primaryWrapMode = (PrimaryWrapMode)binaryReader.ReadInt16();
            this.secondaryWrapMode = (SecondaryWrapMode)binaryReader.ReadInt16();
            this.tertiaryWrapMode = (TertiaryWrapMode)binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.invalidName_4 = binaryReader.ReadBytes(184);
            this.effectors = ReadGlobalHudMultitextureOverlayEffectorDefinitionArray(binaryReader);
            this.invalidName_5 = binaryReader.ReadBytes(128);
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
        internal  virtual GlobalHudMultitextureOverlayEffectorDefinition[] ReadGlobalHudMultitextureOverlayEffectorDefinitionArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalHudMultitextureOverlayEffectorDefinition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalHudMultitextureOverlayEffectorDefinition[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalHudMultitextureOverlayEffectorDefinition(binaryReader);
                }
            }
            return array;
        }
        internal enum FramebufferBlendFunc : short
        
        {
            AlphaBlend = 0,
            Multiply = 1,
            DoubleMultiply = 2,
            Add = 3,
            Subtract = 4,
            ComponentMin = 5,
            ComponentMax = 6,
            AlphaMultiplyAdd = 7,
            ConstantColorBlend = 8,
            InverseConstantColorBlend = 9,
            None = 10,
        };
        internal enum PrimaryAnchor : short
        
        {
            Texture = 0,
            Screen = 1,
        };
        internal enum SecondaryAnchor : short
        
        {
            Texture = 0,
            Screen = 1,
        };
        internal enum TertiaryAnchor : short
        
        {
            Texture = 0,
            Screen = 1,
        };
        internal enum InvalidName0To1BlendFunc : short
        
        {
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Multiply2x = 3,
            Dot = 4,
        };
        internal enum InvalidName1To2BlendFunc : short
        
        {
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Multiply2x = 3,
            Dot = 4,
        };
        internal enum PrimaryWrapMode : short
        
        {
            Clamp = 0,
            Wrap = 1,
        };
        internal enum SecondaryWrapMode : short
        
        {
            Clamp = 0,
            Wrap = 1,
        };
        internal enum TertiaryWrapMode : short
        
        {
            Clamp = 0,
            Wrap = 1,
        };
    };
}
