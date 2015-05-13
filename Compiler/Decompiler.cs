using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Compiler
{
    public static class Decompiler
    {
        public static void Decompile(this CacheStream cache)
        {
            var rootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Halo 2 Modding");
            foreach (var tag in cache.Index.Where(x => x.Class == (TagClass)"bitm"))
            {
                var path = Path.Combine(rootDirectory, Path.ChangeExtension(tag.Path, tag.Class.ToTokenString()));

                var directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    BinaryWriter binaryWriter = new BinaryWriter(stream);
                    var tagObject = cache.Deserialize(tag.Identifier) as IGuerilla;
                    //tagObject.Write( binaryWriter );
                }
            }
        }
    }
}