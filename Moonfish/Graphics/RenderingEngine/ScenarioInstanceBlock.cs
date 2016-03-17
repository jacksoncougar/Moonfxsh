using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     A defuault instance wrapper
    /// </summary>
    public class ScenarioInstanceBlock : GuerillaBlock
    {
        private byte[] indexer = new byte[4];
        public ScenarioObjectDatumStructBlock ObjectData = new ScenarioObjectDatumStructBlock( );
        public ScenarioObjectPermutationStructBlock PermutationData = new ScenarioObjectPermutationStructBlock( );
        public ScenarioSceneryDatumStructV4Block SceneryData = new ScenarioSceneryDatumStructV4Block( );
        public override int Alignment { get; }
        public override int SerializedSize { get; }

        public override bool Equals( object obj )
        {
            var otherInstance = obj as ScenarioInstanceBlock;
            if ( otherInstance != null )
            {
                //TODO make this better
                return otherInstance.ObjectData.ObjectID.UniqueID == ObjectData.ObjectID.UniqueID;
            }
            return base.Equals( obj );
        }

        public override int GetHashCode( )
        {
            return ObjectData.ObjectID.UniqueID;
        }
    }
}