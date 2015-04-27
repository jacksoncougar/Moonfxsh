// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SquadGroupsBlock : SquadGroupsBlockBase
    {
        public  SquadGroupsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SquadGroupsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class SquadGroupsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ShortBlockIndex1 parent;
        internal Moonfish.Tags.ShortBlockIndex1 initialOrders;
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SquadGroupsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            parent = binaryReader.ReadShortBlockIndex1();
            initialOrders = binaryReader.ReadShortBlockIndex1();
        }
        public  SquadGroupsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            parent = binaryReader.ReadShortBlockIndex1();
            initialOrders = binaryReader.ReadShortBlockIndex1();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(parent);
                binaryWriter.Write(initialOrders);
                return nextAddress;
            }
        }
    };
}
