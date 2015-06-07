using System.Drawing;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;

namespace Moonfish.Graphics
{
    public partial class DynamicScene : Scene
    {
        public ConvexHullCaster caster;

        public DynamicScene( )
        {
            caster = new ConvexHullCaster( );
            DrawDebugCollision = false;
            CollisionManager = new CollisionManager( ProgramManager.SystemProgram );
            MousePole = new TranslationGizmo( );
            Camera.CameraUpdated += MousePole.OnCameraUpdate;
            SelectedObjectChanged += OnSelectedObjectChanged;
            SelectedObjectChanged += caster.OnSelectedObjectChanged;
            MouseMove += caster.OnMouseMove;
            MouseUp += caster.OnMouseUp;
            foreach ( var item in MousePole.CollisionObjects )
                CollisionManager.World.AddCollisionObject( item );

#if DEBUG
            GLDebug.DebugProgram = ProgramManager.SystemProgram;
            GLDebug.ScreenspaceProgram = ProgramManager.ScreenProgram;
#endif
        }

        public CollisionManager CollisionManager { get; set; }
        public bool DrawDebugCollision { get; set; }
        public TranslationGizmo MousePole { get; set; }

        public override void Draw( float delta )
        {
            base.Draw( delta );
            ObjectManager.Draw( ProgramManager, MousePole.Model );

            //if (DrawDebugCollision)
            //CollisionManager.World.DebugDrawWorld();

#if DEBUG
            GLDebug.DrawLine( caster.debugPoint0, caster.debugPoint1, Color.Red, 5 );
            GLDebug.DrawPoint(caster.debugPoint2, Color.GreenYellow, 5);
#endif
            //GLDebug.DrawPoint(caster.debugPoint2, Color.Gold, 5);
            //GLDebug.DrawPoint(caster.debugPoint3, Color.DodgerBlue, 5);
        }

        public override void Update( )
        {
            //CollisionManager.Update();
            base.Update( );
        }

        private void OnSelectedObjectChanged( object seneder, SelectEventArgs e )
        {
            //if (e.SelectedObject == null)
            //{
            //    MousePole.DropHandlers();
            //    MousePole.Show(false);
            //    return;
            //}
            //var item = e.SelectedObject as CollisionObject;
            //if (item != null)
            //{
            //    var scenarioObject = item.UserObject as ScenarioObject;
            //    if ( scenarioObject == null ) return;

            //    MousePole.Show(true);
            //    MousePole.DropHandlers();
            //    MousePole.WorldMatrix = item.WorldTransform;
            //    MousePole.WorldMatrixChanged +=
            //        delegate(object sender, MatrixChangedEventArgs args)
            //        {
            //            scenarioObject.WorldMatrix = args.Matrix.ClearScale(  );
            //        };
            //}
        }
    }
}