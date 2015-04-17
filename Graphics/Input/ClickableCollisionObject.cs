using System;
using BulletSharp;

namespace Moonfish.Graphics.Input
{
    public class ScenarioCollisionObject : CollisionObject
    {
        public ScenarioObject ParentObject { get; set; }

        public void OnWorldMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            this.WorldTransform = e.Matrix;
        }
    }

    public class ClickableCollisionObject : CollisionObject
    {
        public event EventHandler<SceneMouseEventArgs> OnMouseDown;
        public event EventHandler<SceneMouseMoveEventArgs> OnMouseMove;
        public event EventHandler<SceneMouseEventArgs> OnMouseUp;
        public event EventHandler<SceneMouseEventArgs> OnMouseClick;

        public void MouseDown( object sender, SceneMouseEventArgs e )
        {
            if ( OnMouseDown != null ) OnMouseDown( sender, e );
        }

        public void MouseMove( object sender, SceneMouseMoveEventArgs e )
        {
            if ( OnMouseMove != null ) OnMouseMove( sender, e );
        }

        public void MouseUp( object sender, SceneMouseEventArgs e )
        {
            if ( OnMouseUp != null ) OnMouseUp( sender, e );
        }

        public void MouseClick( object sender, SceneMouseEventArgs e )
        {
            if ( OnMouseClick != null ) OnMouseClick( sender, e );
        }
    }
}