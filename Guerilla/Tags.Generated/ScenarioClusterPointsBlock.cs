// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioClusterPointsBlock : ScenarioClusterPointsBlockBase
    {
        public  ScenarioClusterPointsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ScenarioClusterPointsBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 centroid;
        internal  ScenarioClusterPointsBlockBase(BinaryReader binaryReader)
        {
            centroid = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(centroid);
                return nextAddress;
            }
        }
    };
}
