using System.Collections.Generic;

namespace Moonfish.Graphics
{
    public interface IRenderable
    {
        void Render( IEnumerable<Program> shaderPasses );
    }
}