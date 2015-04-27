// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitAdditionalNodeNamesStructBlock : UnitAdditionalNodeNamesStructBlockBase
    {
        public  UnitAdditionalNodeNamesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UnitAdditionalNodeNamesStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class UnitAdditionalNodeNamesStructBlockBase : GuerillaBlock
    {
        /// <summary>
        /// if found, use this gun marker
        /// </summary>
        internal Moonfish.Tags.StringID preferredGunNode;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UnitAdditionalNodeNamesStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            preferredGunNode = binaryReader.ReadStringID();
        }
        public  UnitAdditionalNodeNamesStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            preferredGunNode = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(preferredGunNode);
                return nextAddress;
            }
        }
    };
}
