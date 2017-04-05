using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    public class Cache
    {
        public CacheStream BaseStream { get; private set; }

        private GuerillaBlock Deserialize(Type tagType)
        {
            var sourceReader = new BinaryReader(BaseStream);
            var instance = (GuerillaBlock) Activator.CreateInstance(tagType);

            instance.Read(sourceReader);

            return instance;
        }

        public TagDatum Add<T>(T item, string tagName) where T : GuerillaBlock
        {
            var lastDatum = BaseStream.Index.Last();

            var stream = new VirtualStream(lastDatum.VirtualAddress);
            var binaryWriter = new BinaryWriter(stream);

            binaryWriter.Write(item);
            var serializedTagData = stream.ToArray();

            var attribute = ( TagClassAttribute ) item.GetType( ).Attribute( typeof ( TagClassAttribute ) ) ??
                            ( TagClassAttribute )
                                item.GetType( ).BaseType?.GetCustomAttributes(typeof ( TagClassAttribute ) ).FirstOrDefault();
            var tagDatum = BaseStream.Index.Add(attribute.TagClass, tagName, serializedTagData.Length, lastDatum.VirtualAddress);

            _deserializedTagCache.Add(tagDatum.Identifier, item );

            var paths = Index.Select( x => x.Path );

            return tagDatum;
        }
    }
}