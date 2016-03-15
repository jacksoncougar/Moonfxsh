namespace Moonfish.Graphics
{
    /// <summary>
    /// Controls writing to destination register components
    /// </summary>
    public class WriteMask
    {
        public WriteMask( int writeMask )
        {
            //  Addressing:
            //  0: wzyx : 4

            W = writeMask.GetBit( 0 ) == 1;
            Z = writeMask.GetBit( 1 ) == 1;
            Y = writeMask.GetBit( 2 ) == 1;
            X = writeMask.GetBit( 3 ) == 1;
        }

        public bool W { get; }
        public bool X { get; }
        public bool Y { get; }
        public bool Z { get; }

        public override string ToString( )
        {
            var x = X ? 'x' : '\0';
            var y = Y ? 'y' : '\0';
            var z = Z ? 'z' : '\0';
            var w = W ? 'w' : '\0';
            return new string( new[] {x, y, z, w} ).Trim();
        }
    };
}