//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagClassAttribute("scen")]
    [TagBlockOriginalNameAttribute("scenery_block")]
    public partial class SceneryBlock : ObjectBlock, IWriteQueueable
    {
        public PathfindingPolicyEnum PathfindingPolicy;
        public SceneryFlags ScenerySceneryFlags;
        public LightmappingPolicyEnum LightmappingPolicy;
        private byte[] fieldpad3 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 196;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.PathfindingPolicy = ((PathfindingPolicyEnum)(binaryReader.ReadInt16()));
            this.ScenerySceneryFlags = ((SceneryFlags)(binaryReader.ReadInt16()));
            this.LightmappingPolicy = ((LightmappingPolicyEnum)(binaryReader.ReadInt16()));
            this.fieldpad3 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.PathfindingPolicy)));
            queueableBinaryWriter.Write(((short)(this.ScenerySceneryFlags)));
            queueableBinaryWriter.Write(((short)(this.LightmappingPolicy)));
            queueableBinaryWriter.Write(this.fieldpad3);
        }
        /// <summary>
        /// Indicate whether, by default, we should create pathfinding data for this type of scenery
        /// </summary>
        public enum PathfindingPolicyEnum : short
        {
            PathfindingCUTOUT = 0,
            PathfindingSTATIC = 1,
            PathfindingDYNAMIC = 2,
            PathfindingNONE = 3,
        }
        [System.FlagsAttribute()]
        public enum SceneryFlags : short
        {
            None = 0,
            PhysicallySimulatesstimulates = 1,
        }
        /// <summary>
        /// Indicate whether, by default, how we should lightmap this type of scenery
        /// </summary>
        public enum LightmappingPolicyEnum : short
        {
            PerVertex = 0,
            PerPixelnotImplemented = 1,
            Dynamic = 2,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Scen = ((TagClass)("scen"));
    }
}
