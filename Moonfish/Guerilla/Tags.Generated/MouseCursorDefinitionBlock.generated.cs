//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [TagClassAttribute("mcsr")]
    public partial class MouseCursorDefinitionBlock : GuerillaBlock, IWriteDeferrable
    {
        public MouseCursorBitmapReferenceBlock[] MouseCursorBitmaps = new MouseCursorBitmapReferenceBlock[0];
        public float AnimationSpeed;
        public override int SerializedSize
        {
            get
            {
                return 12;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.AnimationSpeed = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            throw new NotImplementedException();
            base.ReadInstances(binaryReader, pointerQueue);
            //this.MouseCursorBitmaps = base.ReadBlockArrayData<MouseCursorBitmapReferenceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter linearBinaryWriter)
        {
            base.DeferReferences(linearBinaryWriter);
            linearBinaryWriter.Defer(this.MouseCursorBitmaps);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter linearBinaryWriter)
        {
            base.Write_(linearBinaryWriter);
            linearBinaryWriter.WritePointer(this.MouseCursorBitmaps);
            linearBinaryWriter.Write(this.AnimationSpeed);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Mcsr = ((TagClass)("mcsr"));
    }
}
