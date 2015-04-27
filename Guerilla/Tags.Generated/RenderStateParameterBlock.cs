// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderStateParameterBlock : RenderStateParameterBlockBase
    {
        public RenderStateParameterBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 3, Alignment = 4 )]
    public class RenderStateParameterBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte parameterType;
        internal byte stateIndex;

        public override int SerializedSize
        {
            get { return 3; }
        }

        internal RenderStateParameterBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            parameterIndex = binaryReader.ReadByte( );
            parameterType = binaryReader.ReadByte( );
            stateIndex = binaryReader.ReadByte( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( parameterIndex );
                binaryWriter.Write( parameterType );
                binaryWriter.Write( stateIndex );
                return nextAddress;
            }
        }
    };
}