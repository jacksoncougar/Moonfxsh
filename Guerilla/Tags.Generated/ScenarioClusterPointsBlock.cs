// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioClusterPointsBlock : ScenarioClusterPointsBlockBase
    {
        public  ScenarioClusterPointsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioClusterPointsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ScenarioClusterPointsBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 centroid;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioClusterPointsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            centroid = binaryReader.ReadVector3();
        }
        public  ScenarioClusterPointsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            centroid = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(centroid);
                return nextAddress;
            }
        }
    };
}
