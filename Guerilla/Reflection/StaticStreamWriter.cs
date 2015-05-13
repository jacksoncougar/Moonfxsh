using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Reflection
{
    public class StaticStreamWriter
    {
        private static StreamWriter _streamWriter;

        static StaticStreamWriter()
        {
            _streamWriter = new StreamWriter(File.Create(Path.Combine(Local.MapsDirectory, "guerillaNames.txt")));
        }

        public static void Write(string name)
        {
            _streamWriter.WriteLine(name);
        }
    }
}
