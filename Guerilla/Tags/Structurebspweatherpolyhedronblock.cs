using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspWeatherPolyhedronBlock : StructureBspWeatherPolyhedronBlockBase
    {
        public  StructureBspWeatherPolyhedronBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class StructureBspWeatherPolyhedronBlockBase
    {
        internal OpenTK.Vector3 boundingSphereCenter;
        internal float boundingSphereRadius;
        internal StructureBspWeatherPolyhedronPlaneBlock[] planes;
        internal  StructureBspWeatherPolyhedronBlockBase(BinaryReader binaryReader)
        {
            this.boundingSphereCenter = binaryReader.ReadVector3();
            this.boundingSphereRadius = binaryReader.ReadSingle();
            this.planes = ReadStructureBspWeatherPolyhedronPlaneBlockArray(binaryReader);
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
        internal  virtual StructureBspWeatherPolyhedronPlaneBlock[] ReadStructureBspWeatherPolyhedronPlaneBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPolyhedronPlaneBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPolyhedronPlaneBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPolyhedronPlaneBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
