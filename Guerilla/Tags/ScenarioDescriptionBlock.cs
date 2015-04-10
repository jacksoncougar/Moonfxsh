using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioDescriptionBlock : ScenarioDescriptionBlockBase
    {
        public  ScenarioDescriptionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class ScenarioDescriptionBlockBase
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference descriptiveBitmap;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference displayedMapName;
        /// <summary>
        /// this is the path to the directory containing the scenario tag file of the same name
        /// </summary>
        internal Moonfish.Tags.String32 scenarioTagDirectoryPath;
        internal byte[] invalidName_;
        internal  ScenarioDescriptionBlockBase(BinaryReader binaryReader)
        {
            this.descriptiveBitmap = binaryReader.ReadTagReference();
            this.displayedMapName = binaryReader.ReadTagReference();
            this.scenarioTagDirectoryPath = binaryReader.ReadString32();
            this.invalidName_ = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
