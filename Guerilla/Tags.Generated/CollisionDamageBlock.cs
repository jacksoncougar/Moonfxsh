// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionDamageBlock : CollisionDamageBlockBase
    {
        public CollisionDamageBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 72, Alignment = 4 )]
    public class CollisionDamageBlockBase : IGuerilla
    {
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference collisionDamage;

        /// <summary>
        /// 0-oo
        /// </summary>
        internal float minGameAccDefault;

        /// <summary>
        /// 0-oo
        /// </summary>
        internal float maxGameAccDefault;

        /// <summary>
        /// 0-1
        /// </summary>
        internal float minGameScaleDefault;

        /// <summary>
        /// 0-1
        /// </summary>
        internal float maxGameScaleDefault;

        /// <summary>
        /// 0-oo
        /// </summary>
        internal float minAbsAccDefault;

        /// <summary>
        /// 0-oo
        /// </summary>
        internal float maxAbsAccDefault;

        /// <summary>
        /// 0-1
        /// </summary>
        internal float minAbsScaleDefault;

        /// <summary>
        /// 0-1
        /// </summary>
        internal float maxAbsScaleDefault;

        internal byte[] invalidName_;

        internal CollisionDamageBlockBase( BinaryReader binaryReader )
        {
            collisionDamage = binaryReader.ReadTagReference( );
            minGameAccDefault = binaryReader.ReadSingle( );
            maxGameAccDefault = binaryReader.ReadSingle( );
            minGameScaleDefault = binaryReader.ReadSingle( );
            maxGameScaleDefault = binaryReader.ReadSingle( );
            minAbsAccDefault = binaryReader.ReadSingle( );
            maxAbsAccDefault = binaryReader.ReadSingle( );
            minAbsScaleDefault = binaryReader.ReadSingle( );
            maxAbsScaleDefault = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 32 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( collisionDamage );
                binaryWriter.Write( minGameAccDefault );
                binaryWriter.Write( maxGameAccDefault );
                binaryWriter.Write( minGameScaleDefault );
                binaryWriter.Write( maxGameScaleDefault );
                binaryWriter.Write( minAbsAccDefault );
                binaryWriter.Write( maxAbsAccDefault );
                binaryWriter.Write( minAbsScaleDefault );
                binaryWriter.Write( maxAbsScaleDefault );
                binaryWriter.Write( invalidName_, 0, 32 );
                return nextAddress;
            }
        }
    };
}