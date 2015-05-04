using System.Collections.Generic;
using OpenTK;

namespace Moonfish.Graphics
{
    public interface IWorldMatrix
    {
        Matrix4 WorldMatrix { get; set; }
    };

    public interface INode : IWorldMatrix
    {
        INode Parent { get; set; }
        IList<INode> ChildrenList { get; set; }
    };

    public static class NodeExtensions
    {
        public static Matrix4 GetWorldMatrix(this INode node)
        {
            return node == null ? Matrix4.Identity : node.WorldMatrix;
        }
    }
}