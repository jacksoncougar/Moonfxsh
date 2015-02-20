using Moonfish.Debug;
using Moonfish.Graphics;
using Moonfish.Guerilla;
using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Moonfish
{
    static class main
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GuerillaToEnt ripperEnt = new GuerillaToEnt(@"C:\Users\seed\Documents\Halo 2 Modding\H2Guerilla.exe");
            //ripperEnt.DumpTagLayout(@"C:\Users\seed\Documents\plugins");
            //return;

            //GuerillaCs ripper = new GuerillaCs(@"C:\Users\seed\Documents\Halo 2 Modding\H2Guerilla.exe");

            //ripper.DumpTagLayout(@"C:\Users\seed\Documents\Visual Studio 2012\Projects\Moonfish2015\Moonfish2015\Guerilla\Tags", "bitm", "");
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShaderViewer());
        }
    }
}
