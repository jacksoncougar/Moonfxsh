﻿using System;
using System.Collections.Generic;
using Moonfish.Guerilla.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public class MarkerWrapper : ISelectable
    {
        private readonly List<RenderModelNodeBlock> _nodes;

        public Matrix4 ParentWorldMatrix
        {
            get { return _nodes.GetWorldMatrix(marker.NodeIndex); }
        }

        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation(marker.Translation);
                var rotationMatrix = Matrix4.CreateFromQuaternion(marker.Rotation);
                var scaleMatrix = Matrix4.CreateScale(marker.Scale);
                return scaleMatrix*rotationMatrix*translationMatrix*_nodes.GetWorldMatrix(marker.NodeIndex);
            }
        }

        public RenderModelMarkerBlock marker;

        public MarkerWrapper(RenderModelMarkerBlock marker, List<RenderModelNodeBlock> nodes)
        {
            this.marker = marker;
            _nodes = nodes;
        }

        public Action<Matrix4> MarkerUpdatedCallback;

        public event EventHandler MarkerUpdated;

        internal void mousePole_WorldMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            var matrix = e.Matrix*ParentWorldMatrix.Inverted();
            var translation = matrix.ExtractTranslation();
            var rotation = matrix.ExtractRotation();
            marker.Translation = translation;
            marker.Rotation = rotation;
            if (MarkerUpdated != null) MarkerUpdated(this, null);
            if (MarkerUpdatedCallback != null) MarkerUpdatedCallback(WorldMatrix);
        }
    }
}