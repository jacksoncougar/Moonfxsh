using Moonfish.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;
using Moonfish.Cache;
using Moonfish.Forms;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var _cacheStream = CacheStream.Open(Path.Combine(Local.MapsDirectory, "ascension.map"));
        }
    }
}