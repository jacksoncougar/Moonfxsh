using System.Collections.Generic;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public static class GuerillaExtensions
    {
        public static void Write(this Stream output, GuerillaBlock block)
        {
            var queueableBinaryWriter = new QueueableBinaryWriter(output,
                (int)output.Position + block.SerializedSize);

            block.QueueWrites(queueableBinaryWriter);
            block.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WriteQueue();
        }

        public static void Write(this BinaryWriter binaryWriter, GuerillaBlock block)
        {
            block.Write_(binaryWriter as QueueableBinaryWriter ??
                         new QueueableBinaryWriter(binaryWriter.BaseStream, block.SerializedSize));
        }

        public delegate void PreProcessFieldSet(BinaryReader reader, List<tag_field> fieldSet);

        public static List<tag_field> ReadFields(this BinaryReader reader)
        {
            var fields = new List<tag_field>();
            var field = new tag_field();
            do
            {
                long currentAddress = reader.BaseStream.Position;
                field = reader.ReadFieldDefinition<tag_field>();
                fields.Add(field);
                // Seek to the next tag_field.
                reader.BaseStream.Position = currentAddress + 16;
            } while (field.type != field_type._field_terminator);
            return fields;
        }

        public static T ReadFieldDefinition<T>(this BinaryReader reader) where T : IReadDefinition, new()
        {
            // Read the tag_block_definition struct from the stream.
            T definition = new T();

            definition.Read(reader);
            return definition;
        }

        public static T ReadFieldDefinition<T>(this BinaryReader reader, tag_field field)
            where T : IReadDefinition, new()
        {
            // Seek to the tag_block_definition address.
            reader.BaseStream.Position = field.definition - Guerilla.BaseAddress;

            return ReadFieldDefinition<T>(reader);
        }
    };
}