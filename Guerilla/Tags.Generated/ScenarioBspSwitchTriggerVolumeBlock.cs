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
    public partial class ScenarioBspSwitchTriggerVolumeBlock : ScenarioBspSwitchTriggerVolumeBlockBase
    {
        public ScenarioBspSwitchTriggerVolumeBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 14, Alignment = 4)]
    public class ScenarioBspSwitchTriggerVolumeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal short source;
        internal short destination;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        public override int SerializedSize { get { return 14; } }
        public override int Alignment { get { return 4; } }
        public ScenarioBspSwitchTriggerVolumeBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            triggerVolume = binaryReader.ReadShortBlockIndex1();
            source = binaryReader.ReadInt16();
            destination = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(triggerVolume);
                binaryWriter.Write(source);
                binaryWriter.Write(destination);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 2);
                return nextAddress;
            }
        }
    };
}
