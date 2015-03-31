using System.ComponentModel;
using BulletSharp;
using Moonfish.Graphics;
using OpenTK;

// ReSharper disable once CheckNamespace
namespace Moonfish.Guerilla.Tags
{
    [TypeConverter(typeof(MarkerGroupConverter))]
    public partial class RenderModelNodeBlock : ISelectable
    {
        public CollisionObject CollisionObject { get; set; }

        public DisplayMode Mode { get; set; }

        public enum DisplayMode
        {
            Rest,
            Pose
        }

        partial void Initialize()
        {
            Mode = DisplayMode.Pose;
            _pose = new Pose { rotation = defaultRotation, translation = defaultTranslation };
        }

        private Pose _pose;

        public Matrix4 WorldMatrix
        {
            get
            {
                return CalculateWorldMatrix(Mode);
            }
            set
            {
                switch (Mode)
                {
                    case DisplayMode.Rest:
                        defaultTranslation = value.ExtractTranslation();
                        defaultRotation = value.ExtractRotation();
                        break;
                    default:
                        _pose.translation = value.ExtractTranslation();
                        _pose.rotation = value.ExtractRotation();
                        break;
                }
            }
        }

        public Matrix4 CalculateWorldMatrix(DisplayMode displayMode)
        {
            var translation = CreateTranslation(displayMode);
            var rotation = CreateFromQuaternion(displayMode);
            return rotation * translation * Matrix4.Identity;
        }

        public Matrix4 CalculateInverseBindTransform()
        {
            var translation = CreateTranslation(DisplayMode.Rest);
            var rotation = CreateFromQuaternion(DisplayMode.Rest);
            return (rotation * translation * Matrix4.Identity).Inverted();
        }

        private Matrix4 CreateFromQuaternion(DisplayMode displayMode)
        {
            return Matrix4.CreateFromQuaternion(displayMode == DisplayMode.Rest ? defaultRotation : _pose.rotation);
        }

        private Matrix4 CreateTranslation(DisplayMode displayMode)
        {
            return Matrix4.CreateTranslation(displayMode == DisplayMode.Rest ? defaultTranslation : _pose.translation);
        }

        private struct Pose
        {
            public Vector3 translation;
            public Quaternion rotation;
        }

    };
}