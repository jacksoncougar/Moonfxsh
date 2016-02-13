using System.Collections.Generic;
using OpenTK;

namespace Moonfish.Graphics
{
    public interface IWorldMatrix
    {
        Matrix4 WorldMatrix { get; set; }
    };

    public static class NodeExtensions
    {
    }
}