using Moonfish.Guerilla.Tags;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    public class NodeCollection : List<RenderModelNodeBlock>
    {
        public NodeCollection()
            : base()
        {
        }

        public NodeCollection(int capacity)
            : base(capacity)
        {
        }

        public NodeCollection(IEnumerable<RenderModelNodeBlock> collection)
            : base(collection)
        {
        }

        public Matrix4 GetWorldMatrix(int index)
        {
            if (index < 0) return Matrix4.Identity;
            else return GetWorldMatrix(this[index]);
        }

        public Matrix4 GetWorldMatrix(RenderModelNodeBlock node)
        {
            if (!this.Contains(node)) throw new ArgumentOutOfRangeException();

            var worldMatrix = node.WorldMatrix;
            if ((int)node.parentNode < 0) return worldMatrix;
            return worldMatrix * GetWorldMatrix(this[(int)node.parentNode]);
        }
    };
}
