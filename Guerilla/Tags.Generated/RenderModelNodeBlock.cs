// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelNodeBlock : RenderModelNodeBlockBase
    {
        public RenderModelNodeBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 96, Alignment = 4 )]
    public class RenderModelNodeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 parentNode;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNode;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNode;
        internal short importNodeIndex;
        internal OpenTK.Vector3 defaultTranslation;
        internal OpenTK.Quaternion defaultRotation;
        internal OpenTK.Vector3 inverseForward;
        internal OpenTK.Vector3 inverseLeft;
        internal OpenTK.Vector3 inverseUp;
        internal OpenTK.Vector3 inversePosition;
        internal float inverseScale;
        internal float distanceFromParent;

        public override int SerializedSize
        {
            get { return 96; }
        }

        internal RenderModelNodeBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            parentNode = binaryReader.ReadShortBlockIndex1( );
            firstChildNode = binaryReader.ReadShortBlockIndex1( );
            nextSiblingNode = binaryReader.ReadShortBlockIndex1( );
            importNodeIndex = binaryReader.ReadInt16( );
            defaultTranslation = binaryReader.ReadVector3( );
            defaultRotation = binaryReader.ReadQuaternion( );
            inverseForward = binaryReader.ReadVector3( );
            inverseLeft = binaryReader.ReadVector3( );
            inverseUp = binaryReader.ReadVector3( );
            inversePosition = binaryReader.ReadVector3( );
            inverseScale = binaryReader.ReadSingle( );
            distanceFromParent = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( parentNode );
                binaryWriter.Write( firstChildNode );
                binaryWriter.Write( nextSiblingNode );
                binaryWriter.Write( importNodeIndex );
                binaryWriter.Write( defaultTranslation );
                binaryWriter.Write( defaultRotation );
                binaryWriter.Write( inverseForward );
                binaryWriter.Write( inverseLeft );
                binaryWriter.Write( inverseUp );
                binaryWriter.Write( inversePosition );
                binaryWriter.Write( inverseScale );
                binaryWriter.Write( distanceFromParent );
                return nextAddress;
            }
        }
    };
}