// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mulg = (TagClass)"mulg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mulg")]
    public partial class MultiplayerGlobalsBlock : MultiplayerGlobalsBlockBase
    {
        public  MultiplayerGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MultiplayerGlobalsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MultiplayerGlobalsBlockBase : GuerillaBlock
    {
        internal MultiplayerUniversalBlock[] universal;
        internal MultiplayerRuntimeBlock[] runtime;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MultiplayerGlobalsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            universal = Guerilla.ReadBlockArray<MultiplayerUniversalBlock>(binaryReader);
            runtime = Guerilla.ReadBlockArray<MultiplayerRuntimeBlock>(binaryReader);
        }
        public  MultiplayerGlobalsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            universal = Guerilla.ReadBlockArray<MultiplayerUniversalBlock>(binaryReader);
            runtime = Guerilla.ReadBlockArray<MultiplayerRuntimeBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MultiplayerUniversalBlock>(binaryWriter, universal, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerRuntimeBlock>(binaryWriter, runtime, nextAddress);
                return nextAddress;
            }
        }
    };
}
