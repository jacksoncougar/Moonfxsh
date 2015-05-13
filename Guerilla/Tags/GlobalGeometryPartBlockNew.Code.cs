using Moonfish.Graphics;
using OpenTK.Graphics.OpenGL;
using System;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryPartBlockNew
    {
        public void Draw()
        {
            GL.DrawElements(PrimitiveType.TriangleStrip, StripLength, DrawElementsType.UnsignedShort,
                (IntPtr) (StripStartIndex*2));
            OpenGL.ReportError();
        }
    }
}