// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ClothPropertiesBlock : ClothPropertiesBlockBase
    {
        public ClothPropertiesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 48, Alignment = 4 )]
    public class ClothPropertiesBlockBase : GuerillaBlock
    {
        internal IntegrationType integrationType;

        /// <summary>
        /// [1-8] sug 1
        /// </summary>
        internal short numberIterations;

        /// <summary>
        /// [-10.0 - 10.0] sug 1.0
        /// </summary>
        internal float weight;

        /// <summary>
        /// [0.0 - 0.5] sug 0.07
        /// </summary>
        internal float drag;

        /// <summary>
        /// [0.0 - 3.0] sug 1.0
        /// </summary>
        internal float windScale;

        /// <summary>
        /// [0.0 - 1.0] sug 0.75
        /// </summary>
        internal float windFlappinessScale;

        /// <summary>
        /// [1.0 - 10.0] sug 3.5
        /// </summary>
        internal float longestRod;

        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 48; }
        }

        internal ClothPropertiesBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            integrationType = ( IntegrationType ) binaryReader.ReadInt16( );
            numberIterations = binaryReader.ReadInt16( );
            weight = binaryReader.ReadSingle( );
            drag = binaryReader.ReadSingle( );
            windScale = binaryReader.ReadSingle( );
            windFlappinessScale = binaryReader.ReadSingle( );
            longestRod = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 24 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) integrationType );
                binaryWriter.Write( numberIterations );
                binaryWriter.Write( weight );
                binaryWriter.Write( drag );
                binaryWriter.Write( windScale );
                binaryWriter.Write( windFlappinessScale );
                binaryWriter.Write( longestRod );
                binaryWriter.Write( invalidName_, 0, 24 );
                return nextAddress;
            }
        }

        internal enum IntegrationType : short
        {
            Verlet = 0,
        };
    };
}