using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalWeatherBackgroundPlateBlock : GlobalWeatherBackgroundPlateBlockBase
    {
        public  GlobalWeatherBackgroundPlateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 936)]
    public class GlobalWeatherBackgroundPlateBlockBase
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
        internal Moonfish.Tags.ColorR8G8B8 tintColor0;
        internal Moonfish.Tags.ColorR8G8B8 tintColor1;
        internal Moonfish.Tags.ColorR8G8B8 tintColor2;
        internal float mass1;
        internal float mass2;
        internal float mass3;
        internal byte[] invalidName_;
        internal  GlobalWeatherBackgroundPlateBlockBase(BinaryReader binaryReader)
        {
            this.texture0 = binaryReader.ReadTagReference();
            this.texture1 = binaryReader.ReadTagReference();
            this.texture2 = binaryReader.ReadTagReference();
            this.platePositions0 = binaryReader.ReadSingle();
            this.platePositions1 = binaryReader.ReadSingle();
            this.platePositions2 = binaryReader.ReadSingle();
            this.moveSpeed0 = binaryReader.ReadVector3();
            this.moveSpeed1 = binaryReader.ReadVector3();
            this.moveSpeed2 = binaryReader.ReadVector3();
            this.textureScale0 = binaryReader.ReadSingle();
            this.textureScale1 = binaryReader.ReadSingle();
            this.textureScale2 = binaryReader.ReadSingle();
            this.jitter0 = binaryReader.ReadVector3();
            this.jitter1 = binaryReader.ReadVector3();
            this.jitter2 = binaryReader.ReadVector3();
            this.plateZNear = binaryReader.ReadSingle();
            this.plateZFar = binaryReader.ReadSingle();
            this.depthBlendZNear = binaryReader.ReadSingle();
            this.depthBlendZFar = binaryReader.ReadSingle();
            this.opacity0 = binaryReader.ReadSingle();
            this.opacity1 = binaryReader.ReadSingle();
            this.opacity2 = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.tintColor0 = binaryReader.ReadColorR8G8B8();
            this.tintColor1 = binaryReader.ReadColorR8G8B8();
            this.tintColor2 = binaryReader.ReadColorR8G8B8();
            this.mass1 = binaryReader.ReadSingle();
            this.mass2 = binaryReader.ReadSingle();
            this.mass3 = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(736);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
