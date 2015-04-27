// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Jmad = ( TagClass ) "jmad";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "jmad" )]
    public partial class ModelAnimationGraphBlock : ModelAnimationGraphBlockBase
    {
        public ModelAnimationGraphBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 188, Alignment = 4 )]
    public class ModelAnimationGraphBlockBase : GuerillaBlock
    {
        internal AnimationGraphResourcesStructBlock resources;
        internal AnimationGraphContentsStructBlock content;
        internal ModelAnimationRuntimeDataStructBlock runTimeData;
        internal byte[] lastImportResults;
        internal AdditionalNodeDataBlock[] additionalNodeData;
        internal MoonfishXboxAnimationRawBlock[] xboxUnknownAnimationBlock;
        internal MoonfishXboxAnimationUnknownBlock[] xboxUnknownAnimationBlock0;

        public override int SerializedSize
        {
            get { return 188; }
        }

        internal ModelAnimationGraphBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            resources = new AnimationGraphResourcesStructBlock( binaryReader );
            content = new AnimationGraphContentsStructBlock( binaryReader );
            runTimeData = new ModelAnimationRuntimeDataStructBlock( binaryReader );
            lastImportResults = Guerilla.ReadData( binaryReader );
            additionalNodeData = Guerilla.ReadBlockArray<AdditionalNodeDataBlock>( binaryReader );
            xboxUnknownAnimationBlock = Guerilla.ReadBlockArray<MoonfishXboxAnimationRawBlock>( binaryReader );
            xboxUnknownAnimationBlock0 = Guerilla.ReadBlockArray<MoonfishXboxAnimationUnknownBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                resources.Write( binaryWriter );
                content.Write( binaryWriter );
                runTimeData.Write( binaryWriter );
                nextAddress = Guerilla.WriteData( binaryWriter, lastImportResults, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<AdditionalNodeDataBlock>( binaryWriter, additionalNodeData,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<MoonfishXboxAnimationRawBlock>( binaryWriter,
                    xboxUnknownAnimationBlock, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<MoonfishXboxAnimationUnknownBlock>( binaryWriter,
                    xboxUnknownAnimationBlock0, nextAddress );
                return nextAddress;
            }
        }
    };
}