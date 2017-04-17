using System.IO;
using Moonfish.Tags;

namespace Moonfish
{
    public class TagIndexBase
    {
        protected internal const int HeaderSize = 32;

        private readonly TagClass fourCC;
        public int NoodleValue;
        public int ClassArrayAddress;
        public int ClassArrayCount;
        public int DatumArrayAddress;
        public int DatumArrayCount;

        protected TagIndexBase(Map cache)
        {
            var binaryReader = new BinaryReader(cache.BaseStream);
            ClassArrayAddress = binaryReader.ReadInt32();
            ClassArrayCount = binaryReader.ReadInt32();
            DatumArrayAddress = binaryReader.ReadInt32();
            ScenarioIdent = binaryReader.ReadTagIdent();
            GlobalsIdent = binaryReader.ReadTagIdent();
            NoodleValue = binaryReader.ReadInt32();
            DatumArrayCount = binaryReader.ReadInt32();
            fourCC = binaryReader.ReadTagClass();
            if (fourCC != new TagClass("tags"))
                throw new InvalidDataException();
        }

        public TagIdent ScenarioIdent { get; set; }
        public TagIdent GlobalsIdent { get; set; }

        protected byte[] SerializeHeader()
        {
            var stream = new MemoryStream(HeaderSize);
            var binaryWriter = new BinaryWriter(stream);
            binaryWriter.Write(ClassArrayAddress);
            binaryWriter.Write(ClassArrayCount);
            binaryWriter.Write(DatumArrayAddress);
            binaryWriter.Write(ScenarioIdent);
            binaryWriter.Write(GlobalsIdent);
            binaryWriter.Write(0);
            binaryWriter.Write(DatumArrayCount);
            binaryWriter.Write(fourCC);
            return stream.GetBuffer();
        }
    }
}