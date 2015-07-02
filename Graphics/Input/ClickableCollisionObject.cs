using System;
using System.Diagnostics;
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
            Debug.WriteLine("OnMouseDown on {0}", UserObject);
            if (MouseDown != null) MouseDown(sender, e);
        }

        public void OnMouseMove(object sender, SceneMouseEventArgs e)
        {
            Debug.WriteLine("OnMouseMove on {0}", UserObject);
            if (MouseMove != null) MouseMove(sender, e);
        }

        public void OnMouseUp(object sender, SceneMouseEventArgs e)
        {
            Debug.WriteLine("OnMouseUp on {0}", UserObject);
            if (MouseUp != null) MouseUp(sender, e);
        }

        public void OnMouseClick(object sender, SceneMouseEventArgs e)
        {
            Debug.WriteLine("OnMouseClick on {0}", UserObject);
            if (MouseClick != null) MouseClick(sender, e);
        }

        public void OnMouseCaptureChanged(object sender, SceneMouseEventArgs e)
        {
            Debug.WriteLine("OnMouseCaptureChanged on {0}", UserObject);
            if (MouseCaptureChanged != null) MouseCaptureChanged(sender, e);
        }
    }
}