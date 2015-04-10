// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalErrorReportCategoriesBlock : GlobalErrorReportCategoriesBlockBase
    {
        public  GlobalErrorReportCategoriesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 676)]
    public class GlobalErrorReportCategoriesBlockBase
    {
        internal Moonfish.Tags.String256 name;
        internal ReportType reportType;
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal ErrorReportsBlock[] reports;
        internal  GlobalErrorReportCategoriesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString256();
            reportType = (ReportType)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(404);
            ReadErrorReportsBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual ErrorReportsBlock[] ReadErrorReportsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteErrorReportsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)reportType);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 404);
                WriteErrorReportsBlockArray(binaryWriter);
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
