// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiScriptReferenceBlock : AiScriptReferenceBlockBase
    {
        public  AiScriptReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiScriptReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class AiScriptReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 scriptName;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiScriptReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            scriptName = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
        }
        public  AiScriptReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scriptName);
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress;
            }
        }
    };
}
