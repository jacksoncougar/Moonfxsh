// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ObjectChangeColors : ObjectChangeColorsBase
    {
        public ObjectChangeColors( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class ObjectChangeColorsBase : GuerillaBlock
    {
        internal ObjectChangeColorInitialPermutation[] initialPermutations;
        internal ObjectChangeColorFunction[] functions;

        public override int SerializedSize
        {
            get { return 16; }
        }

        internal ObjectChangeColorsBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            initialPermutations = Guerilla.ReadBlockArray<ObjectChangeColorInitialPermutation>( binaryReader );
            functions = Guerilla.ReadBlockArray<ObjectChangeColorFunction>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<ObjectChangeColorInitialPermutation>( binaryWriter,
                    initialPermutations, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<ObjectChangeColorFunction>( binaryWriter, functions, nextAddress );
                return nextAddress;
            }
        }
    };
}