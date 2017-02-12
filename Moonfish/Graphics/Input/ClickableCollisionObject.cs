using System;
using BulletSharp;

namespace Moonfish.Graphics.Input
{
    public class ScenarioCollisionObject : CollisionObject
    {
        public ScenarioObject ParentObject { get; set; }

        public void OnWorldMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            this.WorldTransform = e.Matrix;
        }
    }

    public class ClickableCollisionObject : CollisionObject, IClickable
    {
        public event EventHandler<SceneMouseEventArgs> MouseDown;
        public event EventHandler<SceneMouseEventArgs> MouseMove;
        public event EventHandler<SceneMouseEventArgs> MouseUp;
        public event EventHandler<SceneMouseEventArgs> MouseClick;
        public event EventHandler<SceneMouseEventArgs> MouseCaptureChanged;

        public void OnMouseDown(object sender, SceneMouseEventArgs e)
        {
            MouseDown?.Invoke(sender, e);
        }

        public void OnMouseMove(object sender, SceneMouseEventArgs e)
        {
            MouseMove?.Invoke(sender, e);
        }

        public void OnMouseUp(object sender, SceneMouseEventArgs e)
        {
            MouseUp?.Invoke(sender, e);
        }

        public void OnMouseClick(object sender, SceneMouseEventArgs e)
        {
            MouseClick?.Invoke(sender, e);
        }

        public void OnMouseCaptureChanged(object sender, SceneMouseEventArgs e)
        {
            MouseCaptureChanged?.Invoke(sender, e);
        }
    }
}