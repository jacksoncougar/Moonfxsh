using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;

namespace Moonfish.Guerilla
{
    public abstract class GuerillaBlock
    {
        public abstract int SerializedSize { get; }

        public abstract int Alignment { get; }

        protected GuerillaBlock()
        {
        }

        protected GuerillaBlock(BinaryReader binaryReader)
        {
        }

        public static BlamPointer ReadBlockArrayPointer<T>(BinaryReader binaryReader)
            where T : GuerillaBlock, new()
        {
            var elementSize = new T().SerializedSize;
            return ReadBlockArrayPointer(binaryReader, elementSize);
        }

        public static BlamPointer ReadBlockArrayPointer(BinaryReader binaryReader, int elementSize)
        {
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            return blamPointer;
        }

        public static T[] ReadBlockArrayData<T>(BinaryReader binaryReader, BlamPointer blamPointer)
            where T : GuerillaBlock, new()
        {
            var array = new T[blamPointer.ElementCount];
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            var pointerArray = new Queue<BlamPointer>[blamPointer.ElementCount];
            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
                array[i] = new T();
                pointerArray[i] = array[i].ReadFields(binaryReader);
            }
            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
                array[i].ReadPointers(binaryReader, pointerArray[i]);
            }
            return array;
        }

        public static byte[] ReadDataByteArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            return binaryReader.ReadBytes(blamPointer.ElementCount);
        }

        public static short[] ReadDataShortArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            var elements = new short[blamPointer.ElementCount];
            var buffer = binaryReader.ReadBytes(blamPointer.ElementCount * 2);
            Buffer.BlockCopy(buffer, 0, elements, 0, buffer.Length);
            return elements;
        }

        public virtual Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            return new Queue<BlamPointer>();
        }

        public virtual void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
        }

        public virtual void Read(BinaryReader binaryReader)
        {
        }

        public virtual int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            return nextAddress;
        }
    }
}
