using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mpdt")]
    public  partial class MaterialPhysicsBlock : MaterialPhysicsBlockBase
    {
        public  MaterialPhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class MaterialPhysicsBlockBase
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
            this.groundFrictionScale = binaryReader.ReadSingle();
            this.groundFrictionNormalK1Scale = binaryReader.ReadSingle();
            this.groundFrictionNormalK0Scale = binaryReader.ReadSingle();
            this.groundDepthScale = binaryReader.ReadSingle();
            this.groundDampFractionScale = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
