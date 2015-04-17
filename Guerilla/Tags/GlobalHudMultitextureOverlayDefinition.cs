// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalHudMultitextureOverlayDefinition : GlobalHudMultitextureOverlayDefinitionBase
    {
        public GlobalHudMultitextureOverlayDefinition( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 452, Alignment = 4 )]
    public class GlobalHudMultitextureOverlayDefinitionBase : IGuerilla
    {
        internal byte[] invalidName_;
        internal short type;
        internal FramebufferBlendFunc framebufferBlendFunc;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal PrimaryAnchor primaryAnchor;
        internal SecondaryAnchor secondaryAnchor;
        internal TertiaryAnchor tertiaryAnchor;
        internal InvalidName0To1BlendFunc invalidName_0To1BlendFunc;
        internal InvalidName1To2BlendFunc invalidName_1To2BlendFunc;
        internal byte[] invalidName_2;
        internal OpenTK.Vector2 primaryScale;
        internal OpenTK.Vector2 secondaryScale;
        internal OpenTK.Vector2 tertiaryScale;
        internal OpenTK.Vector2 primaryOffset;
        internal OpenTK.Vector2 secondaryOffset;
        internal OpenTK.Vector2 tertiaryOffset;
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference primary;
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference secondary;
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference tertiary;
        internal PrimaryWrapMode primaryWrapMode;
        internal SecondaryWrapMode secondaryWrapMode;
        internal TertiaryWrapMode tertiaryWrapMode;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal GlobalHudMultitextureOverlayEffectorDefinition[] effectors;
        internal byte[] invalidName_5;

        internal GlobalHudMultitextureOverlayDefinitionBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 2 );
            type = binaryReader.ReadInt16( );
            framebufferBlendFunc = ( FramebufferBlendFunc ) binaryReader.ReadInt16( );
            invalidName_0 = binaryReader.ReadBytes( 2 );
            invalidName_1 = binaryReader.ReadBytes( 32 );
            primaryAnchor = ( PrimaryAnchor ) binaryReader.ReadInt16( );
            secondaryAnchor = ( SecondaryAnchor ) binaryReader.ReadInt16( );
            tertiaryAnchor = ( TertiaryAnchor ) binaryReader.ReadInt16( );
            invalidName_0To1BlendFunc = ( InvalidName0To1BlendFunc ) binaryReader.ReadInt16( );
            invalidName_1To2BlendFunc = ( InvalidName1To2BlendFunc ) binaryReader.ReadInt16( );
            invalidName_2 = binaryReader.ReadBytes( 2 );
            primaryScale = binaryReader.ReadVector2( );
            secondaryScale = binaryReader.ReadVector2( );
            tertiaryScale = binaryReader.ReadVector2( );
            primaryOffset = binaryReader.ReadVector2( );
            secondaryOffset = binaryReader.ReadVector2( );
            tertiaryOffset = binaryReader.ReadVector2( );
            primary = binaryReader.ReadTagReference( );
            secondary = binaryReader.ReadTagReference( );
            tertiary = binaryReader.ReadTagReference( );
            primaryWrapMode = ( PrimaryWrapMode ) binaryReader.ReadInt16( );
            secondaryWrapMode = ( SecondaryWrapMode ) binaryReader.ReadInt16( );
            tertiaryWrapMode = ( TertiaryWrapMode ) binaryReader.ReadInt16( );
            invalidName_3 = binaryReader.ReadBytes( 2 );
            invalidName_4 = binaryReader.ReadBytes( 184 );
            effectors = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayEffectorDefinition>( binaryReader );
            invalidName_5 = binaryReader.ReadBytes( 128 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( type );
                binaryWriter.Write( ( Int16 ) framebufferBlendFunc );
                binaryWriter.Write( invalidName_0, 0, 2 );
                binaryWriter.Write( invalidName_1, 0, 32 );
                binaryWriter.Write( ( Int16 ) primaryAnchor );
                binaryWriter.Write( ( Int16 ) secondaryAnchor );
                binaryWriter.Write( ( Int16 ) tertiaryAnchor );
                binaryWriter.Write( ( Int16 ) invalidName_0To1BlendFunc );
                binaryWriter.Write( ( Int16 ) invalidName_1To2BlendFunc );
                binaryWriter.Write( invalidName_2, 0, 2 );
                binaryWriter.Write( primaryScale );
                binaryWriter.Write( secondaryScale );
                binaryWriter.Write( tertiaryScale );
                binaryWriter.Write( primaryOffset );
                binaryWriter.Write( secondaryOffset );
                binaryWriter.Write( tertiaryOffset );
                binaryWriter.Write( primary );
                binaryWriter.Write( secondary );
                binaryWriter.Write( tertiary );
                binaryWriter.Write( ( Int16 ) primaryWrapMode );
                binaryWriter.Write( ( Int16 ) secondaryWrapMode );
                binaryWriter.Write( ( Int16 ) tertiaryWrapMode );
                binaryWriter.Write( invalidName_3, 0, 2 );
                binaryWriter.Write( invalidName_4, 0, 184 );
                nextAddress = Guerilla.WriteBlockArray<GlobalHudMultitextureOverlayEffectorDefinition>( binaryWriter,
                    effectors, nextAddress );
                binaryWriter.Write( invalidName_5, 0, 128 );
                return nextAddress;
            }
        }

        internal enum FramebufferBlendFunc : short
        {
            AlphaBlend = 0,
            Multiply = 1,
            DoubleMultiply = 2,
            Add = 3,
            Subtract = 4,
            ComponentMin = 5,
            ComponentMax = 6,
            AlphaMultiplyAdd = 7,
            ConstantColorBlend = 8,
            InverseConstantColorBlend = 9,
            None = 10,
        };

        internal enum PrimaryAnchor : short
        {
            Texture = 0,
            Screen = 1,
        };

        internal enum SecondaryAnchor : short
        {
            Texture = 0,
            Screen = 1,
        };

        internal enum TertiaryAnchor : short
        {
            Texture = 0,
            Screen = 1,
        };

        internal enum InvalidName0To1BlendFunc : short
        {
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Multiply2x = 3,
            Dot = 4,
        };

        internal enum InvalidName1To2BlendFunc : short
        {
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Multiply2x = 3,
            Dot = 4,
        };

        internal enum PrimaryWrapMode : short
        {
            Clamp = 0,
            Wrap = 1,
        };

        internal enum SecondaryWrapMode : short
        {
            Clamp = 0,
            Wrap = 1,
        };

        internal enum TertiaryWrapMode : short
        {
            Clamp = 0,
            Wrap = 1,
        };
    };
}