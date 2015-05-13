using System;
using System.Linq;
using BulletSharp;
using Moonfish.Graphics.Input;
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

        /// <summary>
        /// Kludge
        /// </summary>
        public void Update()
        {
            foreach (var collisionObject in World.CollisionObjectArray)
            {
                var scenarioObject = collisionObject as ScenarioCollisionObject;
                if (scenarioObject != null)
                {
                    var matrix = scenarioObject.ParentObject.CalculateChildWorldMatrix(scenarioObject.UserObject);
                    scenarioObject.WorldTransform = matrix;
                }
            }
            World.PerformDiscreteCollisionDetection();
        }

        public void LoadScenarioObjectCollision(ScenarioObject scenarioObject)
        {
            for (var index = 0; index < scenarioObject.Nodes.Count; index++)
            {
                var node = scenarioObject.Nodes[index];
                var collisionObject = new ScenarioCollisionObject
                {
                    CollisionShape = new BoxShape(0.015f),
                    WorldTransform = scenarioObject.Nodes.GetWorldMatrix(node),
                    UserObject = node,
                    ParentObject = scenarioObject
                };
                node.CollisionObject = collisionObject;
                World.AddCollisionObject(collisionObject);
            }
            foreach (var collisionObject in scenarioObject.Markers.Select(marker => new ScenarioCollisionObject
            {
                CollisionShape = new BoxShape(0.015f),
                WorldTransform = Matrix4.CreateFromQuaternion(marker.Rotation)*
                                 Matrix4.CreateTranslation(marker.Translation)*
                                 scenarioObject.Nodes.GetWorldMatrix(marker.NodeIndex),
                UserObject = marker,
                ParentObject = scenarioObject
            }))
            {
                World.AddCollisionObject(collisionObject);
            }
        }

        internal void LoadScenarioCollision(ScenarioStructureBspBlock structureBSP)
        {
            foreach (var cluster in structureBSP.Clusters)
            {
                var vertices =
                    new Vector3[cluster.ClusterData[0].Section.VertexBuffers[0].VertexBuffer.Data.Length/12];
                for (var i = 0; i < vertices.Length; ++i)
                {
                    var data = cluster.ClusterData[0].Section.VertexBuffers[0].VertexBuffer.Data;
                    vertices[i] = new Vector3(
                        BitConverter.ToSingle(data, i*12 + 0),
                        BitConverter.ToSingle(data, i*12 + 4),
                        BitConverter.ToSingle(data, i*12 + 8));
                }
                var triangleIndexVertexArray = new TriangleIndexVertexArray(
                    cluster.ClusterData[0].Section.StripIndices.Select(x => (int) x.Index).ToArray(), vertices);

                var collisionObject = new CollisionObject
                {
                    CollisionShape = new BvhTriangleMeshShape(triangleIndexVertexArray, true),
                    CollisionFlags = CollisionFlags.StaticObject
                };

                World.AddCollisionObject(collisionObject, CollisionFilterGroups.StaticFilter,
                    CollisionFilterGroups.AllFilter);
            }
        }
    }
}