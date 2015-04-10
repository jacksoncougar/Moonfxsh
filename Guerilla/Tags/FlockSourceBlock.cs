using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class FlockSourceBlock : FlockSourceBlockBase
    {
        public  FlockSourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class FlockSourceBlockBase
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector2 startingYawPitchDegrees;
        internal float radius;
        /// <summary>
        /// probability of producing at this source
        /// </summary>
        internal float weight;
        internal  FlockSourceBlockBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.startingYawPitchDegrees = binaryReader.ReadVector2();
            this.radius = binaryReader.ReadSingle();
            this.weight = binaryReader.ReadSingle();
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
