// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BehaviorNamesBlock : BehaviorNamesBlockBase
    {
        public BehaviorNamesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class BehaviorNamesBlockBase : IGuerilla
    {
        internal Moonfish.Tags.String32 behaviorName;

        internal BehaviorNamesBlockBase( BinaryReader binaryReader )
        {
            behaviorName = binaryReader.ReadString32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( behaviorName );
                return nextAddress;
            }
        }
    };
}