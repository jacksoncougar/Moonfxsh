// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessAnimatedParameterNewBlock : ShaderPostprocessAnimatedParameterNewBlockBase
    {
        public ShaderPostprocessAnimatedParameterNewBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 2, Alignment = 4 )]
    public class ShaderPostprocessAnimatedParameterNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock overlayReferences;

        public override int SerializedSize
        {
            get { return 2; }
        }

        internal ShaderPostprocessAnimatedParameterNewBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            overlayReferences = new TagBlockIndexStructBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                overlayReferences.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}