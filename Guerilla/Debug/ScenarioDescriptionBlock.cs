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
        public  ScenarioDescriptionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioDescriptionBlockBase(System.IO.BinaryReader binaryReader)
        {
            descriptiveBitmap = binaryReader.ReadTagReference();
            displayedMapName = binaryReader.ReadTagReference();
            scenarioTagDirectoryPath = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(descriptiveBitmap);
                binaryWriter.Write(displayedMapName);
                binaryWriter.Write(scenarioTagDirectoryPath);
                binaryWriter.Write(invalidName_, 0, 4);
            }
        }
    };
}
