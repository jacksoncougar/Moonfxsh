// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GearBlock : GearBlockBase
    {
        public GearBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 68, Alignment = 4 )]
    public class GearBlockBase : IGuerilla
    {
        internal TorqueCurveStructBlock loadedTorqueCurve;
        internal TorqueCurveStructBlock cruisingTorqueCurve;

        /// <summary>
        /// seconds
        /// </summary>
        internal float minTimeToUpshift;

        /// <summary>
        /// 0-1
        /// </summary>
        internal float engineUpShiftScale;

        internal float gearRatio;

        /// <summary>
        /// seconds
        /// </summary>
        internal float minTimeToDownshift;

        /// <summary>
        /// 0-1
        /// </summary>
        internal float engineDownShiftScale;

        internal GearBlockBase( BinaryReader binaryReader )
        {
            loadedTorqueCurve = new TorqueCurveStructBlock( binaryReader );
            cruisingTorqueCurve = new TorqueCurveStructBlock( binaryReader );
            minTimeToUpshift = binaryReader.ReadSingle( );
            engineUpShiftScale = binaryReader.ReadSingle( );
            gearRatio = binaryReader.ReadSingle( );
            minTimeToDownshift = binaryReader.ReadSingle( );
            engineDownShiftScale = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                loadedTorqueCurve.Write( binaryWriter );
                cruisingTorqueCurve.Write( binaryWriter );
                binaryWriter.Write( minTimeToUpshift );
                binaryWriter.Write( engineUpShiftScale );
                binaryWriter.Write( gearRatio );
                binaryWriter.Write( minTimeToDownshift );
                binaryWriter.Write( engineDownShiftScale );
                return nextAddress;
            }
        }
    };
}