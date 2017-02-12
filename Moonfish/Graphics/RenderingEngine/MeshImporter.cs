using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Graphics.RenderingEngine
{
    public class GeometryMesh
    {
        public List<GeometryPart> Parts { get; set;  } = new List<GeometryPart>();

        public RenderModelBlock Export( )
        {
            return new RenderModelBlock
            {
                Sections = new[]
                {
                    new RenderModelSectionBlock
                    {
                        SectionData = new[]
                        {
                            new RenderModelSectionDataBlock
                            {
                                Section = new GlobalGeometrySectionStructBlock
                                {
                                    Parts = ExportParts( ).ToArray( ),
                                    StripIndices = ExportElements( ),
                                    VertexBuffers = ExportVertexBuffers(),
                                }
                            }
                        }
                    }
                }
            };
        }

        private GlobalGeometrySectionVertexBufferBlock[] ExportVertexBuffers( )
        {
            var vertexCount = Parts.Sum( u => u.WorldCoordinates.Count );
            var worldCoordinateData = new byte[vertexCount * Vector3.SizeInBytes];
            var textureCoordinateData = new byte[vertexCount * Vector2.SizeInBytes];
            var vectorData = new byte[vertexCount * Vector3.SizeInBytes * 3];
            using (var worldDataWriter = new BinaryWriter(new MemoryStream(worldCoordinateData)))
            using (var textureDataWriter = new BinaryWriter(new MemoryStream(textureCoordinateData)))
            using (var vectorDataWriter = new BinaryWriter(new MemoryStream(vectorData)))
                foreach ( var geometryPart in Parts )
                {
                    foreach ( var worldCoordinate in geometryPart.WorldCoordinates )
                        worldDataWriter.Write( worldCoordinate );
                    foreach ( var textureCoordinate in geometryPart.TextureCoordinates )
                        textureDataWriter.Write( textureCoordinate.Xy );
                    foreach ( var normalVector in geometryPart.NormalVectors )
                    {
                        // Write Tangent vector
                        vectorDataWriter.Write( new Vector3( ) );
                        // Write Bitangent vector
                        vectorDataWriter.Write( new Vector3( ) );
                        // Write Normal vector
                        vectorDataWriter.Write( normalVector );
                    }
                }
            return new[]
            {
                // World Coordinates
                new GlobalGeometrySectionVertexBufferBlock
                {
                    VertexBuffer = new VertexBuffer
                    {
                        Type = VertexAttributeType.CoordinateFloat,
                        Data = worldCoordinateData
                    }
                },
                // Texture Coordinates
                new GlobalGeometrySectionVertexBufferBlock
                {
                    VertexBuffer = new VertexBuffer
                    {
                        Type = VertexAttributeType.TextureCoordinateFloat,
                        Data = textureCoordinateData
                    }
                },
                // Vector Data
                new GlobalGeometrySectionVertexBufferBlock
                {
                    VertexBuffer = new VertexBuffer
                    {
                        Type = VertexAttributeType.UnpackedLightingData,
                        Data = vectorData
                    }
                }
            };
        }

        private GlobalGeometrySectionStripIndexBlock[] ExportElements( )
        {
            var baseOffset = 0;
            var elements = new List<GlobalGeometrySectionStripIndexBlock>();
            foreach (var geometryPart in Parts)
            {
                elements.AddRange(
                    geometryPart.Elements.Select(
                        u => new GlobalGeometrySectionStripIndexBlock
                        {
                            Index = ( short ) ( baseOffset + u )
                        } ) );
                baseOffset += geometryPart.Elements.Count + 1;
            }
            return elements.ToArray( );
        }

        private IEnumerable<GlobalGeometryPartBlockNew> ExportParts()
        {
            var baseOffset = 0;
            foreach ( var geometryPart in Parts )
            {
                yield return new GlobalGeometryPartBlockNew
                {
                    Type =  geometryPart.Type,
                    GlobalGeometryPartNewFlags = geometryPart.Flags,
                    StripLength = ( short ) geometryPart.Elements.Count,
                    StripStartIndex = ( short ) baseOffset
                };
                baseOffset += geometryPart.Elements.Count + 1;
            }
        }
    }

    public class GeometryPart
    {
        public GlobalGeometryPartBlockNew.TypeEnum Type { get; set; }
        public GlobalGeometryPartBlockNew.Flags Flags { get; set; }

        public List<Vector3> WorldCoordinates { get; set; } = new List<Vector3>( );
        public List<Vector3> NormalVectors { get; set; } = new List<Vector3>( );
        public List<Vector3> TextureCoordinates { get; set; } = new List<Vector3>( );
        public List<short> Elements { get; set; } = new List<short>( );
    };
}
