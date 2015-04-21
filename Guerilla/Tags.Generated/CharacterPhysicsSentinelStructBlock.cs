// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterPhysicsSentinelStructBlock : CharacterPhysicsSentinelStructBlockBase
    {
        public CharacterPhysicsSentinelStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 0, Alignment = 4 )]
    public class CharacterPhysicsSentinelStructBlockBase : IGuerilla
    {
        internal CharacterPhysicsSentinelStructBlockBase( BinaryReader binaryReader )
        {
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                return nextAddress;
            }
        }
    };
}