// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiModelSceneReferenceBlock : UiModelSceneReferenceBlockBase
    {
        public  UiModelSceneReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UiModelSceneReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 76, Alignment = 4)]
    public class UiModelSceneReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal AnimationIndex animationIndex;
        internal short introAnimationDelayMilliseconds;
        internal short renderDepthBias;
        internal byte[] invalidName_;
        internal UiObjectReferenceBlock[] objects;
        internal UiLightReferenceBlock[] lights;
        internal OpenTK.Vector3 animationScaleFactor;
        internal OpenTK.Vector3 cameraPosition;
        internal float fovDegress;
        internal OpenTK.Vector2 uiViewport;
        internal Moonfish.Tags.StringID uNUSEDIntroAnim;
        internal Moonfish.Tags.StringID uNUSEDOutroAnim;
        internal Moonfish.Tags.StringID uNUSEDAmbientAnim;
        
        public override int SerializedSize{get { return 76; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UiModelSceneReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            introAnimationDelayMilliseconds = binaryReader.ReadInt16();
            renderDepthBias = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            objects = Guerilla.ReadBlockArray<UiObjectReferenceBlock>(binaryReader);
            lights = Guerilla.ReadBlockArray<UiLightReferenceBlock>(binaryReader);
            animationScaleFactor = binaryReader.ReadVector3();
            cameraPosition = binaryReader.ReadVector3();
            fovDegress = binaryReader.ReadSingle();
            uiViewport = binaryReader.ReadVector2();
            uNUSEDIntroAnim = binaryReader.ReadStringID();
            uNUSEDOutroAnim = binaryReader.ReadStringID();
            uNUSEDAmbientAnim = binaryReader.ReadStringID();
        }
        public  UiModelSceneReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)animationIndex);
                binaryWriter.Write(introAnimationDelayMilliseconds);
                binaryWriter.Write(renderDepthBias);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<UiObjectReferenceBlock>(binaryWriter, objects, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UiLightReferenceBlock>(binaryWriter, lights, nextAddress);
                binaryWriter.Write(animationScaleFactor);
                binaryWriter.Write(cameraPosition);
                binaryWriter.Write(fovDegress);
                binaryWriter.Write(uiViewport);
                binaryWriter.Write(uNUSEDIntroAnim);
                binaryWriter.Write(uNUSEDOutroAnim);
                binaryWriter.Write(uNUSEDAmbientAnim);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
        };
        internal enum AnimationIndex : short
        {
            NONE = 0,
            InvalidName00 = 1,
            InvalidName01 = 2,
            InvalidName02 = 3,
            InvalidName03 = 4,
            InvalidName04 = 5,
            InvalidName05 = 6,
            InvalidName06 = 7,
            InvalidName07 = 8,
            InvalidName08 = 9,
            InvalidName09 = 10,
            InvalidName10 = 11,
            InvalidName11 = 12,
            InvalidName12 = 13,
            InvalidName13 = 14,
            InvalidName14 = 15,
            InvalidName15 = 16,
            InvalidName16 = 17,
            InvalidName17 = 18,
            InvalidName18 = 19,
            InvalidName19 = 20,
            InvalidName20 = 21,
            InvalidName21 = 22,
            InvalidName22 = 23,
            InvalidName23 = 24,
            InvalidName24 = 25,
            InvalidName25 = 26,
            InvalidName26 = 27,
            InvalidName27 = 28,
            InvalidName28 = 29,
            InvalidName29 = 30,
            InvalidName30 = 31,
            InvalidName31 = 32,
            InvalidName32 = 33,
            InvalidName33 = 34,
            InvalidName34 = 35,
            InvalidName35 = 36,
            InvalidName36 = 37,
            InvalidName37 = 38,
            InvalidName38 = 39,
            InvalidName39 = 40,
            InvalidName40 = 41,
            InvalidName41 = 42,
            InvalidName42 = 43,
            InvalidName43 = 44,
            InvalidName44 = 45,
            InvalidName45 = 46,
            InvalidName46 = 47,
            InvalidName47 = 48,
            InvalidName48 = 49,
            InvalidName49 = 50,
            InvalidName50 = 51,
            InvalidName51 = 52,
            InvalidName52 = 53,
            InvalidName53 = 54,
            InvalidName54 = 55,
            InvalidName55 = 56,
            InvalidName56 = 57,
            InvalidName57 = 58,
            InvalidName58 = 59,
            InvalidName59 = 60,
            InvalidName60 = 61,
            InvalidName61 = 62,
            InvalidName62 = 63,
            InvalidName63 = 64,
        };
    };
}
