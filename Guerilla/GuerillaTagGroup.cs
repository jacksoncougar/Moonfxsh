using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class GuerillaTagGroup : IReadDefinition
    {
        public int[] childGroupTags;
        public short childsCount;
        public int defaultTagPathAddress;
        public int definitionAddress;
        public int flags;
        public int groupTag;
        public byte initialized;
        public int nameAddress;
        public int parentGroupTag;
        public int postprocessForSyncProc;
        public int postprocessProc;
        public int savePostprocessProc;
        public short version;

        public GuerillaTagGroup(BinaryReader reader)
        {
            Read(reader);
        }

        public TagClass Class
        {
            get { return new TagClass(groupTag); }
        }

        public string DefaultPath { get; set; }
        public dynamic Definition { get; set; }
        public string Name { get; private set; }

        public TagClass ParentClass
        {
            get { return new TagClass(parentGroupTag); }
        }

        private void Read(BinaryReader reader)
        {
            var stream = reader.BaseStream;

            nameAddress = reader.ReadInt32();
            flags = reader.ReadInt32();
            groupTag = reader.ReadInt32();
            parentGroupTag = reader.ReadInt32();
            version = reader.ReadInt16();
            initialized = reader.ReadByte();

            stream.Seek(1, SeekOrigin.Current);

            postprocessProc = reader.ReadInt32();
            savePostprocessProc = reader.ReadInt32();
            postprocessForSyncProc = reader.ReadInt32();

            stream.Seek(4, SeekOrigin.Current);

            definitionAddress = reader.ReadInt32();
            childGroupTags = new int[16];
            for (var i = 0; i < 16; i++)
                childGroupTags[i] = reader.ReadInt32();
            childsCount = reader.ReadInt16();

            stream.Seek(2, SeekOrigin.Current);

            defaultTagPathAddress = reader.ReadInt32();


            Name = Guerilla.ReadString(reader, nameAddress);

            DefaultPath = Guerilla.ReadString(reader, defaultTagPathAddress);
            stream.Seek(definitionAddress, SeekOrigin.Begin);
            Definition = reader.ReadFieldDefinition<TagBlockDefinition>();
        }

        void IReadDefinition.Read(BinaryReader reader)
        {
            Read(reader);
        }
    }
}