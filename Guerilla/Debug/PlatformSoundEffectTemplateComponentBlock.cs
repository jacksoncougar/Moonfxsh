// ReSharper disable All
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
        public  PlatformSoundEffectTemplateComponentBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PlatformSoundEffectTemplateComponentBlockBase(System.IO.BinaryReader binaryReader)
        {
            valueType = (ValueType)binaryReader.ReadInt32();
            defaultValue = binaryReader.ReadSingle();
            minimumValue = binaryReader.ReadSingle();
            maximumValue = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32)valueType);
                binaryWriter.Write(defaultValue);
                binaryWriter.Write(minimumValue);
                binaryWriter.Write(maximumValue);
            }
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
