// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RasterizerScreenEffectConvolutionBlock : RasterizerScreenEffectConvolutionBlockBase
    {
        public RasterizerScreenEffectConvolutionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 92, Alignment = 4 )]
    public class RasterizerScreenEffectConvolutionBlockBase : IGuerilla
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal float convolutionAmount0Inf;
        internal float filterScale;
        internal float filterBoxFactor01NotUsedForZoom;
        internal float zoomFalloffRadius;
        internal float zoomCutoffRadius;
        internal float resolutionScale01;

        internal RasterizerScreenEffectConvolutionBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            invalidName_0 = binaryReader.ReadBytes( 64 );
            convolutionAmount0Inf = binaryReader.ReadSingle( );
            filterScale = binaryReader.ReadSingle( );
            filterBoxFactor01NotUsedForZoom = binaryReader.ReadSingle( );
            zoomFalloffRadius = binaryReader.ReadSingle( );
            zoomCutoffRadius = binaryReader.ReadSingle( );
            resolutionScale01 = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( invalidName_0, 0, 64 );
                binaryWriter.Write( convolutionAmount0Inf );
                binaryWriter.Write( filterScale );
                binaryWriter.Write( filterBoxFactor01NotUsedForZoom );
                binaryWriter.Write( zoomFalloffRadius );
                binaryWriter.Write( zoomCutoffRadius );
                binaryWriter.Write( resolutionScale01 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            OnlyWhenPrimaryIsActive = 1,
            OnlyWhenSecondaryIsActive = 2,
            PredatorZoom = 4,
        };
    };
}