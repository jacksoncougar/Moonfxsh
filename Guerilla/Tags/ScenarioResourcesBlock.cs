// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioResourcesBlock : ScenarioResourcesBlockBase
    {
        public  ScenarioResourcesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioResourcesBlockBase  : IGuerilla
    {
        internal ScenarioResourceReferenceBlock[] references;
        internal ScenarioHsSourceReferenceBlock[] scriptSource;
        internal ScenarioAiResourceReferenceBlock[] aIResources;
        internal  ScenarioResourcesBlockBase(BinaryReader binaryReader)
        {
            references = Guerilla.ReadBlockArray<ScenarioResourceReferenceBlock>(binaryReader);
            scriptSource = Guerilla.ReadBlockArray<ScenarioHsSourceReferenceBlock>(binaryReader);
            aIResources = Guerilla.ReadBlockArray<ScenarioAiResourceReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioResourceReferenceBlock>(binaryWriter, references, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioHsSourceReferenceBlock>(binaryWriter, scriptSource, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioAiResourceReferenceBlock>(binaryWriter, aIResources, nextAddress);
                return nextAddress;
            }
        }
    };
}
