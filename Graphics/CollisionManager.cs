using System;
using System.Linq;
using BulletSharp;
using Moonfish.Guerilla.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public class CollisionManager
    {
        public CollisionWorld World { get; private set; }

        public CollisionManager(Program debug)
        {
            var defaultCollisionConfiguration = new DefaultCollisionConfiguration();
            var collisionDispatcher = new CollisionDispatcher(defaultCollisionConfiguration);
            var broadphase = new DbvtBroadphase();
            this.World = new CollisionWorld(collisionDispatcher, broadphase, defaultCollisionConfiguration);
            if (debug != null)
                this.World.DebugDrawer = new BulletDebugDrawer(debug);
        }

        public void LoadScenarioObjectCollision(ScenarioObject scenarioObject)
        {
            foreach (var marker in scenarioObject.Model.RenderModel.markerGroups.SelectMany(x => x.markers))
            {
                var collisionObject = new CollisionObject
                {
                    CollisionShape = new BoxShape(0.015f),

                    WorldTransform = Matrix4.CreateFromQuaternion(marker.rotation) * 
                    Matrix4.CreateTranslation(marker.translation) *
                        scenarioObject.Nodes.GetWorldMatrix(marker.nodeIndex),
                    UserObject = scenarioObject.Markers[marker]
                };

                World.AddCollisionObject(collisionObject);

                var setPropertyMethodInfo = typeof(CollisionObject).GetProperty("WorldTransform").GetSetMethod();
                var setProperty = Delegate.CreateDelegate(typeof(Action<Matrix4>), collisionObject, setPropertyMethodInfo);

                scenarioObject.Markers[marker].MarkerUpdatedCallback += (Action<Matrix4>)setProperty;
            }
        }

        internal void LoadScenarioCollision(ScenarioStructureBspBlock structureBSP)
        {

            foreach (var cluster in structureBSP.clusters)
            {
                var vertices = new Vector3[cluster.clusterData[0].section.vertexBuffers[0].vertexBuffer.Data.Length / 12];
                for (var i = 0; i < vertices.Length; ++i)
                {
                    var data = cluster.clusterData[0].section.vertexBuffers[0].vertexBuffer.Data;
                    vertices[i] = new Vector3(
                        BitConverter.ToSingle(data, i * 12 + 0),
                        BitConverter.ToSingle(data, i * 12 + 4),
                        BitConverter.ToSingle(data, i * 12 + 8));
                }
                var triangleIndexVertexArray = new TriangleIndexVertexArray(
                    cluster.clusterData[0].section.stripIndices.Select(x => (int)x.index).ToArray(), vertices);

                var collisionObject = new CollisionObject
                {
                    CollisionShape = new BvhTriangleMeshShape(triangleIndexVertexArray, true),
                    CollisionFlags = CollisionFlags.StaticObject
                };

                World.AddCollisionObject(collisionObject, CollisionFilterGroups.StaticFilter, CollisionFilterGroups.AllFilter);
            }
        }

        public void OnMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
    }
}