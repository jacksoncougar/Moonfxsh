﻿using Moonfish.Graphics.Input;

namespace Moonfish.Graphics
{
    public partial class DynamicScene : Scene
    {
        public CollisionManager CollisionManager { get; set; }

        public bool DrawDebugCollision { get; set; }

        public MousePole2D MousePole { get; set; }

        public DynamicScene( )
            : base()
        {
            DrawDebugCollision = false;
            CollisionManager = new CollisionManager( base.ProgramManager.SystemProgram );
            MousePole = new MousePole2D( this.Camera );
            this.SelectedObjectChanged += OnSelectedObjectChanged;
            foreach ( var item in MousePole.ContactObjects )
                CollisionManager.World.AddCollisionObject( item );
            MousePole.Hide();
        }

        void OnSelectedObjectChanged( object seneder, SelectEventArgs e )
        {
            var marker = e.SelectedObject as MarkerWrapper;
            if ( marker != null )
            {
                MousePole.DropHandlers();
                MousePole.Show();
                MousePole.Position = marker.WorldMatrix.ExtractTranslation();
                MousePole.Rotation = marker.ParentWorldMatrix.ExtractRotation();
                MousePole.WorldMatrixChanged += marker.mousePole_WorldMatrixChanged;
            }
        }

        public override void Draw( float delta )
        {
            base.Draw( delta );
            var program = ProgramManager.GetProgram( new ShaderReference( ShaderReference.ReferenceType.System, 0 ) );
            MousePole.Render( program );
            if ( DrawDebugCollision )
                CollisionManager.World.DebugDrawWorld();
        }

        public override void Update( )
        {
            foreach ( var collisionObject in CollisionManager.World.CollisionObjectArray )
            {
                var box = collisionObject as BulletSharp.CollisionObject;
                if((box) != null && box.UserObject is MarkerWrapper)
                {
                    var worldMatrix = box.WorldTransform;
                    var scale = Camera.CreateScale(worldMatrix.ExtractTranslation(), 0.05f, 10f);
                    box.CollisionShape.LocalScaling = new OpenTK.Vector3( scale, scale, scale );
                }
            }
            CollisionManager.World.PerformDiscreteCollisionDetection();
            base.Update();
        }

    }
}