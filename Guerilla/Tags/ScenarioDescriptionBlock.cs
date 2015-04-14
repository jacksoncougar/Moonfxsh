// ReSharper disable All
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
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ScenarioDescriptionBlockBase  : IGuerilla
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
            descriptiveBitmap = binaryReader.ReadTagReference();
            displayedMapName = binaryReader.ReadTagReference();
            scenarioTagDirectoryPath = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(descriptiveBitmap);
                binaryWriter.Write(displayedMapName);
                binaryWriter.Write(scenarioTagDirectoryPath);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
