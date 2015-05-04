// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioTriggerVolumeBlock : ScenarioTriggerVolumeBlockBase
    {
        public ScenarioTriggerVolumeBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class ScenarioTriggerVolumeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Moonfish.Tags.ShortBlockIndex1 objectName;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent nodeName;
        internal EMPTYSTRING[] eMPTYSTRING;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 extents;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 killTriggerVolume;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 68; } }
        public override int Alignment { get { return 4; } }
        public ScenarioTriggerVolumeBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            objectName = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            nodeName = binaryReader.ReadStringID();
            eMPTYSTRING = new []{ new EMPTYSTRING(), new EMPTYSTRING(), new EMPTYSTRING(), new EMPTYSTRING(), new EMPTYSTRING(), new EMPTYSTRING() };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(eMPTYSTRING[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(eMPTYSTRING[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(eMPTYSTRING[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(eMPTYSTRING[3].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(eMPTYSTRING[4].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(eMPTYSTRING[5].ReadFields(binaryReader)));
            position = binaryReader.ReadVector3();
            extents = binaryReader.ReadVector3();
            invalidName_0 = binaryReader.ReadBytes(4);
            killTriggerVolume = binaryReader.ReadShortBlockIndex1();
            invalidName_1 = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            eMPTYSTRING = ReadBlockArrayData<EMPTYSTRING>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(objectName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(nodeName);
                eMPTYSTRING[0].Write(binaryWriter);
                eMPTYSTRING[1].Write(binaryWriter);
                eMPTYSTRING[2].Write(binaryWriter);
                eMPTYSTRING[3].Write(binaryWriter);
                eMPTYSTRING[4].Write(binaryWriter);
                eMPTYSTRING[5].Write(binaryWriter);
                binaryWriter.Write(position);
                binaryWriter.Write(extents);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(killTriggerVolume);
                binaryWriter.Write(invalidName_1, 0, 2);
                return nextAddress;
            }
        }
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class EMPTYSTRING : GuerillaBlock
        {
            internal float eMPTYSTRING;
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
            public EMPTYSTRING() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                eMPTYSTRING = binaryReader.ReadSingle();
                return blamPointers;
            }
            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }
            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(eMPTYSTRING);
                    return nextAddress;
                }
            }
        };
    };
}
