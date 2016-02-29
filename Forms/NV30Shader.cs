using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedMember.Local" )]
[SuppressMessage( "ReSharper", "InconsistentNaming" )]
public class NV30Shader
{
    public enum ScalarOps
    {
        /// <summary>
        ///     No operation
        /// </summary>
        NOP = 0x00,

        /// <summary>
        ///     Move
        /// </summary>
        MOV = 0x01,

        /// <summary>
        ///     Reciprocal
        /// </summary>
        RCP = 0x02,

        /// <summary>
        ///     Reciprocal clamped
        /// </summary>
        RCC = 0x03,

        /// <summary>
        ///     Reciprocal square root
        /// </summary>
        RSQ = 0x04,

        /// <summary>
        ///     Exponent
        /// </summary>
        EXP = 0x05,

        /// <summary>
        ///     Logarithm
        /// </summary>
        LOG = 0x06,

        /// <summary>
        ///     Compute lighting coefficients
        /// </summary>
        LIT = 0x07
    }

    public enum VectorOps
    {
        /// <summary>
        ///     No Operation
        /// </summary>
        NOP = 0x00,

        /// <summary>
        ///     Move
        /// </summary>
        MOV = 0x01,

        /// <summary>
        ///     Multiply
        /// </summary>
        MUL = 0x02,

        /// <summary>
        ///     Add
        /// </summary>
        ADD = 0x03,

        /// <summary>
        ///     Multiply & Add
        /// </summary>
        MAD = 0x04,

        /// <summary>
        ///     3-component dot product
        /// </summary>
        DP3 = 0x05,

        /// <summary>
        ///     4-component dot product
        /// </summary>
        DP4 = 0x07,

        /// <summary>
        ///     Homogeneous dot product
        /// </summary>
        DPH = 0x06,

        /// <summary>
        ///     Distance vector
        /// </summary>
        DST = 0x08,

        /// <summary>
        ///     Minimum
        /// </summary>
        MIN = 0x09,

        /// <summary>
        ///     Maximum
        /// </summary>
        MAX = 0x0A,

        /// <summary>
        ///     Set on: less-than
        /// </summary>
        SLT = 0x0B,

        /// <summary>
        ///     Set on: greater-than or equal
        /// </summary>
        SGE = 0x0C,

        /// <summary>
        ///     Address register load
        /// </summary>
        ARL = 0x0D,

        /// <summary>
        ///     Fraction
        /// </summary>
        FRC = 0x0E,

        /// <summary>
        ///     Floor
        /// </summary>
        FLR = 0x0F,

        /// <summary>
        ///     Set on: equal
        /// </summary>
        SEQ = 0x10,

        /// <summary>
        ///     Set on: false
        /// </summary>
        SFL = 0x11,

        /// <summary>
        ///     Set on: greater-than
        /// </summary>
        SGT = 0x12,

        /// <summary>
        ///     Set on: less-than or equal
        /// </summary>
        SLE = 0x13,

        /// <summary>
        ///     Set on: not equal
        /// </summary>
        SNE = 0x14,

        /// <summary>
        ///     Set on: true
        /// </summary>
        STR = 0x15,

        /// <summary>
        ///     Set sign
        /// </summary>
        SSG = 0x16,

        /// <summary>
        ///     Address register load (round)
        /// </summary>
        ARR = 0x17,

        /// <summary>
        ///     Address register add
        /// </summary>
        ARA = 0x18,

        /// <summary>
        ///     Texture Sample ...
        /// </summary>
        TXWHAT = 0x19
    }

    #region Constants

    //  DWORD3   
    private const int LastShift = 0;
    private const int LastMask = 0x1 << LastShift;
    private const int IndexConstantShift = 1;
    private const int IndexConstantMask = 0x1 << IndexConstantShift;
    private const int Dst0Shift = 3;
    private const int Dst0Mask = 0xFF << Dst0Shift;
    private const int ResultShift = 11;
    private const int ResultMask = 0x1 << ResultShift;
    private const int Dst0WriteMaskShift = 12;
    private const int Dst0WriteMaskMask = 0xF << Dst0WriteMaskShift;
    private const int Dst1WriteMaskShift = 16;
    private const int Dst1WriteMaskMask = 0xF << Dst1WriteMaskShift;
    private const int RegisterShift = 20;
    private const int RegisterMask = 0xF << RegisterShift;
    private const int Dst2WriteMaskShift = 24;
    private const int Dst2WriteMaskMask = 0xF << Dst2WriteMaskShift;
    private const int src2LsbShift = 28;
    private const int src2LsbMask = 0xF << src2LsbShift;
    private const int src2LsbLength = 4;

    //  DWORD2
    private const int src2MsbShift = 0;
    private const int src2MsbMask = 0x7FF << src2MsbShift;
    private const int src1Shift = 11;
    private const int src1Mask = 0x7FFF << src1Shift;
    private const int src0LsbShift = 26;
    private const int src0LsbMask = 0x3F << src0LsbShift;
    private const int src0LsbLength = 6;


    //  DWORD1
    private const int src0MsbShift = 0;
    private const int src0MsbMask = 0x1FF << src0MsbShift;
    private const int attributeSourceShift = 9;
    private const int attributeSourceMask = 0xF << attributeSourceShift;
    private const int constantSourceShift = 13;
    private const int constantSourceMask = 0xFF << constantSourceShift;
    private const int vectorOpCodeShift = 21;
    private const int vectorOpCodeMask = 0xF << vectorOpCodeShift;
    private const int scalarOpCodeShift = 25;
    private const int scalarOpCodeMask = 0x7F<< scalarOpCodeShift;

    //  DWORD0

    #endregion

    public NV30Shader( byte[] data )
    {
        var DWORD0 = BitConverter.ToUInt32( data, 0 );
        var DWORD1 = BitConverter.ToUInt32( data, 4 );
        var DWORD2 = BitConverter.ToUInt32( data, 8 );
        var DWORD3 = BitConverter.ToUInt32( data, 12 );

        ScalarOp = (ScalarOps)GetBits( DWORD1, scalarOpCodeMask, scalarOpCodeShift );
        VectorOp = ( VectorOps ) GetBits( DWORD1, vectorOpCodeMask, vectorOpCodeShift );
        ConstantSource = GetBits( DWORD1, constantSourceMask, constantSourceShift );
        AttributerSource = GetBits( DWORD1, attributeSourceMask, attributeSourceShift );

        var src0Bits = GetSplitBits( DWORD1, DWORD2, src0MsbMask, src0MsbShift, src0LsbMask, src0LsbShift, src0LsbLength );
        var src1Bits = GetBits( DWORD2, src1Mask, src1Shift );
        var src2Bits = GetSplitBits( DWORD2, DWORD3, src2MsbMask, src2MsbShift, src2LsbMask, src2LsbShift, src2LsbLength );

        Source0 = new Source(src0Bits);
        Source1 = new Source(src1Bits);
        Source2 = new Source(src2Bits);

        DstTempWriteMask = new WriteMask( GetBits( DWORD3, Dst2WriteMaskMask, Dst2WriteMaskShift ) );
        RegisterSource = GetBits( DWORD3, RegisterMask, RegisterShift );
        DstScalarWriteMask = new WriteMask( GetBits( DWORD3, Dst1WriteMaskMask, Dst1WriteMaskShift ) );
        DstVectorWriteMask = new WriteMask( GetBits( DWORD3, Dst1WriteMaskMask, Dst1WriteMaskShift ) );
        ScalarResult = GetBits( DWORD3, ResultMask, ResultShift ) == 1;
        Destination = ( DestinationRegister ) GetBits( DWORD3, Dst0Mask, Dst0Shift );
        IndexConstant = GetBits( DWORD3, IndexConstantMask, IndexConstantShift );
        LastInstruction = GetBits( DWORD3, LastMask, LastShift ) == 1;
    }

    public enum DestinationRegister
    {
        POS = 0, //oPos

        COL0 = 3, //oD0
        COL1 = 4, //oD1?
        FOGC = 5, //oFog
        PSZ = 6, //oPts
        BFC0 = 7, //oB0
        BFC1 = 8, //oB1?
        TC0 = 9, //oT0
        TC1 = 10, //oT1
        TC2 = 11, //oT2
        TC3 = 12, //oT3

        TEMP = 0xFF, //r*
    };

    public class WriteMask
    {
        public bool X { get; }
        public bool Y { get; }
        public bool Z { get; }
        public bool W { get; }

        public WriteMask( int mask )
        {
            W = ( mask & 0x1 ) >> 0 == 1;
            Z = ( mask & 0x2 ) >> 1 == 1;
            Y = ( mask & 0x4 ) >> 2 == 1;
            X = ( mask & 0x8 ) >> 3 == 1;
        }

        public override string ToString( )
        {
            char x = X ? 'x' : '\0';
            char y = X ? 'y' : '\0';
            char z = X ? 'z' : '\0';
            char w = X ? 'w' : '\0';
            return new string( new[] {x, y, z, w} );
        }
    };

    public VectorOps VectorOp { get; }
    public ScalarOps ScalarOp { get; }
    public int ConstantSource { get; }
    public int AttributerSource { get; }

    [TypeConverter( typeof ( ExpandableObjectConverter ) )]
    public Source Source0 { get; }

    [TypeConverter( typeof ( ExpandableObjectConverter ) )]
    public Source Source1 { get; }

    [TypeConverter( typeof ( ExpandableObjectConverter ) )]
    public Source Source2 { get; }

    public WriteMask DstTempWriteMask { get; }
    public int RegisterSource { get; }
    public WriteMask DstScalarWriteMask { get; }
    public WriteMask DstVectorWriteMask { get; }
    public bool ScalarResult { get; }
    public DestinationRegister Destination { get; }
    public int IndexConstant { get; }
    public bool LastInstruction { get; }

    private int GetBits( uint dword, int mask, int shift )
    {
        return ( int ) ( ( dword & mask ) >> shift );
    }

    /// <summary>
    ///     Returns a value that is split between int boundaries
    /// </summary>
    /// <param name="dword0">The lower addressed int</param>
    /// <param name="dword1">The higher addressed int</param>
    /// <param name="msbMask">Mask for bits in dword0 (Mask should be pre-shifted because it is applied first)</param>
    /// <param name="msbShift">Number of bits to right-shift msbs</param>
    /// <param name="lsbMask">Mask for bits in dword1 (Mask should be pre=shifted because it is applied first)</param>
    /// <param name="lsbShift">Number of bits to right-shift lsbs</param>
    /// <param name="lsbLength">Number of lsbs</param>
    /// <returns></returns>
    private int GetSplitBits( uint dword0, uint dword1, int msbMask, int msbShift, int lsbMask, int lsbShift,
        int lsbLength )
    {
        //DWORD0..DWORD1
        //...MSB..LSB...
        var MsbBits = ( dword0 & msbMask ) >> msbShift;
        var LsbBits = ( dword1 & lsbMask ) >> lsbShift;
        var Bits = ( int ) ( MsbBits << lsbLength | LsbBits );
        return Bits;
    }
    
    public struct SwizzleMask
    {
        public enum Swizzle
        {
            X = 0,
            Y = 1,
            Z = 2,
            W = 3
        }

        public Swizzle X { get; }
        public Swizzle Y { get; }
        public Swizzle Z { get; }
        public Swizzle W { get; }

        public SwizzleMask( byte data )
        {
            X = ( Swizzle ) ( ( data >> 6 ) & 0x3 );
            Y = ( Swizzle ) ( ( data >> 4 ) & 0x3 );
            Z = ( Swizzle ) ( ( data >> 2 ) & 0x3 );
            W = ( Swizzle ) ( ( data >> 0 ) & 0x3 );
        }
    };

    public class Source
    {
        public enum SourceType
        {
            Temp = 1,
            Attribute = 2,
            Constant = 3
        };

        public Source( int data )
        {
            Type = ( SourceType ) ( ( data >> 0 ) & 0x3 );
            TempID = ( byte ) ( ( data >> 2 ) & 0xF );
            Swizzle = new SwizzleMask( ( byte ) ( ( data >> 6 ) & 0xFF ) );
            Negate = ( ( data >> 14 ) & 0x1 ) == 1;
        }

        public bool Negate { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SwizzleMask Swizzle { get; }

        public byte TempID { get; }
        public SourceType Type { get; }
    }
};