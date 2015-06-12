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
                var count = cluster.ClusterData[0].Section.VertexBuffers[0].VertexBuffer.Data.Length / 12;
                var coordinates = new Vector3[count];
                var normals = new Vector3[count];
                var tangents = new Vector3[count];
                var bitangents = new Vector3[count];

                for (var i = 0; i < count; ++i)
                {
                    var data = cluster.ClusterData[0].Section.VertexBuffers[0].VertexBuffer.Data;
                    coordinates[i] = new Vector3(
                        BitConverter.ToSingle(data, i*12 + 0),
                        BitConverter.ToSingle(data, i*12 + 4),
                        BitConverter.ToSingle(data, i*12 + 8));
                }
                var globalGeometrySectionVertexBufferBlock = cluster.ClusterData[0].Section.VertexBuffers.Single(x => x.VertexBuffer.Type == VertexAttributeType.TangentSpaceUnitVectorsCompressed);
                var vectorData = globalGeometrySectionVertexBufferBlock.VertexBuffer.Data;
                int stride = globalGeometrySectionVertexBufferBlock.VertexBuffer.Type.GetSize( );

                vectorData = Mesh.UnpackNormals( vectorData, VertexAttributeType.TangentSpaceUnitVectorsCompressed, ref stride );
                for (var i = 0; i < count; ++i)
                {
                    normals[i] = new Vector3(
                        BitConverter.ToSingle(vectorData, i * stride + 0),
                        BitConverter.ToSingle(vectorData, i * stride + 4),
                        BitConverter.ToSingle(vectorData, i * stride + 8));
                    tangents[i] = new Vector3(
                        BitConverter.ToSingle(vectorData, i * stride + 12),
                        BitConverter.ToSingle(vectorData, i * stride + 16),
                        BitConverter.ToSingle(vectorData, i * stride + 20));
                    bitangents[i] = new Vector3(
                        BitConverter.ToSingle(vectorData, i * stride + 24),
                        BitConverter.ToSingle(vectorData, i * stride + 28),
                        BitConverter.ToSingle(vectorData, i * stride + 32));
                }

                var indices = cluster.ClusterData[ 0 ].Section.StripIndices.Select( x =>  (int)x.Index ).ToArray( );
                
                var collisionObject = new CollisionObject
                {
                    CollisionShape = new BvhTriangleMeshShape(new InfoTriangleIndexVertexArray(coordinates, normals, tangents, bitangents, indices), true, true),
                    CollisionFlags = CollisionFlags.StaticObject,
                };

                World.AddCollisionObject(collisionObject, (short)CollisionGroup.Level, (short)(CollisionGroup.Objects));
            }
        }
    }

    public class InfoTriangleIndexVertexArray : TriangleIndexVertexArray
    {
        public Vector3[] Normals { get; set; }
        public Vector3[] Tangents { get; set; }
        public Vector3[] Bitangents { get; set; }
        public Vector3[] Coordinates { get; set; }
        public int[] Indices { get; set; }

        public InfoTriangleIndexVertexArray( Vector3[] coordinates, Vector3[] normals, Vector3[] tangents,
            Vector3[] bitangents, int[] indices )
        :base(indices, coordinates)
        {
            Normals = normals;
            Tangents = tangents;
            Bitangents = bitangents;
            Coordinates = coordinates;
            Indices = indices;
        }
    }
}