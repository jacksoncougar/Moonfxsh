using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitAdditionalNodeNamesStructBlock : UnitAdditionalNodeNamesStructBlockBase
    {
        public  UnitAdditionalNodeNamesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class UnitAdditionalNodeNamesStructBlockBase
    {
        /// <summary>
        /// if found, use this gun marker
        /// </summary>
        internal Moonfish.Tags.StringID preferredGunNode;
        internal  UnitAdditionalNodeNamesStructBlockBase(BinaryReader binaryReader)
        {
            this.preferredGunNode = binaryReader.ReadStringID();
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
