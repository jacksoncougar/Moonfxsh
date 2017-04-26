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
    using Moonfish.Guerilla;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("shader_postprocess_implementation_new_block")]
    public partial class ShaderPostprocessImplementationNewBlock : GuerillaBlock, IWriteDeferrable
    {
        public TagBlockIndexStructBlock BitmapTransforms = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock RenderStates = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock TextureStates = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock PixelConstants = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock VertexConstants = new TagBlockIndexStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 10;
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
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.BitmapTransforms.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.RenderStates.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.TextureStates.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.PixelConstants.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.VertexConstants.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.BitmapTransforms.ReadInstances(binaryReader, pointerQueue);
            this.RenderStates.ReadInstances(binaryReader, pointerQueue);
            this.TextureStates.ReadInstances(binaryReader, pointerQueue);
            this.PixelConstants.ReadInstances(binaryReader, pointerQueue);
            this.VertexConstants.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.DeferReferences(writer);
            this.BitmapTransforms.DeferReferences(writer);
            this.RenderStates.DeferReferences(writer);
            this.TextureStates.DeferReferences(writer);
            this.PixelConstants.DeferReferences(writer);
            this.VertexConstants.DeferReferences(writer);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.Write(writer);
            this.BitmapTransforms.Write(writer);
            this.RenderStates.Write(writer);
            this.TextureStates.Write(writer);
            this.PixelConstants.Write(writer);
            this.VertexConstants.Write(writer);
        }
    }
}
