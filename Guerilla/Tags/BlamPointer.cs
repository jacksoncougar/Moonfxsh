using System;
using System.Collections.Generic;

namespace Moonfish.Tags
{
    public struct BlamPointer : IEnumerable<int>, IEquatable<BlamPointer>
    {
        public readonly int elementCount;
        public readonly int startAddress;
        public readonly int elementSize;
        private readonly int _endAddress;

        public int this[ int index ]
        {
            get { return startAddress + elementSize * index; }
        }

        public BlamPointer( int count, int address, int elementsize, int alignment = 4 )
        {
            elementCount = count;
            startAddress = Padding.Pad( address, alignment );
            elementSize = elementsize;
            _endAddress = address + elementSize * elementCount;
        }

        public int PointedSize
        {
            get { return elementCount * elementSize; }
        }

        public int EndAddress
        {
            get { return _endAddress; }
        }

        public IEnumerator<int> GetEnumerator( )
        {
            for ( var i = 0; i < elementCount; ++i )
            {
                yield return startAddress + elementSize * i;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
        {
            return GetEnumerator( );
        }

        public bool Intersects( BlamPointer other )
        {
            return !( startAddress + PointedSize <= other.startAddress
                      || other.startAddress + other.PointedSize <= startAddress );
        }

        public override bool Equals( object obj )
        {
            if ( obj is BlamPointer )
            {
                return ( this as IEquatable<BlamPointer> ).Equals( ( BlamPointer ) obj );
            }
            return base.Equals( obj );
        }

        public override int GetHashCode( )
        {
            return startAddress.GetHashCode( );
        }

        bool IEquatable<BlamPointer>.Equals( BlamPointer other )
        {
            return startAddress == other.startAddress && elementCount == other.elementCount &&
                   elementSize == other.elementSize;
        }

        public override string ToString( )
        {
            return string.Format( "{0}:{1}", startAddress, elementCount );
        }
    }
}