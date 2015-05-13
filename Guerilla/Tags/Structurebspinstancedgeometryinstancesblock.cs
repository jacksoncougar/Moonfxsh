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
                    new Vector4(this.Forward, 0),
                    new Vector4(this.Left, 0),
                    new Vector4(this.Up, 0),
                    new Vector4(this.Position, 1)
                    );
            }
        }
    }
}