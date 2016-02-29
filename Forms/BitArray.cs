public class BitArray
{
    private bool littleEndian;
    private byte[] data;

    public BitArray( byte[] _data, bool _littleEndian = true )
    {
        data = _data;
        littleEndian = _littleEndian;
    }
    
    public override string ToString( )
    {
        //  Case: LittleEndian ( the LSB are in the highest address )
        //  Procedure: 
        //  (0) read each byte in data array from back to front
        //  (1) foreach byte read every bit from least to most significant
        //  (2) convert each bit to bool
        if ( littleEndian )
        {
            const int bitsPerByte = 8;
            var charBuffer = new char[data.Length * bitsPerByte];
            // Start at the back of the array and work to the front
            for ( int i = data.GetUpperBound( 0 ); i >= 0; i-- )
            {
                var section = data[ i ];
                var bits = GetBits( ref section );
                charBuffer[i * bitsPerByte + 0] = bits[0] ? '1' : '0';
                charBuffer[i * bitsPerByte + 1] = bits[1] ? '1' : '0';
                charBuffer[i * bitsPerByte + 2] = bits[2] ? '1' : '0';
                charBuffer[i * bitsPerByte + 3] = bits[3] ? '1' : '0';
                charBuffer[i * bitsPerByte + 4] = bits[4] ? '1' : '0';
                charBuffer[i * bitsPerByte + 5] = bits[5] ? '1' : '0';
                charBuffer[i * bitsPerByte + 6] = bits[6] ? '1' : '0';
                charBuffer[i * bitsPerByte + 7] = bits[7] ? '1' : '0';
            }
            return new string( charBuffer );
        }
        return base.ToString( );
    }

    private static bool[] GetBits( ref byte section )
    {
        const int bitMask = 0x1;
        var bit0 = ( ( section >> 0 ) & bitMask ) == 1;
        var bit1 = ( ( section >> 1 ) & bitMask ) == 1;
        var bit2 = ( ( section >> 2 ) & bitMask ) == 1;
        var bit3 = ( ( section >> 3 ) & bitMask ) == 1;
        var bit4 = ( ( section >> 4 ) & bitMask ) == 1;
        var bit5 = ( ( section >> 5 ) & bitMask ) == 1;
        var bit6 = ( ( section >> 6 ) & bitMask ) == 1;
        var bit7 = ( ( section >> 7 ) & bitMask ) == 1;
        return new[] {bit7, bit6, bit5, bit4, bit3, bit2, bit1, bit0};
    }
}