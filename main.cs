using Moonfish.Graphics;
using System;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Compiler;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            //var converter = new GuerillaCs(Local.GuerillaPath);
            //var tags = Guerilla.Guerilla.h2Tags
            //    .Select(x => new MoonfishTagGroup(x)).ToList();
            //foreach (var tag in tags.Where(x => x.Class == TagClass.Scnr))
            //{
            //    var blockClass = new GuerillaBlockClass(tag, tags);
            //    blockClass.GenerateCSharpCode();
            //}

            var map = new CacheStream(@"C:\Users\stem\Documents\modding\headlong.map");

            var test = new Guerilla.Tags.Experimental.ScenarioBlock();

            map.Seek(map.Index.First(x => x.Class == TagClass.Scnr).Identifier);

            StaticBenchmark.Begin("test.Read()");
            var binaryReader = new BinaryReader(map);
            test.Read(binaryReader);
            StaticBenchmark.End();

            var memoryStream = new MemoryStream();
            binaryReader = new BinaryReader(memoryStream, Encoding.Default, true);
            StaticBenchmark.Begin("test.Write()");
            for (int i = 0; i < 3000; ++i)
            {
                memoryStream.Position = 0;
                memoryStream.Write(test);
                memoryStream.Position = 0;
                test.Read(binaryReader);
            }
            StaticBenchmark.End();
            var stop = 0;
            //map.Seek(map.Index.ScenarioIdent);

            //binaryReader = new BinaryReader(map);
            //StaticBenchmark.Begin();
            //test.Read(binaryReader);
            //StaticBenchmark.End();
            //stop = 0;
            ////StaticBenchmark.Begin();
            ////for(var i = 0; i<map.Index.Count; ++i)
            ////{
            ////    var tag = map.Index[i].Identifier; 
            ////    map.Deserialize(tag);
            ////}
            ////StaticBenchmark.End();
            ////var v = StaticBenchmark.Result;

            //////return;
            ////map.ClearCache(map.Index.ScenarioIdent);


            //var item = map.Deserialize(map.Index.ScenarioIdent);
            //map.Add((ScenarioBlock)item, "moonfish/moonfish");

            ////var validator = new Validator();
            ////var guerilla = new GuerillaCs(Local.GuerillaPath);
            ////var files = Directory.GetFiles(Local.MapsDirectory, "*.map", SearchOption.TopDirectoryOnly);
            ////foreach (var tag in Guerilla.Guerilla.h2Tags)
            ////{
            ////    if (!validator.Validate(new MoonfishTagGroup(tag),
            ////        Guerilla.Guerilla.h2Tags.Select(x => new MoonfishTagGroup(x)), new[] { @"C:\Users\seed\Documents\Halo 2 Modding\headlong.map" }))
            ////    {

            ////    }
            ////    else Console.WriteLine("{0} failed", tag.Class);
            ////    Application.DoEvents();
            ////}

            ////return;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Gizmo());
        }
    }
}