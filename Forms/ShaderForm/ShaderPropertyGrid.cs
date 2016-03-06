using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms.ShaderForm
{
    public partial class ShaderPropertyGrid : DockContent
    {
        public ShaderPropertyGrid( )
        {
            InitializeComponent( );
        }

        public void DisplayVertexConstants( TagDatum vertexTag, CacheStream cache )
        {
            var items = GetVertexConstants( vertexTag, cache );
            items.Sort((u,v)=>u.bytes[0].CompareTo( v.bytes[0] ));
            var source = new BindingSource {DataSource = items};
            dataGridView1.DataSource = source;
        }

        private List<VertexConstantInfo> GetVertexConstants( TagDatum vertexTag, CacheStream cache )
        {
            if ( !cache.Index.Contains( vertexTag ) ) return new List<VertexConstantInfo>( );

            var vertexConstantInfos = new List<VertexConstantInfo>( );

            foreach ( var tagDatum in cache.Index.Where( TagClass.Spas ) )
            {
                var block = ( ShaderPassBlock ) cache.Deserialize( tagDatum.Identifier );
                var usesVertex =
                    block.PostprocessDefinition[ 0 ].Implementations.Any(
                        u => u.VertexShader.Ident == vertexTag.Identifier );
                if ( !usesVertex ) continue;
                foreach ( var templateDatum in cache.Index.Where( TagClass.Stem ) )
                {
                    var templateBlock = ( ShaderTemplateBlock ) cache.Deserialize( templateDatum.Identifier );
                    var usesPass =
                        templateBlock.PostprocessDefinition[ 0 ].Passes.Any(
                            v => v.Pass.Ident == tagDatum.Identifier );
                    if ( !usesPass ) continue;
                    foreach ( var shaderDatum in cache.Index.Where( TagClass.Shad ) )
                    {
                        var shaderBlock = ( ShaderBlock ) cache.Deserialize( shaderDatum.Identifier );
                        var usesTemplate = shaderBlock.Template.Ident == templateDatum.Identifier;
                        if ( usesTemplate )
                        {
                            var items = GetVertexConstants( shaderBlock, templateBlock, block, vertexTag, tagDatum,
                                templateDatum,
                                shaderDatum, cache );
                            vertexConstantInfos.AddRange( items );
                        }
                    }
                }
            }
            return vertexConstantInfos;
        }

        private List<VertexConstantInfo> GetVertexConstants( ShaderBlock shaderBlock,
            ShaderTemplateBlock shaderTemplateBlock,
            ShaderPassBlock shaderPassBlock, TagDatum vrtxDatum, TagDatum spasDatum, TagDatum stemDatum,
            TagDatum shaderDatum, CacheStream cache )
        {
            var vertexConstantInfos = new List<VertexConstantInfo>( );
            var passes =
                shaderTemplateBlock.PostprocessDefinition[ 0 ].Passes.Where( u => u.Pass.Ident == spasDatum.Identifier );
            foreach ( var pass in passes )
            {
                for ( int i = pass.Implementations.Index; i < pass.Implementations.Index + pass.Implementations.Length; i++ )
                {
                    var index =
                        shaderTemplateBlock.PostprocessDefinition[ 0 ].Implementations[ i ].VertexConstants.Index;
                    var length =
                        shaderTemplateBlock.PostprocessDefinition[ 0 ].Implementations[ i ].VertexConstants.Length;
                    for ( int j = index; j < index + length; j++ )
                    {
                        var sourceIndex = shaderTemplateBlock.PostprocessDefinition[ 0 ].Remappings[ j ].SourceIndex;
                        var bytes = shaderTemplateBlock.PostprocessDefinition[ 0 ].Remappings[ j ].fieldskip;

                        var vertexConstant = shaderBlock.PostprocessDefinition[ 0 ].VertexConstants[ sourceIndex ];

                        var info = new VertexConstantInfo
                        {
                            source = sourceIndex,
                            bytes = bytes,
                            value = new Vector4( vertexConstant.Vector3, vertexConstant.W ),
                            stringId = Halo2.Strings[new StringIdent(BitConverter.ToInt16( bytes, 0 ), 0)]
                        };
                        vertexConstantInfos.Add( info );
                    }
                }
            }
            return vertexConstantInfos;
        }

        private struct VertexConstantInfo
        {
            public string stringId { get; set; }
            public int Source => source;
            public Vector4 Value => value;
            public string MSB0 => BitConverter.ToString(bytes,0,2);
            public byte MSB1 => bytes[1];
            public byte LSB0 => bytes[2];
            public Vector4 value;
            public byte[] bytes;
            public int source;
        }
    }
}