// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderGpuStateReferenceStructBlock : ShaderGpuStateReferenceStructBlockBase
    {
        public ShaderGpuStateReferenceStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 14, Alignment = 4 )]
    public class ShaderGpuStateReferenceStructBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock renderStates;
        internal TagBlockIndexStructBlock textureStageStates;
        internal TagBlockIndexStructBlock renderStateParameters;
        internal TagBlockIndexStructBlock textureStageParameters;
        internal TagBlockIndexStructBlock textures;
        internal TagBlockIndexStructBlock vnConstants;
        internal TagBlockIndexStructBlock cnConstants;

        public override int SerializedSize
        {
            get { return 14; }
        }

        internal ShaderGpuStateReferenceStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            renderStates = new TagBlockIndexStructBlock( binaryReader );
            textureStageStates = new TagBlockIndexStructBlock( binaryReader );
            renderStateParameters = new TagBlockIndexStructBlock( binaryReader );
            textureStageParameters = new TagBlockIndexStructBlock( binaryReader );
            textures = new TagBlockIndexStructBlock( binaryReader );
            vnConstants = new TagBlockIndexStructBlock( binaryReader );
            cnConstants = new TagBlockIndexStructBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                renderStates.Write( binaryWriter );
                textureStageStates.Write( binaryWriter );
                renderStateParameters.Write( binaryWriter );
                textureStageParameters.Write( binaryWriter );
                textures.Write( binaryWriter );
                vnConstants.Write( binaryWriter );
                cnConstants.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}