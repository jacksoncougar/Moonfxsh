using System;
using System.Collections.Generic;
using Moonfish.Guerilla.Tags;
using OpenTK;

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
            if (node.parentNode < 0) return worldMatrix;
            return worldMatrix * list.GetWorldMatrix(list[node.parentNode]);
        }


        public static Matrix4 GetPoseTransfrom(this IList<RenderModelNodeBlock> list, int index)
        {
            return index < 0 ? Matrix4.Identity : list.GetPoseTransfrom(list[index]);
        }

        public static Matrix4 GetPoseTransfrom(this IList<RenderModelNodeBlock> list, RenderModelNodeBlock node)
        {
            if (!list.Contains(node)) throw new ArgumentOutOfRangeException();

            var worldMatrix = node.WorldMatrix;
            if (node.parentNode < 0) return worldMatrix;
            return worldMatrix * list.GetWorldMatrix(list[node.parentNode]);
        }

        public static Matrix4 GetBindPoseTransfrom(this IList<RenderModelNodeBlock> list, int index)
        {
            return index < 0 ? Matrix4.Identity : list.GetBindPoseTransfrom(list[index]);
        }

        public static Matrix4 GetBindPoseTransfrom(this IList<RenderModelNodeBlock> list, RenderModelNodeBlock node)
        {
            if (!list.Contains(node)) throw new ArgumentOutOfRangeException();

            var inverseBindPoseTransfrom = node.CalculateWorldMatrix(RenderModelNodeBlock.DisplayMode.Rest);
            if (node.parentNode < 0) return inverseBindPoseTransfrom;
            return list.GetBindPoseTransfrom(list[node.parentNode]) * inverseBindPoseTransfrom;
        }

        public static Matrix4 GetInverseBindPoseTransfrom(this IList<RenderModelNodeBlock> list, int index)
        {
            return index < 0 ? Matrix4.Identity : list.GetInverseBindPoseTransfrom(list[index]);
        }

        public static Matrix4 GetInverseBindPoseTransfrom(this IList<RenderModelNodeBlock> list, RenderModelNodeBlock node)
        {
            if (!list.Contains(node)) throw new ArgumentOutOfRangeException();

            var inverseBindPoseTransfrom = node.CalculateInverseBindTransform();
            if (node.parentNode < 0) return inverseBindPoseTransfrom;
            return list.GetInverseBindPoseTransfrom(list[node.parentNode]) * inverseBindPoseTransfrom;
        }

        public static void SetWorldMatrix(this IList<RenderModelNodeBlock> list, int index, Matrix4 value)
        {
            SetWorldMatrix(list, list[index], value);
        }

        public static void SetWorldMatrix(this IList<RenderModelNodeBlock> list, RenderModelNodeBlock node, Matrix4 value)
        {
            if (!list.Contains(node)) throw new ArgumentOutOfRangeException();

            var matrix = node.parentNode < 0
                ? value
                : value * list.GetWorldMatrix(list[node.parentNode]).Inverted();

            node.WorldMatrix = matrix;
        }
    };
}
