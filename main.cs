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
            using (var map = new Moonfish.Cache.CacheStream(Path.Combine(Local.MapsDirectory, @"output.map")))
            using (var output = new FileStream(Path.Combine(Local.MapsDirectory, @"output1.map"), FileMode.Create,
                    FileAccess.Write, FileShare.ReadWrite, 4 * 1024, FileOptions.SequentialScan))
            {
                map.SaveTo(output);
            } 
            return;
            {
                var test = new Moonfish.Cache.CacheStream(Path.Combine(Local.MapsDirectory, @"output.map"));
                test.Seek(test.Index.GlobalsIdent);
                var position = test.GetFilePosition();

                var buggery = test.GetOwner(187923790);
                //test.Deserialize(buggery.Identifier);

                var localOffset = 187923790 - test.VirtualAddressToFileOffset(buggery.VirtualAddress);

                foreach (var data in test.Index)
                {
                    test.Deserialize(data.Identifier);
                }
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Gizmo());
        }
    }
}