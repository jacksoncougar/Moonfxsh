using Moonfish.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Compiler;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.CodeDom;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish
{
    internal static class main
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            CacheStream map = new CacheStream(Path.Combine(Local.MapsDirectory, @"output1.map"));
            var scenario = (ScenarioBlock) map.Deserialize(map.Index.ScenarioIdent);
            var crates = scenario.Crates.ToList();
            crates.AddRange(crates);
            crates.AddRange(crates);
            crates.AddRange(crates);
            crates.AddRange(crates);
            crates.AddRange(crates);
            crates.AddRange(crates);
            scenario.Crates = crates.ToArray();
            map.Save();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Gizmo());
        }

        private static CacheStream Save(this CacheStream map)
        {
            var filename = Path.Combine(Local.MapsDirectory, @"temp.map");
            FileStream copyStream = new FileStream(filename, FileMode.Create,
                FileAccess.Write, FileShare.ReadWrite, 4 * 1024, FileOptions.SequentialScan);
            using(copyStream)
            using (map)
            {
                map.SaveTo(copyStream);
            }
            File.Delete(map.Name);
            File.Move(filename, map.Name);
            return new CacheStream(map.Name);
        }
    }
}