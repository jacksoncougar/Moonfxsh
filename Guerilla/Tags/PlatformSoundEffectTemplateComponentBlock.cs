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
        public  PlatformSoundEffectTemplateComponentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PlatformSoundEffectTemplateComponentBlockBase  : IGuerilla
    {
        internal ValueType valueType;
        internal float defaultValue;
        internal float minimumValue;
        internal float maximumValue;
        internal  PlatformSoundEffectTemplateComponentBlockBase(BinaryReader binaryReader)
        {
            valueType = (ValueType)binaryReader.ReadInt32();
            defaultValue = binaryReader.ReadSingle();
            minimumValue = binaryReader.ReadSingle();
            maximumValue = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)valueType);
                binaryWriter.Write(defaultValue);
                binaryWriter.Write(minimumValue);
                binaryWriter.Write(maximumValue);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
