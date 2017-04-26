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

        public int this[int index]
        {
            get { return StartAddress + ElementSize*index; }
        }

        public BlamPointer(int count, int address, int elementsize, int alignment = Moonfish.Alignment.Default)
        {
            Alignment = alignment;
            ElementCount = count;
            StartAddress = Padding.Align(address, alignment);
            ElementSize = elementsize;
        }

        private BlamPointer(int count, int elementsize, int startAddress, int endAddress, int alignment)
        {
            Alignment = alignment;
            ElementCount = count;
            ElementSize = elementsize;
            StartAddress = startAddress;
        }

        public int PointedSize => ElementCount*ElementSize;

        public int EndAddress => StartAddress + ElementSize*ElementCount;

        public static BlamPointer Null { get { return new BlamPointer(0, 0, 0, 0, Moonfish.Alignment.Default); } }

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
            return $"{StartAddress}:{ElementCount}";
        }

        public static bool operator ==(BlamPointer left, BlamPointer right)
        {
            return left.StartAddress == right.StartAddress && left.ElementCount == right.ElementCount &&
                   left.EndAddress == right.EndAddress;
        }

        public static bool operator !=(BlamPointer left, BlamPointer right)
        {
            return !(left == right);
        }
    }
}