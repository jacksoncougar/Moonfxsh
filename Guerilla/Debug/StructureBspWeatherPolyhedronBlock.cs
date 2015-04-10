// ReSharper disable All
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
        public  StructureBspWeatherPolyhedronBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class StructureBspWeatherPolyhedronBlockBase
    {
        internal OpenTK.Vector3 boundingSphereCenter;
        internal float boundingSphereRadius;
        internal StructureBspWeatherPolyhedronPlaneBlock[] planes;
        internal  StructureBspWeatherPolyhedronBlockBase(System.IO.BinaryReader binaryReader)
        {
            boundingSphereCenter = binaryReader.ReadVector3();
            boundingSphereRadius = binaryReader.ReadSingle();
            ReadStructureBspWeatherPolyhedronPlaneBlockArray(binaryReader);
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
        internal  virtual StructureBspWeatherPolyhedronPlaneBlock[] ReadStructureBspWeatherPolyhedronPlaneBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspWeatherPolyhedronPlaneBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(boundingSphereCenter);
                binaryWriter.Write(boundingSphereRadius);
                WriteStructureBspWeatherPolyhedronPlaneBlockArray(binaryWriter);
            }
        }
    };
}
