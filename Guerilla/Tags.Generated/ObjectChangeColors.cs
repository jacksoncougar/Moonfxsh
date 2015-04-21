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
    public class ObjectChangeColorsBase : IGuerilla
    {
        internal ObjectChangeColorInitialPermutation[] initialPermutations;
        internal ObjectChangeColorFunction[] functions;

        internal ObjectChangeColorsBase( BinaryReader binaryReader )
        {
            initialPermutations = Guerilla.ReadBlockArray<ObjectChangeColorInitialPermutation>( binaryReader );
            functions = Guerilla.ReadBlockArray<ObjectChangeColorFunction>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
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