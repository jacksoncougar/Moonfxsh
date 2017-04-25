using System;
using System.Collections.Generic;

namespace Moonfish.Tags
{
    public struct BlamPointer : IEnumerable<int>, IEquatable<BlamPointer>
    {
        public int Alignment { get; set; }
        public readonly int ElementCount;
        public readonly int StartAddress;
        public readonly int ElementSize;

        private readonly int endAddress;

        public int this[int index]
        {
            get { return StartAddress + ElementSize*index; }
        }

        public BlamPointer(int count, int address, int elementsize, int alignment = 4)
        {
            Alignment = alignment;
            ElementCount = count;
            StartAddress = Padding.Align(address, alignment);
            ElementSize = elementsize;
            endAddress = StartAddress + ElementSize*ElementCount;
        }

        private BlamPointer(int count, int elementsize, int startAddress, int endAddress, int alignment)
        {
            Alignment = alignment;
            ElementCount = count;
            ElementSize = elementsize;
            StartAddress = startAddress;
            this.endAddress = endAddress;
        }

        public BlamPointer Shift(int offset)
        {
            return new BlamPointer(ElementCount, ElementSize, StartAddress + offset, endAddress + offset, Alignment);
        }

        public int PointedSize
        {
            get { return ElementCount*ElementSize; }
        }

        public int EndAddress
        {
            get { return endAddress; }
        }

        public static BlamPointer Null { get { return new BlamPointer(0, 0, 0, 0, 4); } }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < ElementCount; ++i)
            {
                yield return StartAddress + ElementSize*i;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Intersects(BlamPointer other)
        {
            return !(StartAddress + PointedSize <= other.StartAddress
                     || other.StartAddress + other.PointedSize <= StartAddress);
        }

        public override bool Equals(object obj)
        {
            if (obj is BlamPointer)
            {
                return (this as IEquatable<BlamPointer>).Equals((BlamPointer) obj);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return StartAddress.GetHashCode();
        }

        bool IEquatable<BlamPointer>.Equals(BlamPointer other)
        {
            return StartAddress == other.StartAddress && ElementCount == other.ElementCount &&
                   ElementSize == other.ElementSize;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", StartAddress, ElementCount);
        }

        internal static bool IsNull(BlamPointer pointer)
        {
            return pointer.ElementCount == 0 && pointer.StartAddress == 0;
        }
    }
}