// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationTransitionBlock : AnimationTransitionBlockBase
    {
        public AnimationTransitionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class AnimationTransitionBlockBase : IGuerilla
    {
        /// <summary>
        /// name of the mode & state of the source
        /// </summary>
        internal Moonfish.Tags.StringID fullName;

        internal AnimationTransitionStateStructBlock stateInfo;
        internal AnimationTransitionDestinationBlock[] destinationsAABBCC;

        internal AnimationTransitionBlockBase( BinaryReader binaryReader )
        {
            fullName = binaryReader.ReadStringID( );
            stateInfo = new AnimationTransitionStateStructBlock( binaryReader );
            destinationsAABBCC = Guerilla.ReadBlockArray<AnimationTransitionDestinationBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( fullName );
                stateInfo.Write( binaryWriter );
                nextAddress = Guerilla.WriteBlockArray<AnimationTransitionDestinationBlock>( binaryWriter,
                    destinationsAABBCC, nextAddress );
                return nextAddress;
            }
        }
    };
}