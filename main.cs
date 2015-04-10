using Moonfish.Graphics;
using System;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Guerilla;
using Moonfish.Forms;

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
            //GuerillaToEnt ripperEnt = new GuerillaToEnt(Local.GuerillaPath);
            //foreach (var tag in Guerilla.Guerilla.h2Tags)
            //{
            //    ripperEnt.DumpTagLayout(tag, Local.PluginsFolder);
            //}
            ////Validator v = new Validator();
            //return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
