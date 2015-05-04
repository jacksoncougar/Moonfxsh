// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalWeatherBackgroundPlateBlock : GlobalWeatherBackgroundPlateBlockBase
    {
        public  GlobalWeatherBackgroundPlateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalWeatherBackgroundPlateBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 936, Alignment = 4)]
    public class GlobalWeatherBackgroundPlateBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference texture0;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference texture1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference texture2;
        internal float platePositions0;
        internal float platePositions1;
        internal float platePositions2;
        internal OpenTK.Vector3 moveSpeed0;
        internal OpenTK.Vector3 moveSpeed1;
        internal OpenTK.Vector3 moveSpeed2;
        internal float textureScale0;
        internal float textureScale1;
        internal float textureScale2;
        internal OpenTK.Vector3 jitter0;
        internal OpenTK.Vector3 jitter1;
        internal OpenTK.Vector3 jitter2;
        internal float plateZNear;
        internal float plateZFar;
        internal float depthBlendZNear;
        internal float depthBlendZFar;
        internal float opacity0;
        internal float opacity1;
        internal float opacity2;
        internal Flags flags;
        internal Moonfish.Tags.ColourR8G8B8 tintColor0;
        internal Moonfish.Tags.ColourR8G8B8 tintColor1;
        internal Moonfish.Tags.ColourR8G8B8 tintColor2;
        internal float mass1;
        internal float mass2;
        internal float mass3;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 936; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalWeatherBackgroundPlateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            texture0 = binaryReader.ReadTagReference();
            texture1 = binaryReader.ReadTagReference();
            texture2 = binaryReader.ReadTagReference();
            platePositions0 = binaryReader.ReadSingle();
            platePositions1 = binaryReader.ReadSingle();
            platePositions2 = binaryReader.ReadSingle();
            moveSpeed0 = binaryReader.ReadVector3();
            moveSpeed1 = binaryReader.ReadVector3();
            moveSpeed2 = binaryReader.ReadVector3();
            textureScale0 = binaryReader.ReadSingle();
            textureScale1 = binaryReader.ReadSingle();
            textureScale2 = binaryReader.ReadSingle();
            jitter0 = binaryReader.ReadVector3();
            jitter1 = binaryReader.ReadVector3();
            jitter2 = binaryReader.ReadVector3();
            plateZNear = binaryReader.ReadSingle();
            plateZFar = binaryReader.ReadSingle();
            depthBlendZNear = binaryReader.ReadSingle();
            depthBlendZFar = binaryReader.ReadSingle();
            opacity0 = binaryReader.ReadSingle();
            opacity1 = binaryReader.ReadSingle();
            opacity2 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
            tintColor0 = binaryReader.ReadColorR8G8B8();
            tintColor1 = binaryReader.ReadColorR8G8B8();
            tintColor2 = binaryReader.ReadColorR8G8B8();
            mass1 = binaryReader.ReadSingle();
            mass2 = binaryReader.ReadSingle();
            mass3 = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(736);
        }
        public  GlobalWeatherBackgroundPlateBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            texture0 = binaryReader.ReadTagReference();
            texture1 = binaryReader.ReadTagReference();
            texture2 = binaryReader.ReadTagReference();
            platePositions0 = binaryReader.ReadSingle();
            platePositions1 = binaryReader.ReadSingle();
            platePositions2 = binaryReader.ReadSingle();
            moveSpeed0 = binaryReader.ReadVector3();
            moveSpeed1 = binaryReader.ReadVector3();
            moveSpeed2 = binaryReader.ReadVector3();
            textureScale0 = binaryReader.ReadSingle();
            textureScale1 = binaryReader.ReadSingle();
            textureScale2 = binaryReader.ReadSingle();
            jitter0 = binaryReader.ReadVector3();
            jitter1 = binaryReader.ReadVector3();
            jitter2 = binaryReader.ReadVector3();
            plateZNear = binaryReader.ReadSingle();
            plateZFar = binaryReader.ReadSingle();
            depthBlendZNear = binaryReader.ReadSingle();
            depthBlendZFar = binaryReader.ReadSingle();
            opacity0 = binaryReader.ReadSingle();
            opacity1 = binaryReader.ReadSingle();
            opacity2 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
            tintColor0 = binaryReader.ReadColorR8G8B8();
            tintColor1 = binaryReader.ReadColorR8G8B8();
            tintColor2 = binaryReader.ReadColorR8G8B8();
            mass1 = binaryReader.ReadSingle();
            mass2 = binaryReader.ReadSingle();
            mass3 = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(736);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(texture0);
                binaryWriter.Write(texture1);
                binaryWriter.Write(texture2);
                binaryWriter.Write(platePositions0);
                binaryWriter.Write(platePositions1);
                binaryWriter.Write(platePositions2);
                binaryWriter.Write(moveSpeed0);
                binaryWriter.Write(moveSpeed1);
                binaryWriter.Write(moveSpeed2);
                binaryWriter.Write(textureScale0);
                binaryWriter.Write(textureScale1);
                binaryWriter.Write(textureScale2);
                binaryWriter.Write(jitter0);
                binaryWriter.Write(jitter1);
                binaryWriter.Write(jitter2);
                binaryWriter.Write(plateZNear);
                binaryWriter.Write(plateZFar);
                binaryWriter.Write(depthBlendZNear);
                binaryWriter.Write(depthBlendZFar);
                binaryWriter.Write(opacity0);
                binaryWriter.Write(opacity1);
                binaryWriter.Write(opacity2);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(tintColor0);
                binaryWriter.Write(tintColor1);
                binaryWriter.Write(tintColor2);
                binaryWriter.Write(mass1);
                binaryWriter.Write(mass2);
                binaryWriter.Write(mass3);
                binaryWriter.Write(invalidName_, 0, 736);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            ForwardMotion = 1,
            AutoPositionPlanes = 2,
            AutoScalePlanesautoUpdateSpeed = 4,
        };
    };
}
