// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RuntimeLevelsDefinitionBlock : RuntimeLevelsDefinitionBlockBase
    {
        public RuntimeLevelsDefinitionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class RuntimeLevelsDefinitionBlockBase : IGuerilla
    {
        internal RuntimeCampaignLevelBlock[] campaignLevels;

        internal RuntimeLevelsDefinitionBlockBase( BinaryReader binaryReader )
        {
            campaignLevels = Guerilla.ReadBlockArray<RuntimeCampaignLevelBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<RuntimeCampaignLevelBlock>( binaryWriter, campaignLevels,
                    nextAddress );
                return nextAddress;
            }
        }
    };
}