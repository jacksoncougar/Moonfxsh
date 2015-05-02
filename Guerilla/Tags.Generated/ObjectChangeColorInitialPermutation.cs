// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ObjectChangeColorInitialPermutation : ObjectChangeColorInitialPermutationBase
    {
        public  ObjectChangeColorInitialPermutation(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ObjectChangeColorInitialPermutation(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ObjectChangeColorInitialPermutationBase : GuerillaBlock
    {
        internal float weight;
        internal Moonfish.Tags.ColourR8G8B8 ColourLowerBound;
        internal Moonfish.Tags.ColourR8G8B8 ColourUpperBound;
        /// <summary>
        /// if empty, may be used by any model variant
        /// </summary>
        internal Moonfish.Tags.StringIdent variantName;
        
        public override int SerializedSize{get { return 32; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ObjectChangeColorInitialPermutationBase(BinaryReader binaryReader): base(binaryReader)
        {
            weight = binaryReader.ReadSingle();
            ColourLowerBound = binaryReader.ReadColorR8G8B8();
            ColourUpperBound = binaryReader.ReadColorR8G8B8();
            variantName = binaryReader.ReadStringID();
        }
        public  ObjectChangeColorInitialPermutationBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            weight = binaryReader.ReadSingle();
            ColourLowerBound = binaryReader.ReadColorR8G8B8();
            ColourUpperBound = binaryReader.ReadColorR8G8B8();
            variantName = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weight);
                binaryWriter.Write(ColourLowerBound);
                binaryWriter.Write(ColourUpperBound);
                binaryWriter.Write(variantName);
                return nextAddress;
            }
        }
    };
}
