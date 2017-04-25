using System;
using System.Collections.Generic;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     A defuault instance wrapper
    /// </summary>
    public class ScenarioInstanceBlock : GuerillaBlock, IH2ObjectInstance
    {
        private byte[] indexer = new byte[4];
        public readonly ScenarioObjectDatumStructBlock ObjectData = new ScenarioObjectDatumStructBlock( );
        public ScenarioObjectPermutationStructBlock PermutationData = new ScenarioObjectPermutationStructBlock( );
        public ScenarioSceneryDatumStructV4Block SceneryData = new ScenarioSceneryDatumStructV4Block( );
        public override int Alignment { get; }
        public override int SerializedSize { get; }

        bool IEquatable<IH2ObjectInstance>.Equals( IH2ObjectInstance other )
        {
            var instance = other as ScenarioInstanceBlock;
            if ( instance == null ) return false;
            var objectInstance = ( IH2ObjectInstance ) this;
            return other.ObjectDatum.ObjectID.UniqueID == objectInstance.ObjectDatum.ObjectID.UniqueID;
        }

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

        ShortBlockIndex1 IH2ObjectInstance.NameIndex
        {
            get { return (ShortBlockIndex1) (-1); }
        }

        ShortBlockIndex1 IH2ObjectInstance.PaletteIndex
        {
            get { return (ShortBlockIndex1) (-1); }
        }

        ScenarioObjectDatumStructBlock IH2ObjectInstance.ObjectDatum
        {
            get { return ObjectData; }
        }

        Matrix4 IH2ObjectInstance.WorldMatrix
        {
            get { return ObjectData.CreateWorldMatrix( ); }
        }

        bool IEqualityComparer<IH2ObjectInstance>.Equals(IH2ObjectInstance x, IH2ObjectInstance y)
        {
            return x.Equals(y);
        }

        int IEqualityComparer<IH2ObjectInstance>.GetHashCode(IH2ObjectInstance obj)
        {
            return obj.ObjectDatum.ObjectID.UniqueID;
        }
    }
}