using System;
using System.Threading;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics;

namespace Moonfish.Graphics
{
    public partial class DynamicScene : Scene
    {
        private GLControl _graphicsContext;

        public CollisionManager CollisionManager { get; set; }

        public bool DrawDebugCollision { get; set; }

        public TranslationGizmo MousePole { get; set; }

        public DynamicScene()
        {
            DrawDebugCollision = false;
            CollisionManager = new CollisionManager(ProgramManager.SystemProgram);
            MousePole = new TranslationGizmo();
            Camera.CameraUpdated += MousePole.OnCameraUpdate;
            SelectedObjectChanged += OnSelectedObjectChanged;
            foreach (var item in MousePole.CollisionObjects)
                CollisionManager.World.AddCollisionObject(item);
            
#if DEBUG
            GLDebug.DebugProgram = ProgramManager.SystemProgram;
            GLDebug.ScreenspaceProgram = ProgramManager.ScreenProgram;
#endif
        }

        public DynamicScene(GLControl graphicsContext) : this()
        {
            _graphicsContext = graphicsContext;
        }

        private void OnSelectedObjectChanged(object seneder, SelectEventArgs e)
        {
            if (e.SelectedObject == null)
            {
                MousePole.DropHandlers();
                MousePole.Show(false);
                return;
            }
            var item = e.SelectedObject as CollisionObject;
            if (item != null)
            {
                var scenarioObject = item.UserObject as ScenarioObject;
                if ( scenarioObject == null ) return;

                MousePole.Show(true);
                MousePole.DropHandlers();
                MousePole.WorldMatrix = item.WorldTransform;
                MousePole.WorldMatrixChanged +=
                    delegate(object sender, MatrixChangedEventArgs args)
                    {
                        scenarioObject.WorldMatrix = args.Matrix.ClearScale(  );
                    };
            }
        }

        public override void Draw(float delta)
        {
            base.Draw(delta);
            ObjectManager.Draw(ProgramManager, MousePole.Model);

            if (DrawDebugCollision)
                CollisionManager.World.DebugDrawWorld();
        }

        public override void Update()
        {
            CollisionManager.Update();
            base.Update();
        }
    }
}