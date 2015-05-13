//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class GlobalWaterDefinitionsBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference Shader;
        public WaterGeometrySectionBlock[] Section = new WaterGeometrySectionBlock[0];
        public GlobalGeometryBlockInfoStructBlock GeometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
        public Moonfish.Tags.ColourR8G8B8 SunSpotColor;
        public Moonfish.Tags.ColourR8G8B8 ReflectionTint;
        public Moonfish.Tags.ColourR8G8B8 RefractionTint;
        public Moonfish.Tags.ColourR8G8B8 HorizonColor;
        public float SunSpecularPower;
        public float ReflectionBumpScale;
        public float RefractionBumpScale;
        public float FresnelScale;
        public float SunDirHeading;
        public float SunDirPitch;
        public float FOV;
        public float Aspect;
        public float Height;
        public float Farz;
        public float RotateOffset;
        public OpenTK.Vector2 Center;
        public OpenTK.Vector2 Extents;
        public float FogNear;
        public float FogFar;
        public float DynamicHeightBias;
        public override int SerializedSize
        {
            get
            {
                return 172;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Shader = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(68));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GeometryBlockInfo.ReadFields(binaryReader)));
            this.SunSpotColor = binaryReader.ReadColorR8G8B8();
            this.ReflectionTint = binaryReader.ReadColorR8G8B8();
            this.RefractionTint = binaryReader.ReadColorR8G8B8();
            this.HorizonColor = binaryReader.ReadColorR8G8B8();
            this.SunSpecularPower = binaryReader.ReadSingle();
            this.ReflectionBumpScale = binaryReader.ReadSingle();
            this.RefractionBumpScale = binaryReader.ReadSingle();
            this.FresnelScale = binaryReader.ReadSingle();
            this.SunDirHeading = binaryReader.ReadSingle();
            this.SunDirPitch = binaryReader.ReadSingle();
            this.FOV = binaryReader.ReadSingle();
            this.Aspect = binaryReader.ReadSingle();
            this.Height = binaryReader.ReadSingle();
            this.Farz = binaryReader.ReadSingle();
            this.RotateOffset = binaryReader.ReadSingle();
            this.Center = binaryReader.ReadVector2();
            this.Extents = binaryReader.ReadVector2();
            this.FogNear = binaryReader.ReadSingle();
            this.FogFar = binaryReader.ReadSingle();
            this.DynamicHeightBias = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Section = base.ReadBlockArrayData<WaterGeometrySectionBlock>(binaryReader, pointerQueue.Dequeue());
            this.GeometryBlockInfo.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Section);
            this.GeometryBlockInfo.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Shader);
            queueableBinaryWriter.WritePointer(this.Section);
            this.GeometryBlockInfo.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.SunSpotColor);
            queueableBinaryWriter.Write(this.ReflectionTint);
            queueableBinaryWriter.Write(this.RefractionTint);
            queueableBinaryWriter.Write(this.HorizonColor);
            queueableBinaryWriter.Write(this.SunSpecularPower);
            queueableBinaryWriter.Write(this.ReflectionBumpScale);
            queueableBinaryWriter.Write(this.RefractionBumpScale);
            queueableBinaryWriter.Write(this.FresnelScale);
            queueableBinaryWriter.Write(this.SunDirHeading);
            queueableBinaryWriter.Write(this.SunDirPitch);
            queueableBinaryWriter.Write(this.FOV);
            queueableBinaryWriter.Write(this.Aspect);
            queueableBinaryWriter.Write(this.Height);
            queueableBinaryWriter.Write(this.Farz);
            queueableBinaryWriter.Write(this.RotateOffset);
            queueableBinaryWriter.Write(this.Center);
            queueableBinaryWriter.Write(this.Extents);
            queueableBinaryWriter.Write(this.FogNear);
            queueableBinaryWriter.Write(this.FogFar);
            queueableBinaryWriter.Write(this.DynamicHeightBias);
        }
    }
}
