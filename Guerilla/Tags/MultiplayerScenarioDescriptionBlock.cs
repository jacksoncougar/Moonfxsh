// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass MplyClass = (TagClass)"mply";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mply")]
    public  partial class MultiplayerScenarioDescriptionBlock : MultiplayerScenarioDescriptionBlockBase
    {
        public  MultiplayerScenarioDescriptionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class MultiplayerScenarioDescriptionBlockBase  : IGuerilla
    {
        internal ScenarioDescriptionBlock[] multiplayerScenarios;
        internal  MultiplayerScenarioDescriptionBlockBase(BinaryReader binaryReader)
        {
            multiplayerScenarios = Guerilla.ReadBlockArray<ScenarioDescriptionBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<ScenarioDescriptionBlock>(binaryWriter, multiplayerScenarios, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
