// ReSharper disable All
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
        public  ScenarioCutsceneCameraPointBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioCutsceneCameraPointBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            type = (Type)binaryReader.ReadInt16();
            name = binaryReader.ReadString32();
            position = binaryReader.ReadVector3();
            orientation = binaryReader.ReadVector3();
            unused = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(name);
                binaryWriter.Write(position);
                binaryWriter.Write(orientation);
                binaryWriter.Write(unused);
            }
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
