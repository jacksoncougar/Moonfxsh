using Moonfish.Guerilla.Tags;
using OpenTK;
using System;

namespace Moonfish.Graphics
{
    public class MarkerWrapper : ISelectable
    {
        private NodeCollection nodes;

        public Matrix4 ParentWorldMatrix
        {
            get
            {
                return nodes.GetWorldMatrix( this.marker.nodeIndex );
            }
        }

        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation( this.marker.Translation );
                var rotationMatrix = Matrix4.CreateFromQuaternion( this.marker.Rotation );
                var scaleMatrix = Matrix4.CreateScale( this.marker.Scale );
                return scaleMatrix * rotationMatrix * translationMatrix * nodes.GetWorldMatrix( this.marker.nodeIndex );
            }
        }

        public RenderModelMarkerBlock marker;

        public MarkerWrapper( RenderModelMarkerBlock marker, NodeCollection nodes )
        {
            this.marker = marker;
            this.nodes = nodes;
        }

        public Action<Matrix4> MarkerUpdatedCallback;

        public event EventHandler MarkerUpdated;

        internal void mousePole_WorldMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            var translation = e.Delta.ExtractTranslation();
            this.marker.Translation += translation;
            if ( MarkerUpdated != null ) MarkerUpdated( this, null );
            if ( MarkerUpdatedCallback != null ) MarkerUpdatedCallback( this.WorldMatrix );
        }
    }
}
