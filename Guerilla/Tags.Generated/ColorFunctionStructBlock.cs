// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ColorFunctionStructBlock : ColorFunctionStructBlockBase
    {
        public ColorFunctionStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ColorFunctionStructBlockBase : GuerillaBlock
    {
        internal MappingFunctionBlock function;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal ColorFunctionStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            function = new MappingFunctionBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                function.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}