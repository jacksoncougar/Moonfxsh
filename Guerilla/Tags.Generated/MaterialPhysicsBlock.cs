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
        public static readonly TagClass Mpdt = (TagClass)"mpdt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mpdt")]
    public partial class MaterialPhysicsBlock : MaterialPhysicsBlockBase
    {
        public  MaterialPhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MaterialPhysicsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class MaterialPhysicsBlockBase : GuerillaBlock
    {
        /// <summary>
        /// fraction of original velocity parallel to the ground after one tick
        /// </summary>
        internal float groundFrictionScale;
        /// <summary>
        /// cosine of angle at which friction falls off
        /// </summary>
        internal float groundFrictionNormalK1Scale;
        /// <summary>
        /// cosine of angle at which friction is zero
        /// </summary>
        internal float groundFrictionNormalK0Scale;
        /// <summary>
        /// depth a point mass rests in the ground
        /// </summary>
        internal float groundDepthScale;
        /// <summary>
        /// fraction of original velocity perpendicular to the ground after one tick
        /// </summary>
        internal float groundDampFractionScale;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MaterialPhysicsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            groundFrictionScale = binaryReader.ReadSingle();
            groundFrictionNormalK1Scale = binaryReader.ReadSingle();
            groundFrictionNormalK0Scale = binaryReader.ReadSingle();
            groundDepthScale = binaryReader.ReadSingle();
            groundDampFractionScale = binaryReader.ReadSingle();
        }
        public  MaterialPhysicsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            groundFrictionScale = binaryReader.ReadSingle();
            groundFrictionNormalK1Scale = binaryReader.ReadSingle();
            groundFrictionNormalK0Scale = binaryReader.ReadSingle();
            groundDepthScale = binaryReader.ReadSingle();
            groundDampFractionScale = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(groundFrictionScale);
                binaryWriter.Write(groundFrictionNormalK1Scale);
                binaryWriter.Write(groundFrictionNormalK0Scale);
                binaryWriter.Write(groundDepthScale);
                binaryWriter.Write(groundDampFractionScale);
                return nextAddress;
            }
        }
    };
}
