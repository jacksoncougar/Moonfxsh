using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Guerilla.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public class CollisionManager
    {
        public CollisionWorld World { get; private set; }

        public CollisionManager( Program debug )
        {
            var defaultCollisionConfiguration = new DefaultCollisionConfiguration( );
            var collisionDispatcher = new CollisionDispatcher( defaultCollisionConfiguration );
            var broadphase = new DbvtBroadphase( );
            this.World = new CollisionWorld( collisionDispatcher, broadphase, defaultCollisionConfiguration );
            if ( debug != null )
                this.World.DebugDrawer = new BulletDebugDrawer( debug );
        }

        /// <summary>
        /// Kludge
        /// </summary>
        public void Update( )
        {
            World.PerformDiscreteCollisionDetection( );
        }

        public void LoadScenarioObjectCollision( ScenarioObject scenarioObject )
        {
            for ( var index = 0; index < scenarioObject.Nodes.Count; index++ )
            {
                var node = scenarioObject.Nodes[ index ];
                var collisionObject = new ScenarioCollisionObject
                {
                    CollisionShape = new BoxShape( 0.015f ),
                    WorldTransform = scenarioObject.Nodes.GetWorldMatrix( node ),
                    UserObject = node,
                    ParentObject = scenarioObject
                };
                node.CollisionObject = collisionObject;
                World.AddCollisionObject( collisionObject );
            }
            foreach ( var collisionObject in scenarioObject.Markers.Select( marker => new ScenarioCollisionObject
            {
                CollisionShape = new BoxShape( 0.015f ),
                WorldTransform = Matrix4.CreateFromQuaternion( marker.Rotation ) *
                                 Matrix4.CreateTranslation( marker.Translation ) *
                                 scenarioObject.Nodes.GetWorldMatrix( marker.NodeIndex ),
                UserObject = marker,
                ParentObject = scenarioObject
            } ) )
            {
                World.AddCollisionObject(collisionObject, (short)CollisionGroup.Objects, (short)(CollisionGroup.Objects | CollisionGroup.Level));
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

                var indices = cluster.ClusterData[ 0 ].Section.StripIndices.Select( x =>  (int)x.Index ).ToArray( );
                
                var collisionObject = new CollisionObject
                {
                    CollisionShape = new BvhTriangleMeshShape(new TriangleIndexVertexArray(indices, vertices), true, true),
                    CollisionFlags = CollisionFlags.StaticObject,
                };

                World.AddCollisionObject(collisionObject, (short)CollisionGroup.Level, (short)(CollisionGroup.Objects));
            }
        }
    }
}