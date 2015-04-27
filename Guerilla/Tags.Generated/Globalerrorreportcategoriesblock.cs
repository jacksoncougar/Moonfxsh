// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalErrorReportCategoriesBlock : GlobalErrorReportCategoriesBlockBase
    {
        public GlobalErrorReportCategoriesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 676, Alignment = 4 )]
    public class GlobalErrorReportCategoriesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String256 name;
        internal ReportType reportType;
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal ErrorReportsBlock[] reports;

        public override int SerializedSize
        {
            get { return 676; }
        }

        internal GlobalErrorReportCategoriesBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadString256( );
            reportType = ( ReportType ) binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            invalidName_0 = binaryReader.ReadBytes( 2 );
            invalidName_1 = binaryReader.ReadBytes( 404 );
            reports = Guerilla.ReadBlockArray<ErrorReportsBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( ( Int16 ) reportType );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( invalidName_0, 0, 2 );
                binaryWriter.Write( invalidName_1, 0, 404 );
                nextAddress = Guerilla.WriteBlockArray<ErrorReportsBlock>( binaryWriter, reports, nextAddress );
                return nextAddress;
            }
        }

        internal enum ReportType : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        };

        [FlagsAttribute]
        internal enum Flags : short
        {
            Rendered = 1,
            TangentSpace = 2,
            Noncritical = 4,
            LightmapLight = 8,
            ReportKeyIsValid = 16,
        };
    };
}