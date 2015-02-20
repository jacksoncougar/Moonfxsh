using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public class RenderObject : IRenderable
    {
        public Color DiffuseColour { get; set; }

        protected List<Mesh> sectionBuffers;

        public RenderObject( )
        {
            sectionBuffers = new List<Mesh>( );
        }

        public RenderObject( StructureBspClusterBlock item )
        {
            sectionBuffers = new List<Mesh>( new[] { new Mesh( item.clusterData[0].section ) } );
        }

        public RenderObject( StructureBspInstancedGeometryDefinitionBlock item )
        {
            sectionBuffers = new List<Mesh>( new[] { new Mesh( item.renderInfo.renderData[0].section ) } );
        }

        public virtual void Render( Program program )
        {
            if( sectionBuffers.Count == 0 ) return;
            using( program.Use( ) )
            {
                int colourAttribute = program.GetAttributeLocation("colour");
                program.SetAttribute(colourAttribute, new ColorF(DiffuseColour).ToArray());

                using( sectionBuffers.First( ).Bind( ) )
                {
                    foreach( var part in sectionBuffers.First( ).Parts )
                    {
                        GL.DrawElements( PrimitiveType.Triangles, part.stripLength, DrawElementsType.UnsignedShort,
                            (IntPtr)( part.stripStartIndex * 2 ) ); OpenGL.ReportError( );
                    }
                }
            }
        }

        void IRenderable.Render( IEnumerable<Program> shaderPasses )
        {
            foreach( var pass in shaderPasses )
            {
                this.Render( pass );
            }
        }
    }
}
