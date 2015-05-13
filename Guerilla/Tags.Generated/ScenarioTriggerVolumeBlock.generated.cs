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
    
    public partial class ScenarioTriggerVolumeBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public Moonfish.Tags.ShortBlockIndex1 ObjectName;
        private byte[] fieldskip = new byte[2];
        public Moonfish.Tags.StringIdent NodeName;
        public EMPTYSTRINGBlock[] EMPTYSTRING00 = new EMPTYSTRINGBlock[6];
        public OpenTK.Vector3 Position;
        public OpenTK.Vector3 Extents;
        private byte[] fieldpad = new byte[4];
        public Moonfish.Tags.ShortBlockIndex1 KillTriggerVolume;
        private byte[] fieldpad0 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 68;
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
            this.Name = binaryReader.ReadStringID();
            this.ObjectName = binaryReader.ReadShortBlockIndex1();
            this.fieldskip = binaryReader.ReadBytes(2);
            this.NodeName = binaryReader.ReadStringID();
            int i;
            for (i = 0; (i < 6); i = (i + 1))
            {
                this.EMPTYSTRING00[i] = new EMPTYSTRINGBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.EMPTYSTRING00[i].ReadFields(binaryReader)));
            }
            this.Position = binaryReader.ReadVector3();
            this.Extents = binaryReader.ReadVector3();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.KillTriggerVolume = binaryReader.ReadShortBlockIndex1();
            this.fieldpad0 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            int i;
            for (i = 0; (i < 6); i = (i + 1))
            {
                this.EMPTYSTRING00[i].ReadInstances(binaryReader, pointerQueue);
            }
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            int i;
            for (i = 0; (i < 6); i = (i + 1))
            {
                this.EMPTYSTRING00[i].QueueWrites(queueableBinaryWriter);
            }
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.ObjectName);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.NodeName);
            int i;
            for (i = 0; (i < 6); i = (i + 1))
            {
                this.EMPTYSTRING00[i].Write_(queueableBinaryWriter);
            }
            queueableBinaryWriter.Write(this.Position);
            queueableBinaryWriter.Write(this.Extents);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.KillTriggerVolume);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
        public class EMPTYSTRINGBlock : GuerillaBlock, IWriteQueueable
        {
            public float EMPTYSTRING;
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
                    return 1;
                }
            }
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.EMPTYSTRING = binaryReader.ReadSingle();
                return pointerQueue;
            }
            public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
            {
                base.ReadInstances(binaryReader, pointerQueue);
            }
            public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
            {
                base.QueueWrites(queueableBinaryWriter);
            }
            public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
            {
                base.Write_(queueableBinaryWriter);
                queueableBinaryWriter.Write(this.EMPTYSTRING);
            }
        }
    }
}
