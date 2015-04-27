// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundPlaybackParameterDefinitionBlock : SoundPlaybackParameterDefinitionBlockBase
    {
        public  SoundPlaybackParameterDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundPlaybackParameterDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundPlaybackParameterDefinitionBlockBase : GuerillaBlock
    {
        internal Moonfish.Model.Range scaleBounds;
        internal Moonfish.Model.Range randomBaseAndVariance;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundPlaybackParameterDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            scaleBounds = binaryReader.ReadRange();
            randomBaseAndVariance = binaryReader.ReadRange();
        }
        public  SoundPlaybackParameterDefinitionBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scaleBounds);
                binaryWriter.Write(randomBaseAndVariance);
                return nextAddress;
            }
        }
    };
}
