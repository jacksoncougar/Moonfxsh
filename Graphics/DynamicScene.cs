using Moonfish.Graphics.Input;

namespace Moonfish.Graphics
{
    public partial class DynamicScene : Scene
    {
        public CollisionManager CollisionManager { get; set; }

        public MousePole2D MousePole { get; set; }

        public DynamicScene( )
            : base()
        {
            CollisionManager = new CollisionManager( base.ProgramManager.SystemProgram );
            MousePole = new MousePole2D( this.Camera );
        }

        public override void Draw( float delta )
        {
            base.Draw( delta );
            MousePole.Render(null);
            CollisionManager.World.DebugDrawWorld();
        }


    }
}
