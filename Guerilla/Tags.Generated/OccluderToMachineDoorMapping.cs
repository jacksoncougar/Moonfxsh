// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class OccluderToMachineDoorMapping : OccluderToMachineDoorMappingBase
    {
        public OccluderToMachineDoorMapping( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 1, Alignment = 4 )]
    public class OccluderToMachineDoorMappingBase : GuerillaBlock
    {
        internal byte machineDoorIndex;

        public override int SerializedSize
        {
            get { return 1; }
        }

        internal OccluderToMachineDoorMappingBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            machineDoorIndex = binaryReader.ReadByte( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( machineDoorIndex );
                return nextAddress;
            }
        }
    };
}