using OpenTK;

namespace Moonfish.Guerilla.Tags
{
    partial class StructureBspInstancedGeometryInstancesBlock
    {
        public Matrix4 WorldMatrix
        {
            get
            {
                return new Matrix4(
                    new Vector4( this.forward, 0 ),
                    new Vector4( this.left, 0 ),
                    new Vector4( this.up, 0 ),
                    new Vector4( this.position, 1 )
                    );
            }
        }
    }
}