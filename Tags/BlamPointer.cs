using System;
using System.Collections.Generic;

namespace Moonfish.Tags
{
    public struct BlamPointer : IEnumerable<int>, IEquatable<BlamPointer>
    {
        public readonly int count;
        public readonly int address;
        public readonly int elementSize;

        public int this[ int index ]
        {
            get { return address + elementSize * index; }
        }

        public BlamPointer( int count, int address, int elementSize )
        {
            this.count = count;
            this.address = address;
            this.elementSize = elementSize;
        }

        public int PointedSize
        {
            get { return count * elementSize; }
        }

        public IEnumerator<int> GetEnumerator( )
        {
            for ( var i = 0; i < count; ++i )
            {
                yield return address + elementSize * i;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
        {
            return GetEnumerator();
        }

        public bool Intersects( BlamPointer other )
        {
            return !( address + PointedSize <= other.address
                      || other.address + other.PointedSize <= address );
        }

        public override bool Equals( object obj )
        {
            if ( obj is BlamPointer )
            {
                return ( this as IEquatable<BlamPointer> ).Equals( ( BlamPointer )obj );
            }
            return base.Equals( obj );
        }

        public override int GetHashCode( )
        {
            return address.GetHashCode();
        }

        bool IEquatable<BlamPointer>.Equals( BlamPointer other )
        {
            return address == other.address && count == other.count && elementSize == other.elementSize;
        }

        public override string ToString( )
        {
            return string.Format( "{0}:{1}", address, count );
        }
    }
}