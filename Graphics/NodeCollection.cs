using Moonfish.Guerilla.Tags;
using OpenTK;
using System;
using System.Collections.Generic;

namespace Moonfish.Graphics
{
    public static class NodeCollectionExtensions
    {
        public static Matrix4 GetWorldMatrix(this IList<RenderModelNodeBlock> list, int index)
        {
            return index < 0 ? Matrix4.Identity : list.GetWorldMatrix(list[index]);
        }

        public static Matrix4 GetWorldMatrix(this IList<RenderModelNodeBlock> list, RenderModelNodeBlock node)
        {
            if (!list.Contains(node)) throw new ArgumentOutOfRangeException();

            var worldMatrix = node.WorldMatrix;
            if ((int)node.parentNode < 0) return worldMatrix;
            return worldMatrix * list.GetWorldMatrix(list[(int)node.parentNode]);
        }
    };
}
