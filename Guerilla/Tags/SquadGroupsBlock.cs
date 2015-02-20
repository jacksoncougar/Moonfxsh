using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SquadGroupsBlock : SquadGroupsBlockBase
    {
        public  SquadGroupsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class SquadGroupsBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ShortBlockIndex1 parent;
        internal Moonfish.Tags.ShortBlockIndex1 initialOrders;
        internal  SquadGroupsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.parent = binaryReader.ReadShortBlockIndex1();
            this.initialOrders = binaryReader.ReadShortBlockIndex1();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
