using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioTriggerVolumeBlock : ScenarioTriggerVolumeBlockBase
    {
        public  ScenarioTriggerVolumeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68)]
    public class ScenarioTriggerVolumeBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 objectName;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID nodeName;
        internal EMPTYSTRING[] eMPTYSTRING;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 extents;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 killTriggerVolume;
        internal byte[] invalidName_1;
        internal  ScenarioTriggerVolumeBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.objectName = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.nodeName = binaryReader.ReadStringID();
            this.eMPTYSTRING = new []{ new EMPTYSTRING(binaryReader), new EMPTYSTRING(binaryReader), new EMPTYSTRING(binaryReader), new EMPTYSTRING(binaryReader), new EMPTYSTRING(binaryReader), new EMPTYSTRING(binaryReader),  };
            this.position = binaryReader.ReadVector3();
            this.extents = binaryReader.ReadVector3();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.killTriggerVolume = binaryReader.ReadShortBlockIndex1();
            this.invalidName_1 = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        public class EMPTYSTRING
        {
            internal float eMPTYSTRING;
            internal  EMPTYSTRING(BinaryReader binaryReader)
            {
                this.eMPTYSTRING = binaryReader.ReadSingle();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.Count];
                if(blamPointer.Count > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.Count);
                    }
                }
                return data;
            }
        };
    };
}
