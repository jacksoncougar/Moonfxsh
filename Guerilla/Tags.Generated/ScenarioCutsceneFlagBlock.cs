// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioCutsceneFlagBlock : ScenarioCutsceneFlagBlockBase
    {
        public  ScenarioCutsceneFlagBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioCutsceneFlagBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ScenarioCutsceneFlagBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector2 facing;
        
        public override int SerializedSize{get { return 56; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioCutsceneFlagBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            name = binaryReader.ReadString32();
            position = binaryReader.ReadVector3();
            facing = binaryReader.ReadVector2();
        }
        public  ScenarioCutsceneFlagBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            name = binaryReader.ReadString32();
            position = binaryReader.ReadVector3();
            facing = binaryReader.ReadVector2();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(name);
                binaryWriter.Write(position);
                binaryWriter.Write(facing);
                return nextAddress;
            }
        }
    };
}
