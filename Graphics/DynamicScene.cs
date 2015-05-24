using System;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public partial class DynamicScene : Scene
    {
        public CollisionManager CollisionManager { get; set; }

        public bool DrawDebugCollision { get; set; }

        public RotationGizmo MousePole { get; set; }

        public DynamicScene()
        {
            DrawDebugCollision = false;
            CollisionManager = new CollisionManager(ProgramManager.SystemProgram);
            MousePole = new RotationGizmo();
            Camera.CameraUpdated += MousePole.OnCameraUpdate;
            SelectedObjectChanged += OnSelectedObjectChanged;
            foreach (var item in MousePole.CollisionObjects)
                CollisionManager.World.AddCollisionObject(item);
            
#if DEBUG
            GLDebug.DebugProgram = ProgramManager.SystemProgram;
            GLDebug.ScreenspaceProgram = ProgramManager.ScreenProgram;
#endif
        }

        private void OnSelectedObjectChanged(object seneder, SelectEventArgs e)
        {
            if (e.SelectedObject == null)
            {
                MousePole.DropHandlers();
                MousePole.Show(false);
                return;
            }
            var item = e.SelectedObject as ScenarioCollisionObject;
            if (item != null)
            {
                var node = item.UserObject as RenderModelNodeBlock;
                MousePole.Show(true);
                MousePole.DropHandlers();
                MousePole.WorldMatrix = item.WorldTransform;
                MousePole.WorldMatrixChanged +=
                    delegate(object sender, MatrixChangedEventArgs args)
                    {
                        item.ParentObject.SetChildWorldMatrix(item.UserObject, args.Matrix);
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
            foreach (CollisionObject collisionObject in CollisionManager.World.CollisionObjectArray)
            {
                if (collisionObject.UserObject is MarkerWrapper)
                {
                    var worldMatrix = collisionObject.WorldTransform;
                    var scale = Camera.CreateScale(worldMatrix.ExtractTranslation(), 0.05f, 15f);
                    collisionObject.CollisionShape.LocalScaling = new Vector3(scale, scale, scale);
                }
            }
            CollisionManager.Update();
            base.Update();
        }
    }
}