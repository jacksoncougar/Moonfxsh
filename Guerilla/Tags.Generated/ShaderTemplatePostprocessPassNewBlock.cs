// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplatePostprocessPassNewBlock : ShaderTemplatePostprocessPassNewBlockBase
    {
        public ShaderTemplatePostprocessPassNewBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 10, Alignment = 4 )]
    public class ShaderTemplatePostprocessPassNewBlockBase : IGuerilla
    {
        [TagReference( "spas" )] internal Moonfish.Tags.TagReference pass;
        internal TagBlockIndexStructBlock implementations;

        internal ShaderTemplatePostprocessPassNewBlockBase( BinaryReader binaryReader )
        {
            pass = binaryReader.ReadTagReference( );
            implementations = new TagBlockIndexStructBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( pass );
                implementations.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}