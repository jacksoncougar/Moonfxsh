using System;
using System.Collections.Generic;

namespace Moonfish.Tags
{
    public struct BlamPointer : IEnumerable<int>, IEquatable<BlamPointer>
    {
        public readonly int ElementCount;
        public readonly int StartAddress;
        public readonly int ElementSize;

        private readonly int _endAddress;

        public int this[int index]
        {
            get { return StartAddress + ElementSize*index; }
        }

        public BlamPointer(int count, int address, int elementsize, int alignment = 4)
        {
            ElementCount = count;
            StartAddress = Padding.Pad(address, alignment);
            ElementSize = elementsize;
            _endAddress = address + ElementSize*ElementCount;
        }

        public int PointedSize
        {
            get { return ElementCount*ElementSize; }
        }

        public int EndAddress
        {
            get { return _endAddress; }
        }

        public static BlamPointer Null { get { return new BlamPointer(0, 0, 0, 0); } }

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