using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Fasterflect;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     nVidia IL vertex program instruction
    /// </summary>
    public class VertexProgramInstruction
    {
        [SuppressMessage( "ReSharper", "InconsistentNaming" )]
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

            TEMP = 0xFF //r*
        };

        [SuppressMessage( "ReSharper", "InconsistentNaming" )]
        public enum ScalarOps
        {
            /// <summary>
            ///     No operation
            /// </summary>
            [OpCodeAttributes( false, false, false )] NOP = 0x00,

            /// <summary>
            ///     Move
            /// </summary>
            [OpCodeAttributes( false, false, true )] MOV = 0x01,

            /// <summary>
            ///     Reciprocal
            /// </summary>
            [OpCodeAttributes( false, false, true )] RCP = 0x02,

            /// <summary>
            ///     Reciprocal clamped
            /// </summary>
            [OpCodeAttributes( false, false, true )] RCC = 0x03,

            /// <summary>
            ///     Reciprocal square root
            /// </summary>
            [OpCodeAttributes( false, false, true )] RSQ = 0x04,

            /// <summary>
            ///     Exponent
            /// </summary>
            [OpCodeAttributes( false, false, true )] EXP = 0x05,

            /// <summary>
            ///     Logarithm
            /// </summary>
            [OpCodeAttributes( false, false, true )] LOG = 0x06,

            /// <summary>
            ///     Compute lighting coefficients
            /// </summary>
            [OpCodeAttributes( false, false, true )] LIT = 0x07
        }

        [SuppressMessage( "ReSharper", "InconsistentNaming" )]
        public enum VectorOps
        {
            /// <summary>
            ///     No Operation
            /// </summary>
            [OpCodeAttributes( false, false, false )] NOP = 0x00,

            /// <summary>
            ///     Move
            /// </summary>
            [OpCodeAttributes( true, false, false )] MOV = 0x01,

            /// <summary>
            ///     Multiply
            /// </summary>
            [OpCodeAttributes( true, true, false )] MUL = 0x02,

            /// <summary>
            ///     Add
            /// </summary>
            [OpCodeAttributes( true, false, true )] ADD = 0x03,

            /// <summary>
            ///     Multiply & Add
            /// </summary>
            [OpCodeAttributes( true, true, true )] MAD = 0x04,

            /// <summary>
            ///     3-component dot product
            /// </summary>
            [OpCodeAttributes( true, true, false )] DP3 = 0x05,

            /// <summary>
            ///     4-component dot product
            /// </summary>
            [OpCodeAttributes( true, true, false )] DP4 = 0x07,

            /// <summary>
            ///     Homogeneous dot product
            /// </summary>
            [OpCodeAttributes( true, true, false )] DPH = 0x06,

            /// <summary>
            ///     Distance vector
            /// </summary>
            [OpCodeAttributes( true, true, false )] DST = 0x08,

            /// <summary>
            ///     Minimum
            /// </summary>
            [OpCodeAttributes( true, true, false )] MIN = 0x09,

            /// <summary>
            ///     Maximum
            /// </summary>
            [OpCodeAttributes( true, true, false )] MAX = 0x0A,

            /// <summary>
            ///     Set on: less-than
            /// </summary>
            [OpCodeAttributes( true, true, false )] SLT = 0x0B,

            /// <summary>
            ///     Set on: greater-than or equal
            /// </summary>
            [OpCodeAttributes( true, true, false )] SGE = 0x0C,

            /// <summary>
            ///     Address register load
            /// </summary>
            [OpCodeAttributes( true, false, false )] ARL = 0x0D,

            /// <summary>
            ///     Fraction
            /// </summary>
            [OpCodeAttributes( false, false, false )] FRC = 0x0E,

            /// <summary>
            ///     Floor
            /// </summary>
            [OpCodeAttributes( false, false, false )] FLR = 0x0F,

            /// <summary>
            ///     Set on: equal
            /// </summary>
            [OpCodeAttributes( false, false, false )] SEQ = 0x10,

            /// <summary>
            ///     Set on: false
            /// </summary>
            [OpCodeAttributes( false, false, false )] SFL = 0x11,

            /// <summary>
            ///     Set on: greater-than
            /// </summary>
            [OpCodeAttributes( false, false, false )] SGT = 0x12,

            /// <summary>
            ///     Set on: less-than or equal
            /// </summary>
            [OpCodeAttributes( false, false, false )] SLE = 0x13,

            /// <summary>
            ///     Set on: not equal
            /// </summary>
            [OpCodeAttributes( false, false, false )] SNE = 0x14,

            /// <summary>
            ///     Set on: true
            /// </summary>
            [OpCodeAttributes( false, false, false )] STR = 0x15,

            /// <summary>
            ///     Set sign
            /// </summary>
            [OpCodeAttributes( false, false, false )] SSG = 0x16,

            /// <summary>
            ///     Address register load (round)
            /// </summary>
            [OpCodeAttributes( false, false, false )] ARR = 0x17,

            /// <summary>
            ///     Address register add
            /// </summary>
            [OpCodeAttributes( false, false, false )] ARA = 0x18,

            /// <summary>
            ///     Texture Sample ...
            /// </summary>
            [OpCodeAttributes( false, false, false )] TXWHAT = 0x19
        }

        private const string RegisterToken = "r";
        private const string AttributeToken = "v";
        private const string ConstantToken = "c";

        public VertexProgramInstruction( byte[] data )
        {
            var dword0 = BitConverter.ToUInt32( data, 0 );
            var dword1 = BitConverter.ToUInt32( data, 4 );
            var dword2 = BitConverter.ToUInt32( data, 8 );
            var dword3 = BitConverter.ToUInt32( data, 12 );

            ScalarOp = ( ScalarOps ) GetBits( dword1, ScalarOpCodeMask, ScalarOpCodeShift );
            VectorOp = ( VectorOps ) GetBits( dword1, VectorOpCodeMask, VectorOpCodeShift );
            ConstantSource = GetBits( dword1, ConstantSourceMask, ConstantSourceShift );
            AttributerSource = GetBits( dword1, AttributeSourceMask, AttributeSourceShift );

            var src0Bits = GetSplitBits( dword1, dword2, Src0MsbMask, Src0MsbShift, Src0LsbMask, Src0LsbShift,
                Src0LsbLength );
            var src1Bits = GetBits( dword2, Src1Mask, Src1Shift );
            var src2Bits = GetSplitBits( dword2, dword3, Src2MsbMask, Src2MsbShift, Src2LsbMask, Src2LsbShift,
                Src2LsbLength );

            Source0 = new SourceRegister( src0Bits );
            Source1 = new SourceRegister( src1Bits );
            Source2 = new SourceRegister( src2Bits );

            DstTempWriteMask = new WriteMask( GetBits( dword3, Dst2WriteMaskMask, Dst2WriteMaskShift ) );
            RegisterSource = GetBits( dword3, RegisterMask, RegisterShift );
            DstScalarWriteMask = new WriteMask( GetBits( dword3, Dst1WriteMaskMask, Dst1WriteMaskShift ) );
            DstVectorWriteMask = new WriteMask( GetBits( dword3, Dst0WriteMaskMask, Dst0WriteMaskShift ) );
            ScalarResult = GetBits( dword3, ResultMask, ResultShift ) == 1;
            Destination = ( DestinationRegister ) GetBits( dword3, Dst0Mask, Dst0Shift );
            IndexConstant = GetBits( dword3, IndexConstantMask, IndexConstantShift );
            LastInstruction = GetBits( dword3, LastMask, LastShift ) == 1;
        }

        public int AttributerSource { get; }
        public int ConstantSource { get; }
        public DestinationRegister Destination { get; }
        public WriteMask DstScalarWriteMask { get; }

        public WriteMask DstTempWriteMask { get; }
        public WriteMask DstVectorWriteMask { get; }
        public int IndexConstant { get; }
        public bool LastInstruction { get; }
        public int RegisterSource { get; }
        public ScalarOps ScalarOp { get; }
        public bool ScalarResult { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source0 { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source1 { get; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SourceRegister Source2 { get; }

        public string ToAsm
        {
            get
            {
                var asm = $@"{VectorOp} {GetDestinationToken( )} {GetSourceToken( Source0 )} {GetSourceToken( Source1 )} {GetSourceToken
                    ( Source2 )} ".Replace( "\0", "" );
                return asm;
            }
        }

        public VectorOps VectorOp { get; }

        private static int GetBits( uint dword, int mask, int shift )
        {
            return ( int ) ( ( dword & mask ) >> shift );
        }

        private string GetDestinationToken( )
        {
            switch ( Destination )
            {
                case DestinationRegister.POS:
                    return ScalarResult
                        ? "oPos" + "." + DstVectorWriteMask
                        : "~r" + RegisterSource + "." + DstTempWriteMask;
                case DestinationRegister.COL0:
                    return "oD0" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.COL1:
                    return "oD1" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.FOGC:
                    return "oFog" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.PSZ:
                    return "oPts" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.BFC0:
                    return "oB0" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.BFC1:
                    return "oB1" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.TC0:
                    return "oT0" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.TC1:
                    return "oT1" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.TC2:
                    return "oT2" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.TC3:
                    return "oT3" + "." + ( ScalarResult ? DstVectorWriteMask.ToString( ) : DstTempWriteMask + "!" );
                case DestinationRegister.TEMP:
                    return "r" + RegisterSource + "." + DstTempWriteMask;
                default:
                    return "";
            }
        }

        /// <summary>
        ///     Makes a string from the SourceRegister value. e.g -r10.xyzw
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string GetSourceToken( SourceRegister source )
        {
            //  Use reflection to determine which Source values to use with the OpCode,
            //  return empty string for any unused source
            var attribute = ( OpCodeAttributes ) VectorOp.Attribute( typeof ( OpCodeAttributes ) );
            if ( ( !attribute.ParamA || source != Source0 ) && ( !attribute.ParamB || source != Source1 ) &&
                 ( !attribute.ParamC || source != Source2 ) ) return string.Empty;

            switch ( source.Type )
            {
                case SourceRegister.SourceType.Temporary:
                    return source.NegationPrefix + RegisterToken + source.TempID + source.Swizzle.GetSuffix( );
                case SourceRegister.SourceType.Attribute:
                    return source.NegationPrefix + AttributeToken + AttributerSource + source.Swizzle.GetSuffix( );
                case SourceRegister.SourceType.Constant:
                    return source.NegationPrefix + ConstantToken + ConstantSource + source.Swizzle.GetSuffix( );
                default:
                    throw new DataException( "Invalid " + nameof( source.Type ) );
            }
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
        private static int GetSplitBits( uint dword0, uint dword1, int msbMask, int msbShift, int lsbMask, int lsbShift,
            int lsbLength )
        {
            //DWORD0..DWORD1
            //...MSB..LSB...
            var msbBits = ( dword0 & msbMask ) >> msbShift;
            var lsbBits = ( dword1 & lsbMask ) >> lsbShift;
            var bits = ( int ) ( msbBits << lsbLength | lsbBits );
            return bits;
        }

        private class OpCodeAttributes : Attribute
        {
            public OpCodeAttributes( bool paramA, bool paramB, bool paramC )
            {
                ParamA = paramA;
                ParamB = paramB;
                ParamC = paramC;
            }

            public bool ParamA { get; }
            public bool ParamB { get; }
            public bool ParamC { get; }
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
        private const int Src2LsbShift = 28;
        private const int Src2LsbMask = 0xF << Src2LsbShift;
        private const int Src2LsbLength = 4;

        //  DWORD2
        private const int Src2MsbShift = 0;
        private const int Src2MsbMask = 0x7FF << Src2MsbShift;
        private const int Src1Shift = 11;
        private const int Src1Mask = 0x7FFF << Src1Shift;
        private const int Src0LsbShift = 26;
        private const int Src0LsbMask = 0x3F << Src0LsbShift;
        private const int Src0LsbLength = 6;


        //  DWORD1
        private const int Src0MsbShift = 0;
        private const int Src0MsbMask = 0x1FF << Src0MsbShift;
        private const int AttributeSourceShift = 9;
        private const int AttributeSourceMask = 0xF << AttributeSourceShift;
        private const int ConstantSourceShift = 13;
        private const int ConstantSourceMask = 0xFF << ConstantSourceShift;
        private const int VectorOpCodeShift = 21;
        private const int VectorOpCodeMask = 0xF << VectorOpCodeShift;
        private const int ScalarOpCodeShift = 25;
        private const int ScalarOpCodeMask = 0x7F << ScalarOpCodeShift;

        //  DWORD0

        #endregion
    };
}