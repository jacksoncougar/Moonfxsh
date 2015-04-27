// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioClusterWeatherPropertiesBlock : ScenarioClusterWeatherPropertiesBlockBase
    {
        public  ScenarioClusterWeatherPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioClusterWeatherPropertiesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ScenarioClusterWeatherPropertiesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioClusterWeatherPropertiesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  ScenarioClusterWeatherPropertiesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
