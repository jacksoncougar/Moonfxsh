// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ContactPointBlock : ContactPointBlockBase
    {
        public  ContactPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ContactPointBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID markerName;
        internal  ContactPointBlockBase(BinaryReader binaryReader)
        {
            markerName = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(markerName);
                return nextAddress;
            }
        }
    };
}
