using Moonfish.Graphics;
using System;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Compiler;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
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
        private static void Main( )
        {
            
            CacheStream map = new CacheStream( @"C:\Users\seed\Documents\Halo 2 Modding\headlong.map" );

            map.Decompile(  );
            
            return;

            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            // Application.Run(new Form1());
        }
    }
}