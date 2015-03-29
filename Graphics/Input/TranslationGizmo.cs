using Moonfish.Collision;
using OpenTK;

namespace Moonfish.Graphics.Input
{
    public class TranslationGizmo : GizmoBase
    {
        private Vector3 _translation;

        public override Matrix4 WorldMatrix
        {
            get { return CalculateWorldMatrix(position + _translation, rotation, scale); }
            set { base.WorldMatrix = value; }
        }

        private Vector3 FindPlaneNormal(Vector3 viewerAxis, Vector3 axisNormal)
        {
            var planeUNormal = UpNormalized;
            var planeVNormal = RightNormalized;
            var planeWNormal = ForwardNormalized;
            var cosineToNormalU = Vector3.Cross(planeUNormal, axisNormal).Length;
            var cosineToNormalV = Vector3.Cross(planeVNormal, axisNormal).Length;
            var cosineToNormalW = Vector3.Cross(planeWNormal, axisNormal).Length;
            var cosineToPlaneU = Vector3.Cross(planeUNormal, viewerAxis).Length - cosineToNormalU;
            var cosineToPlaneV = Vector3.Cross(planeVNormal, viewerAxis).Length - cosineToNormalV;
            var cosineToPlaneW = Vector3.Cross(planeWNormal, viewerAxis).Length - cosineToNormalW;

            var normal = cosineToPlaneU < cosineToPlaneV
                ? cosineToPlaneU < cosineToPlaneW ? planeUNormal : planeWNormal
                : cosineToPlaneV < cosineToPlaneW ? planeVNormal : planeWNormal;
            return normal;
        }
        
        protected override void Commit()
        {
            position += _translation;
            _translation = Vector3.Zero;
            base.Commit();
        }

        private void SetTranslation(Vector3 translationVector3)
        {
            var beforeMatrix = CalculateWorldMatrix(position, rotation, scale);
            var afterMatrix = CalculateWorldMatrix(position + translationVector3, rotation, scale);
            _translation = translationVector3;
            OnWorldMatrixChanged(ref beforeMatrix, ref afterMatrix);
        }

        protected override void Transform(SceneMouseMoveEventArgs args)
        {
            if (selectedAxis == Axis.None) return;
            var camera = args.Camera;

            var originScreenspace = camera.Project(position);
            var axisNormal = GetAxisNormal(selectedAxis);
            var translation_screenspace = CalculateScreenspaceTranslation(originScreenspace,
                camera.Project(position + axisNormal), new Vector2(args.X, args.Y));

            var near = camera.UnProject(originScreenspace + translation_screenspace);
            var far = camera.UnProject(originScreenspace + translation_screenspace, -0.01f);

            var mouseRay = new Ray(near, far);

            // Setup and select the collision plane
            var normal = FindPlaneNormal(mouseRay.Direction, axisNormal);
            // Produce the plane-distance from origin from this objects position vector
            var planeOffset = Vector3.Dot(normal, position);
            // We use negetive offset here
            var translationPlane = new Plane(normal, -planeOffset);

            float? distance;
            if (!translationPlane.Intersects(mouseRay, out distance)) return;

            var mouseVector = mouseRay.Origin + mouseRay.Direction * distance.GetValueOrDefault();
            var mouseProjectionLength = Vector3.Dot(axisNormal, mouseVector);
            var positionProjectionLength = Vector3.Dot(axisNormal, position);
            var translationProjectionLength = (mouseProjectionLength - positionProjectionLength);

            var vector = (translationProjectionLength * axisNormal);

            if (!(vector.Length > 0)) return;
            SetTranslation(vector);
        }
    }
}