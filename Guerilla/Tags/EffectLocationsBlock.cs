// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EffectLocationsBlock : EffectLocationsBlockBase
    {
        public  EffectLocationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class EffectLocationsBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID markerName;
        internal  EffectLocationsBlockBase(BinaryReader binaryReader)
        {
            markerName = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(markerName);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
