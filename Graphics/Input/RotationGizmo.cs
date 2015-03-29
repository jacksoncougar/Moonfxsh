using OpenTK;

namespace Moonfish.Graphics.Input
{
    public class RotationGizmo : GizmoBase
    {
        private Quaternion _rotationDelta = Quaternion.Identity;

        public override Matrix4 WorldMatrix
        {
            get { return CalculateWorldMatrix(position, _rotationDelta * rotation, scale); }
            set { base.WorldMatrix = value; }
        }

        protected override void Commit()
        {
            selectedAxis = Axis.None;
            rotation = _rotationDelta * rotation;
            rotation.Normalize();
            _rotationDelta = Quaternion.Identity;
            SelectAxis(Axis.None);
        }

        protected void SetTransform(float degrees)
        {
            var axisNormal = GetAxisNormal(selectedAxis);
            var radians = OpenTK.MathHelper.DegreesToRadians(degrees);

            _rotationDelta = Quaternion.FromAxisAngle(axisNormal, radians);

            var beforeMatrix = CalculateWorldMatrix(position, rotation, scale);
            var afterMatrix = CalculateWorldMatrix(position, _rotationDelta * rotation, scale);
            OnWorldMatrixChanged(ref beforeMatrix, ref afterMatrix);
        }

        protected override void Transform(SceneMouseMoveEventArgs args)
        {
            if (selectedAxis == Axis.None) return;
            var camera = args.Camera;

            var originScreenspace = camera.Project(position);
            var axisNormal = GetAxisNormal(selectedAxis);

            var normalScreenspace = camera.Project(position + axisNormal).Normalized();

            var translation = CalculateScreenspaceTranslation(originScreenspace,
                camera.Project(position + axisNormal), new Vector2(args.X, args.Y));
            SetTransform(Vector2.Dot(translation, normalScreenspace));
        }
    }
}