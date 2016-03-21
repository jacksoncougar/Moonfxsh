using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryPartBlockNew : IComparable<GlobalGeometryPartBlockNew>
    {
        private static int uniquePartIdentidifer;

        private static int CreateUniquePartIdentifier
        {
            get { return uniquePartIdentidifer++; }
        }

        public int CompareTo( GlobalGeometryPartBlockNew other )
        {
            return PartIdentifier.CompareTo( other.PartIdentifier );
        }

        public override int GetHashCode( )
        {
            return PartIdentifier;
        }

        private int PartIdentifier { get; } = CreateUniquePartIdentifier;

        public PrimitiveType PrimitiveType
        {
            get
            {
                return GlobalGeometryPartNewFlags.HasFlag( Flags.OverrideTriangleList )
                    ? PrimitiveType.Triangles
                    : PrimitiveType.TriangleStrip;
            }
        }
    }
}
