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
            GuerillaCodeDom.GenerateGuerillaCode();
            var map = new CacheStream(Path.Combine(Local.MapsDirectory, @"singleplayer\05a_deltaapproach.map"));
            var output = new FileStream(Path.Combine(Local.MapsDirectory, @"output.map"), FileMode.Create, FileAccess.Write, FileShare.None, 4 * 1024, FileOptions.SequentialScan);
            map.SaveTo(output);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Gizmo());
        }
    }
}