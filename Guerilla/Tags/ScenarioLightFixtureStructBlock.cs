// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioLightFixtureStructBlock : ScenarioLightFixtureStructBlockBase
    {
        public ScenarioLightFixtureStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class ScenarioLightFixtureStructBlockBase : IGuerilla
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal float intensity;
        internal float falloffAngleDegrees;
        internal float cutoffAngleDegrees;

        internal ScenarioLightFixtureStructBlockBase( BinaryReader binaryReader )
        {
            color = binaryReader.ReadColorR8G8B8( );
            intensity = binaryReader.ReadSingle( );
            falloffAngleDegrees = binaryReader.ReadSingle( );
            cutoffAngleDegrees = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( color );
                binaryWriter.Write( intensity );
                binaryWriter.Write( falloffAngleDegrees );
                binaryWriter.Write( cutoffAngleDegrees );
                return nextAddress;
            }
        }
    };
}