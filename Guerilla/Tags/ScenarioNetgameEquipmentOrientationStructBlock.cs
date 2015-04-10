using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioNetgameEquipmentOrientationStructBlock : ScenarioNetgameEquipmentOrientationStructBlockBase
    {
        public  ScenarioNetgameEquipmentOrientationStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ScenarioNetgameEquipmentOrientationStructBlockBase
    {
        internal OpenTK.Vector3 orientation;
        internal  ScenarioNetgameEquipmentOrientationStructBlockBase(BinaryReader binaryReader)
        {
            this.orientation = binaryReader.ReadVector3();
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
