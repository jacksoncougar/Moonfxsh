// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessImplementationNewBlock : ShaderPostprocessImplementationNewBlockBase
    {
        public ShaderPostprocessImplementationNewBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 10, Alignment = 4 )]
    public class ShaderPostprocessImplementationNewBlockBase : IGuerilla
    {
        internal TagBlockIndexStructBlock bitmapTransforms;
        internal TagBlockIndexStructBlock renderStates;
        internal TagBlockIndexStructBlock textureStates;
        internal TagBlockIndexStructBlock pixelConstants;
        internal TagBlockIndexStructBlock vertexConstants;

        internal ShaderPostprocessImplementationNewBlockBase( BinaryReader binaryReader )
        {
            bitmapTransforms = new TagBlockIndexStructBlock( binaryReader );
            renderStates = new TagBlockIndexStructBlock( binaryReader );
            textureStates = new TagBlockIndexStructBlock( binaryReader );
            pixelConstants = new TagBlockIndexStructBlock( binaryReader );
            vertexConstants = new TagBlockIndexStructBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                bitmapTransforms.Write( binaryWriter );
                renderStates.Write( binaryWriter );
                textureStates.Write( binaryWriter );
                pixelConstants.Write( binaryWriter );
                vertexConstants.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}