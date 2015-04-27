// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RegionsBlock : RegionsBlockBase
    {
        public  RegionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RegionsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class RegionsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal PermutationsBlock[] permutations;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RegionsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            permutations = Guerilla.ReadBlockArray<PermutationsBlock>(binaryReader);
        }
        public  RegionsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<PermutationsBlock>(binaryWriter, permutations, nextAddress);
                return nextAddress;
            }
        }
    };
}
