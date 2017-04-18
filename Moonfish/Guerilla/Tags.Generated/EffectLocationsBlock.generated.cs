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
    
    public partial class EffectLocationsBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// In addition to the marker in the render model there are several special marker names:
        ///
        ///replace
        ///Replace allows you to use the same effect with different markers. Damage transition effects support this for example.
        ///
        ///gravity, up
        ///The direction of gravity (down) and the opposite direction (up).  Always supplied
        ///
        ///normal
        ///Vector pointing directly away from the surface you collided with. Supplied for effects from collision.
        ///
        ///forward
        ///The 'negative incident' vector i.e. the direction the object is moving in. Most commonly used to generated decals. Supplied for effects from collision.
        ///
        ///backward
        ///The 'incident' vector i.e. the opposite of the direction the object is moving in. Supplied for effects from collision.
        ///
        ///reflection
        ///The way the effect would reflect off the surface it hit. Supplied for effects from collision.
        ///
        ///root
        ///The object root (pivot). These can used for all effects which are associated with an object.
        ///
        ///impact
        ///The location of a havok impact.
        /// </summary>
        public Moonfish.Tags.StringIdent MarkerName;
        public override int SerializedSize
        {
            get
            {
                return 4;
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
            this.MarkerName = binaryReader.ReadStringIdent();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.MarkerName);
        }
    }
}
