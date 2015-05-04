using Moonfish.Graphics;
using System;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Compiler;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Moonfish.Guerilla;
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
            var converter = new GuerillaCs(Local.GuerillaPath);
            foreach (var tag in Guerilla.Guerilla.h2Tags.Where(x=>x.Class == TagClass.Bitm))
            {
                converter.DumpTagLayout(
                    new MoonfishTagGroup(tag),
                    Path.Combine(Local.ProjectDirectory, @"Guerilla\Debug\"));
                Console.WriteLine("Exported: {0}", tag.Class);
            }
            Application.Exit();
            return;


            //StaticBenchmark.Begin();
            //for(var i = 0; i<map.Index.Count; ++i)
            //{
            //    var tag = map.Index[i].Identifier; 
            //    map.Deserialize(tag);
            //}
            //StaticBenchmark.End();
            //var v = StaticBenchmark.Result;

            ////return;
            //map.ClearCache(map.Index.ScenarioIdent);

            var map = new CacheStream(@"C:\Users\stem\Documents\modding\headlong.map");

            var item = map.Deserialize(map.Index.ScenarioIdent);
            map.Add((ScenarioBlock)item, "moonfish/moonfish");

            //var validator = new Validator();
            //var guerilla = new GuerillaCs(Local.GuerillaPath);
            //var files = Directory.GetFiles(Local.MapsDirectory, "*.map", SearchOption.TopDirectoryOnly);
            //foreach (var tag in Guerilla.Guerilla.h2Tags)
            //{
            //    if (!validator.Validate(new MoonfishTagGroup(tag),
            //        Guerilla.Guerilla.h2Tags.Select(x => new MoonfishTagGroup(x)), new[] { @"C:\Users\seed\Documents\Halo 2 Modding\headlong.map" }))
            //    {

            //    }
            //    else Console.WriteLine("{0} failed", tag.Class);
            //    Application.DoEvents();
            //}

            //return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gizmo());
        }
    }
}