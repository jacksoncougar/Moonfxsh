// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspClusterDataBlockNew : StructureBspClusterDataBlockNewBase
    {
        public StructureBspClusterDataBlockNew( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 68, Alignment = 4 )]
    public class StructureBspClusterDataBlockNewBase : GuerillaBlock
    {
        internal GlobalGeometrySectionStructBlock section;

        public override int SerializedSize
        {
            get { return 68; }
        }

        internal StructureBspClusterDataBlockNewBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            section = new GlobalGeometrySectionStructBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                section.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}