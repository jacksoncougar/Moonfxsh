using Moonfish.Graphics;
using System;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Compiler;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish
{
    static class main
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main( )
        {
            //GuerillaToEnt ripperEnt = new GuerillaToEnt(Local.GuerillaPath);
            //foreach (var tag in Guerilla.Guerilla.h2Tags)
            //{
            //    ripperEnt.DumpTagLayout(tag, Local.PluginsFolder);
            //}
            ////Validator v = new Validator();
            //return;

            GuerillaCs guerilla = new GuerillaCs(Local.GuerillaPath);
            foreach (var tag in Guerilla.Guerilla.h2Tags)
            {
                guerilla.DumpTagLayout(tag, @"C:\Users\seed\Documents\Visual Studio 2012\Projects\Moonfxsh\Guerilla\Tags");
                Application.DoEvents();
            }
            return;

            MapStream map = new MapStream( @"C:\Users\seed\Documents\Halo 2 Modding\headlong.map" );
            var bitmap = map[ "bitm", "scenario" ].Deserialize( ) as IGuerilla;

            const string folder = @"C:\Users\seed\Documents\Visual Studio 2012\Projects\Moonfxsh\Guerilla\Debug\";
            var filename = Path.Combine( folder, Path.ChangeExtension( "scenario", ".bitm" ) );
            using ( var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite) )
            {
                var binaryWriter = new BinaryWriter( fileStream );
                bitmap.Write( binaryWriter );
            }

            Decompiler d = new Decompiler( );
            //d.Decompile(new MapStream(@"C:\Users\seed\Documents\Halo 2 Modding\headlong.map"));
            return;

            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            // Application.Run(new Form1());
        }
    }
}
