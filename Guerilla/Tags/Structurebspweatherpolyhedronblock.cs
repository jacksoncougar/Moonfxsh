// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspWeatherPolyhedronBlock : StructureBspWeatherPolyhedronBlockBase
    {
        public StructureBspWeatherPolyhedronBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class StructureBspWeatherPolyhedronBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 boundingSphereCenter;
        internal float boundingSphereRadius;
        internal StructureBspWeatherPolyhedronPlaneBlock[] planes;

        internal StructureBspWeatherPolyhedronBlockBase( BinaryReader binaryReader )
        {
            boundingSphereCenter = binaryReader.ReadVector3( );
            boundingSphereRadius = binaryReader.ReadSingle( );
            planes = Guerilla.ReadBlockArray<StructureBspWeatherPolyhedronPlaneBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( boundingSphereCenter );
                binaryWriter.Write( boundingSphereRadius );
                nextAddress = Guerilla.WriteBlockArray<StructureBspWeatherPolyhedronPlaneBlock>( binaryWriter, planes,
                    nextAddress );
                return nextAddress;
            }
        }
    };
}