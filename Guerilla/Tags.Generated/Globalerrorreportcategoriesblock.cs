// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalErrorReportCategoriesBlock : GlobalErrorReportCategoriesBlockBase
    {
        public GlobalErrorReportCategoriesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 676, Alignment = 4)]
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

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalErrorReportCategoriesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString256();
            reportType = (ReportType) binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(404);
            blamPointers.Enqueue(ReadBlockArrayPointer<ErrorReportsBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            reports = ReadBlockArrayData<ErrorReportsBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16) reportType);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 404);
                nextAddress = Guerilla.WriteBlockArray<ErrorReportsBlock>(binaryWriter, reports, nextAddress);
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