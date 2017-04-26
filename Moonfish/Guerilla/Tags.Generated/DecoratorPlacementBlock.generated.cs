//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("decorator_placement_block")]
    public partial class DecoratorPlacementBlock : GuerillaBlock, IWriteDeferrable
    {
        public int InternalData1;
        public int CompressedPosition;
        public Moonfish.Tags.ColourR1G1B1 TintColor;
        public Moonfish.Tags.ColourR1G1B1 LightmapColor;
        public int CompressedLightDirection;
        public int CompressedLight2Direction;
        public override int SerializedSize
        {
            get
            {
                return 22;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.InternalData1 = binaryReader.ReadInt32();
            this.CompressedPosition = binaryReader.ReadInt32();
            this.TintColor = binaryReader.ReadColourR1G1B1();
            this.LightmapColor = binaryReader.ReadColourR1G1B1();
            this.CompressedLightDirection = binaryReader.ReadInt32();
            this.CompressedLight2Direction = binaryReader.ReadInt32();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.InternalData1);
            queueableBinaryWriter.Write(this.CompressedPosition);
            queueableBinaryWriter.Write(this.TintColor);
            queueableBinaryWriter.Write(this.LightmapColor);
            queueableBinaryWriter.Write(this.CompressedLightDirection);
            queueableBinaryWriter.Write(this.CompressedLight2Direction);
        }
    }
}
