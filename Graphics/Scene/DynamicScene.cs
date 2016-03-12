using System;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public partial class DynamicScene : Scene
    {
        public ConvexHullCaster caster;

        public DynamicScene( Control ownerControl ) : this( )
        {
            ownerControl.MouseDown += Camera.OnMouseDown;
            ownerControl.MouseMove += Camera.OnMouseMove;
            ownerControl.MouseUp += Camera.OnMouseUp;
            ownerControl.MouseCaptureChanged += Camera.OnMouseCaptureChanged;
            ownerControl.KeyDown +=
                delegate( object sender1, KeyEventArgs e1 )
                {
                    if ( e1.KeyCode == Keys.X )
                        Camera.LookAt( GetLocationOf( SelectedObject ) );
                    if ( e1.KeyCode == Keys.Z )
                        Camera.ZoomTo( SelectedObject );
                };
            ownerControl.MouseDown += OnMouseDown;
            ownerControl.MouseMove += OnMouseMove;
            ownerControl.MouseUp += OnMouseUp;
            ownerControl.MouseClick += OnMouseClick;
        }

        public DynamicScene( )
        {
            caster = new ConvexHullCaster( );
            SceneUpdate += caster.OnUpdate;
            DrawDebugCollision = false;
            CollisionManager = new CollisionManager( ProgramManager.DebugShader );
            MousePole = new TranslationGizmo( );
            MousePole.Show( true );
            Camera.CameraUpdated += MousePole.OnCameraUpdate;
            SelectedObjectChanged += OnSelectedObjectChanged;
            SelectedObjectChanged += caster.OnSelectedObjectChanged;
            MouseMove += caster.OnMouseMove;
            MouseUp += caster.OnMouseUp;
            foreach ( var item in MousePole.CollisionObjects )
                CollisionManager.World.AddCollisionObject( item, CollisionFilterGroups.SensorTrigger, CollisionFilterGroups.SensorTrigger );

#if DEBUG
            OpenGL.EnableDebugging( );
#endif
        }

        public CollisionManager CollisionManager { get; set; }
        public bool DrawDebugCollision { get; set; }
        public TranslationGizmo MousePole { get; set; }

        private event EventHandler SceneUpdate;

        public override void Update( float delta, float currentTime )
        {
#if DEBUG
            //CollisionManager.World.DebugDrawWorld();
#endif

            SceneUpdate?.Invoke(this, new EventArgs(  ));

            //Manager.Update( );
            base.Update( delta, currentTime );
        }

        private void OnSelectedObjectChanged( object seneder, SelectEventArgs e )
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
                var objectBlock = item.UserObject as ObjectBlock;
                if (objectBlock == null) return;

                MousePole.Show(true);
                MousePole.DropHandlers();
                MousePole.WorldMatrix = item.WorldTransform;
                MousePole.WorldMatrixChanged +=
                    delegate( object sender, MatrixChangedEventArgs args )
                    {
                        CollisionManager.Move( item, args.Matrix.ClearScale(  ));
                        //Manager.UpdateInstance( objectBlock, item.UserIndex, item.WorldTransform );
                    };
            }
        }

        public Vector3 GetLocationOf( object selectedObject)
        {
            var item = selectedObject as CollisionObject;
            var objectBlock = item?.UserObject as ObjectBlock;

            //if ( objectBlock != null && Manager.Instances.ContainsKey( objectBlock ) )
            //    return Manager.Instances[ objectBlock ][ item.UserIndex ].ExtractTranslation( );

            return Vector3.Zero;
        }

        public void UpdatePhysics( )
        {
            CollisionManager.Update( );
        }
    }
}