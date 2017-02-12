using System;
using System.Windows.Forms;
using System.IO;
using Moonfish.Cache;

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