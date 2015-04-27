// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioNetgameEquipmentOrientationStructBlock : ScenarioNetgameEquipmentOrientationStructBlockBase
    {
        public  ScenarioNetgameEquipmentOrientationStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioNetgameEquipmentOrientationStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ScenarioNetgameEquipmentOrientationStructBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 orientation;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioNetgameEquipmentOrientationStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            orientation = binaryReader.ReadVector3();
        }
        public  ScenarioNetgameEquipmentOrientationStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(orientation);
                return nextAddress;
            }
        }
    };
}
