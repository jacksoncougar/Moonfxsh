using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Guerilla;
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
             var collisionDispatcher =  new CollisionDispatcher(defaultCollisionConfiguration);
            var broadphase = new AxisSweep3(new Vector3(-100,-100,-100), new Vector3(100,100,100));
            World = new CollisionWorld( collisionDispatcher, broadphase, defaultCollisionConfiguration );

            if ( debug != null )
                this.World.DebugDrawer = new BulletDebugDrawer( debug );
        }

        /// <summary>
        /// Kludge
        /// </summary>
        public void Update( )
        {
            World.UpdateAabbs(  );
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
        

        internal void LoadScenarioCollision( ScenarioStructureBspBlock structureBSP )
        {
            {
                var meshArray = new InfoTriangleIndexVertexArray( );
                foreach ( var cluster in structureBSP.Clusters )
                {
                    var globalGeometrySectionStructBlock = cluster.ClusterData[ 0 ].Section;
                    if ( !IsCollisionMesh( globalGeometrySectionStructBlock ) ) continue;

                    var indexedMesh = GenerateBvhCollisionObjectFromMesh( globalGeometrySectionStructBlock , Matrix4.Identity);
                    meshArray.AddIndexedMesh( indexedMesh );
                    meshArray.AddIndexedMeshSurfaceData( globalGeometrySectionStructBlock );
                }

                Vector3 aabbMax;
                Vector3 aabbMin;
                meshArray.CalculateAabbBruteForce( out aabbMin, out aabbMax );
                var bvhTriangleMeshShape = new BvhTriangleMeshShape( meshArray, true, aabbMin, aabbMax, true );
                bvhTriangleMeshShape.BuildOptimizedBvh( );

                var collisionObject = new CollisionObject
                {
                    CollisionShape = bvhTriangleMeshShape
                };
                World.AddCollisionObject( collisionObject, CollisionFilterGroups.StaticFilter,
                    CollisionFilterGroups.DefaultFilter );
            }

            foreach (var structureBspInstancedGeometryInstancesBlock in structureBSP.InstancedGeometryInstances)
            {
                var instanceMeshArray = new InfoTriangleIndexVertexArray();
                var structureBspInstancedGeometryDefinitionBlock = structureBSP.InstancedGeometriesDefinitions[structureBspInstancedGeometryInstancesBlock.InstanceDefinition];
                if (structureBspInstancedGeometryDefinitionBlock.RenderInfo.RenderData.Length < 1) continue;

                var globalGeometrySectionStructBlock = structureBspInstancedGeometryDefinitionBlock.RenderInfo.RenderData[0].Section;
                if (!IsCollisionMesh(globalGeometrySectionStructBlock)) continue;

                var indexedMesh = GenerateBvhCollisionObjectFromMesh(globalGeometrySectionStructBlock, structureBspInstancedGeometryInstancesBlock.WorldMatrix);
                instanceMeshArray.AddIndexedMesh(indexedMesh);
                instanceMeshArray.AddIndexedMeshSurfaceData(globalGeometrySectionStructBlock);

                Vector3 aabbMin;
                Vector3 aabbMax;
                instanceMeshArray.CalculateAabbBruteForce(out aabbMin, out aabbMax);
                var bvhTriangleMeshShape = new BvhTriangleMeshShape( instanceMeshArray, true, aabbMin, aabbMax, true );
                bvhTriangleMeshShape.BuildOptimizedBvh();

                var collisionObject = new CollisionObject
                {
                    CollisionShape = bvhTriangleMeshShape,
                    UserObject = "Instance"
                };
                World.AddCollisionObject(collisionObject, CollisionFilterGroups.StaticFilter, CollisionFilterGroups.DefaultFilter);
            }
            World.UpdateAabbs();

        }

        private static bool IsCollisionMesh( GlobalGeometrySectionStructBlock globalGeometrySectionStructBlock )
        {
           return globalGeometrySectionStructBlock.Parts.Count(
                e => e.GlobalGeometryPartNewFlags.HasFlag( GlobalGeometryPartBlockNew.Flags.Decalable ) ) > 0;
        }


        private DefaultIndexedMesh GenerateBvhCollisionObjectFromMesh(GlobalGeometrySectionStructBlock globalGeometrySectionStructBlock, Matrix4 instanceWorldMatrix)
        {
            return new DefaultIndexedMesh( globalGeometrySectionStructBlock, instanceWorldMatrix );
        }

        public void Move( CollisionObject item, Matrix4 transform )
        {
            var worldTransform = item.WorldTransform;
            var from = worldTransform.ExtractTranslation( );
            var to = transform.ExtractTranslation( );

            var closestConvexResultCallback = new ClosestNotMeConvexResultCallback( item, from, to )
            {
                CollisionFilterGroup = ( CollisionFilterGroups ) ( CollisionGroup.Objects | CollisionGroup.Level )
            };
            World.ConvexSweepTest( ( ConvexShape ) item.CollisionShape, worldTransform, transform, closestConvexResultCallback );
            if ( closestConvexResultCallback.HasHit )
            {
                Vector3 linVel;
                Vector3 angVel;
                TransformUtil.CalculateVelocity( worldTransform, transform, 1.0f, out linVel, out angVel );
                Matrix4 T;
                TransformUtil.IntegrateTransform( worldTransform, linVel, angVel,
                    closestConvexResultCallback.ClosestHitFraction, out T );
                item.WorldTransform = T;
            }
            else item.WorldTransform = transform;
        }
    }

    public class DefaultIndexedMesh : IndexedMesh
    {
        public DefaultIndexedMesh( GlobalGeometrySectionStructBlock geometrySectionStructBlock) : this( geometrySectionStructBlock, Matrix4.Identity )
        {
        }

        public DefaultIndexedMesh( GlobalGeometrySectionStructBlock geometrySectionStructBlock, 
            Matrix4 instanceWorldMatrix)
        {
            var collisionParts = geometrySectionStructBlock.Parts.Where(
                e => e.GlobalGeometryPartNewFlags.HasFlag( GlobalGeometryPartBlockNew.Flags.Decalable ) ).ToArray( );

            if ( collisionParts.Length<=0 )
            {
                return;
            }

           
            int indicesLength = 0;
            foreach ( var globalGeometryPartBlockNew in collisionParts )
            {
                indicesLength += globalGeometryPartBlockNew.StripLength;
            }

            var coordinates =
                geometrySectionStructBlock.VertexBuffers.Single(
                    e => e.VertexBuffer.Type == VertexAttributeType.CoordinateFloat ).VertexBuffer.Data;
            var coordinateDataStride = VertexAttributeType.CoordinateFloat.GetSize( );
            var vertexCount = coordinates.Length / coordinateDataStride;


            Allocate(vertexCount, coordinateDataStride, indicesLength / 3, 4 * 3 );
            
            using ( BinaryWriter binaryWriter = new BinaryWriter( LockIndices( ) ) )
            {
                foreach ( var globalGeometryPartBlockNew in collisionParts )
                {
                    int baseIndex = globalGeometryPartBlockNew.StripStartIndex;
                    for ( int i = 0; i < globalGeometryPartBlockNew.StripLength; ++i )
                    {
                        binaryWriter.Write((int)geometrySectionStructBlock.StripIndices[baseIndex + i].Index);
                    }
                }
            }

            using (var binaryReader = new BinaryReader(new MemoryStream(coordinates)))
            using (var binaryWriter = new BinaryWriter(LockVerts()))
            {
                for ( var i = 0; i < vertexCount; ++i )
                {
                    var value = binaryReader.ReadVector3( );
                    Vector3.Transform( ref value, ref instanceWorldMatrix, out value );
                    binaryWriter.Write( value );
                }
            }
        }
    }

    public class PartSurfaceInfo
    {
        public Vector3[] Normals { get; set; }
        public Vector3[] Tangents { get; set; }
        public Vector3[] Bitangents { get; set; }

        public PartSurfaceInfo( GlobalGeometrySectionStructBlock geometrySectionStructBlock )
        {

            var lightingData = geometrySectionStructBlock.VertexBuffers.Single(
                e => e.VertexBuffer.Type == VertexAttributeType.UnpackedLightingData ).VertexBuffer.Data;
            var lightingDataStride = VertexAttributeType.UnpackedLightingData.GetSize( );
            var count = lightingData.Length / lightingDataStride;

            Normals = new Vector3[count];
            Bitangents = new Vector3[count];
            Tangents = new Vector3[count];
            for ( var i = 0; i < count; ++i )
            {
                Normals[ i ] = new Vector3(
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 0 ),
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 4 ),
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 8 ) );
                Tangents[ i ] = new Vector3(
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 12 ),
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 16 ),
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 20 ) );
                Bitangents[ i ] = new Vector3(
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 24 ),
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 28 ),
                    BitConverter.ToSingle( lightingData, i * lightingDataStride + 32 ) );
            }
        }
    }

    public class InfoTriangleIndexVertexArray : TriangleIndexVertexArray
    {
        public List<PartSurfaceInfo> SurfaceInfo { get; set; }= new List<PartSurfaceInfo>();

        public void AddIndexedMeshSurfaceData( GlobalGeometrySectionStructBlock globalGeometrySectionStructBlock )
        {
            SurfaceInfo.Add( new PartSurfaceInfo( globalGeometrySectionStructBlock ) );
        }
    }
}