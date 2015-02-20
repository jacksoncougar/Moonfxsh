using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioCutsceneFlagBlock : ScenarioCutsceneFlagBlockBase
    {
        public  ScenarioCutsceneFlagBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class ScenarioCutsceneFlagBlockBase
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector2 facing;
        internal  ScenarioCutsceneFlagBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.name = binaryReader.ReadString32();
            this.position = binaryReader.ReadVector3();
            this.facing = binaryReader.ReadVector2();
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
}
