using System;
using System.Reflection;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;
using OpenTK;
using Fasterflect;
using MousePole = Moonfish.Graphics.Input.MousePole;

namespace Moonfish.Graphics
{
    public partial class DynamicScene : Scene
    {
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
            GLDebug.DebugProgram = ProgramManager.SystemProgram;
            GLDebug.ScreenspaceProgram = ProgramManager.ScreenProgram;
        }

        void OnSelectedObjectChanged(object seneder, SelectEventArgs e)
        {
            var marker = e.SelectedObject as MarkerWrapper;
            if (marker != null)
            {
                MousePole.WorldMatrix = marker.WorldMatrix;
                MousePole.DropHandlers();
                MousePole.WorldMatrixChanged += marker.mousePole_WorldMatrixChanged;
            }
        }

        public override void Draw(float delta)
        {
            base.Draw(delta);

            ObjectManager.Draw(ProgramManager, MousePole.Model);

            if (DrawDebugCollision || true)
                CollisionManager.World.DebugDrawWorld();
        }

        public override void Update()
        {
            foreach (CollisionObject collisionObject in CollisionManager.World.CollisionObjectArray)
            {
                var box = collisionObject;
                if ((box) != null && box.UserObject is MarkerWrapper)
                {
                    var worldMatrix = box.WorldTransform;
                    var scale = Camera.CreateScale(worldMatrix.ExtractTranslation(), 0.05f, 15f);
                    box.CollisionShape.LocalScaling = new Vector3(scale, scale, scale);
                }
            }
            CollisionManager.World.PerformDiscreteCollisionDetection();
            base.Update();
        }

    }
}
