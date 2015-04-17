// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterPhysicsDeadStructBlock : CharacterPhysicsDeadStructBlockBase
    {
        public CharacterPhysicsDeadStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 0, Alignment = 4 )]
    public class CharacterPhysicsDeadStructBlockBase : IGuerilla
    {
        internal CharacterPhysicsDeadStructBlockBase( BinaryReader binaryReader )
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