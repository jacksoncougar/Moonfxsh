using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TextEditor.Actions;
using Moonfish.Cache;
using Moonfish.Graphics;
using Moonfish.Guerilla.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms.ShaderForm
{
    public partial class AsmEditor : DockContent
    {
        public AsmEditor( string title )
        {
            InitializeComponent( );
            Text = title;
        }

        public void SetText(string text )
        {
            textEditorControl1.Text = text;
            textEditorControl1.Refresh();
        }

        public void DisplayVertexInstructions( TagDatum vertexDatum, Map cache )
        {
            var vertexBlock = ( VertexShaderBlock ) cache.Deserialize( vertexDatum.Identifier );
            var code = vertexBlock.GeometryClassifications[0].Code;
            var altCode = vertexBlock.GeometryClassifications[0].CompiledShader;
            var strBuilder = new StringBuilder();
            foreach ( var s in altCode )
            {
                strBuilder.Append( "$ " + s + " " );
            }
            strBuilder.AppendLine();
            if ( code.Length < 4 )
            {
                textEditorControl1.Text = strBuilder.ToString();
                textEditorControl1.Refresh(  );
                return;
            }
            using ( BinaryReader binaryReader = new BinaryReader( new MemoryStream( code ) ) )
            {
                    var version = binaryReader.ReadInt16( );
                    strBuilder.AppendLine( "#" + version );
                    var instructionCount = binaryReader.ReadInt16( );
                    for ( int i = 0; i < instructionCount; i++ )
                    {
                        var instructionBytes = binaryReader.ReadBytes( 16 );
                        var instruction = new VertexProgramInstruction( instructionBytes );
                        strBuilder.AppendLine( instruction.ToAsm );
                    }
                
            }
            textEditorControl1.Text = strBuilder.ToString( );
            textEditorControl1.Refresh();
        }
    };
}
