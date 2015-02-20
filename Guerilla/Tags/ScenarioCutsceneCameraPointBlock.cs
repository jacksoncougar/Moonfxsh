using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioCutsceneCameraPointBlock : ScenarioCutsceneCameraPointBlockBase
    {
        public  ScenarioCutsceneCameraPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class ScenarioCutsceneCameraPointBlockBase
    {
        internal Flags flags;
        internal Type type;
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 orientation;
        internal float unused;
        internal  ScenarioCutsceneCameraPointBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.type = (Type)binaryReader.ReadInt16();
            this.name = binaryReader.ReadString32();
            this.position = binaryReader.ReadVector3();
            this.orientation = binaryReader.ReadVector3();
            this.unused = binaryReader.ReadSingle();
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            EditAsRelative = 1,
        };
        internal enum Type : short
        
        {
            Normal = 0,
            IgnoreTargetOrientation = 1,
            Dolly = 2,
            IgnoreTargetUpdates = 3,
        };
    };
}
