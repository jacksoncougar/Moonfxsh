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
            //GuerillaCodeDom.GenerateGuerillaCode(TagClass.Phmo);
            //CacheStream map = new CacheStream(Path.Combine(Local.MapsDirectory, "lockout.map"));
            //foreach (var datum in map.Index)
            //{
            //    new Validator().Validate(datum, map);
            //}
            //var cache = CacheStream.SaveAs( map, Path.Combine( Local.MapsDirectory, "headlong.map") );
            //foreach ( var datum in cache.Index )
            //{
            //    new Validator( ).Validate( datum, cache );
            //}
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DatumViewer());
        }
    }
}