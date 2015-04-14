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
        public static readonly TagClass MpdtClass = (TagClass)"mpdt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mpdt")]
    public  partial class MaterialPhysicsBlock : MaterialPhysicsBlockBase
    {
        public  MaterialPhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class MaterialPhysicsBlockBase  : IGuerilla
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
        internal  MaterialPhysicsBlockBase(BinaryReader binaryReader)
        {
            groundFrictionScale = binaryReader.ReadSingle();
            groundFrictionNormalK1Scale = binaryReader.ReadSingle();
            groundFrictionNormalK0Scale = binaryReader.ReadSingle();
            groundDepthScale = binaryReader.ReadSingle();
            groundDampFractionScale = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(groundFrictionScale);
                binaryWriter.Write(groundFrictionNormalK1Scale);
                binaryWriter.Write(groundFrictionNormalK0Scale);
                binaryWriter.Write(groundDepthScale);
                binaryWriter.Write(groundDampFractionScale);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
