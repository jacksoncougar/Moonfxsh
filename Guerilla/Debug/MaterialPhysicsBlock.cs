// ReSharper disable All
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
        public  MaterialPhysicsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  MaterialPhysicsBlockBase(System.IO.BinaryReader binaryReader)
        {
            groundFrictionScale = binaryReader.ReadSingle();
            groundFrictionNormalK1Scale = binaryReader.ReadSingle();
            groundFrictionNormalK0Scale = binaryReader.ReadSingle();
            groundDepthScale = binaryReader.ReadSingle();
            groundDampFractionScale = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(groundFrictionScale);
                binaryWriter.Write(groundFrictionNormalK1Scale);
                binaryWriter.Write(groundFrictionNormalK0Scale);
                binaryWriter.Write(groundDepthScale);
                binaryWriter.Write(groundDampFractionScale);
            }
        }
    };
}
