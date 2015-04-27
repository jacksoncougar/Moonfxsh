// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrtLodInfoBlock : PrtLodInfoBlockBase
    {
        public PrtLodInfoBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class PrtLodInfoBlockBase : GuerillaBlock
    {
        internal int clusterOffset;
        internal PrtSectionInfoBlock[] sectionInfo;

        public override int SerializedSize
        {
            get { return 12; }
        }

        internal PrtLodInfoBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            clusterOffset = binaryReader.ReadInt32( );
            sectionInfo = Guerilla.ReadBlockArray<PrtSectionInfoBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( clusterOffset );
                nextAddress = Guerilla.WriteBlockArray<PrtSectionInfoBlock>( binaryWriter, sectionInfo, nextAddress );
                return nextAddress;
            }
        }
    };
}