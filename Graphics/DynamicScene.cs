using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    public class DynamicScene : Scene
    {
        CollisionManager CollisionManager;

        DynamicScene()
            : base()
        {
            CollisionManager = new CollisionManager(base.ProgramManager.SystemProgram);
         
        }


    }
}
