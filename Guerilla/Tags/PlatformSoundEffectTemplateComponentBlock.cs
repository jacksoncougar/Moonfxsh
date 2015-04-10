using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectTemplateComponentBlock : PlatformSoundEffectTemplateComponentBlockBase
    {
        public  PlatformSoundEffectTemplateComponentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class PlatformSoundEffectTemplateComponentBlockBase
    {
        internal ValueType valueType;
        internal float defaultValue;
        internal float minimumValue;
        internal float maximumValue;
        internal  PlatformSoundEffectTemplateComponentBlockBase(BinaryReader binaryReader)
        {
            this.valueType = (ValueType)binaryReader.ReadInt32();
            this.defaultValue = binaryReader.ReadSingle();
            this.minimumValue = binaryReader.ReadSingle();
            this.maximumValue = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal enum ValueType : int
        
        {
            Zero = 0,
            Time = 1,
            Scale = 2,
            Rolloff = 3,
        };
    };
}
