using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics.RenderingEngine
{
    static class Extensions
    {
        public static IEnumerable<T> TakeSubset<T>( this IEnumerable<T> enumerable, TagBlockIndexStructBlock param )
        {
            return enumerable.Skip( param.Index ).Take( param.Length );
        }

        public static CullFaceMode ConvertCullMode( this D3DCULL cull )
        {
            switch ( cull )
            {
                case D3DCULL.NONE:
                    return CullFaceMode.FrontAndBack;
                    break;
                case D3DCULL.CW:
                    return CullFaceMode.Back;
                    break;
                case D3DCULL.CCW:
                    return CullFaceMode.Front;
                    break;
                default:
                    throw new ArgumentOutOfRangeException( nameof( cull ), cull, null );
            }
        }

        public static BlendingFactorDest ConvertToBlendingFactorDest( this D3DBLEND blend )
        {
            switch ( blend )
            {
                case D3DBLEND.ZERO:
                    return BlendingFactorDest.Zero;
                case D3DBLEND.ONE:
                    return BlendingFactorDest.One;
                case D3DBLEND.SRCCOLOR:
                    return BlendingFactorDest.SrcColor;
                case D3DBLEND.INVSRCCOLOR:
                    return BlendingFactorDest.OneMinusSrcColor;
                case D3DBLEND.SRCALPHA:
                    return BlendingFactorDest.SrcAlpha;
                case D3DBLEND.INVSRCALPHA:
                    return BlendingFactorDest.OneMinusSrcAlpha;
                case D3DBLEND.DESTALPHA:
                    return BlendingFactorDest.DstAlpha;
                case D3DBLEND.INVDESTALPHA:
                    return BlendingFactorDest.OneMinusDstAlpha;
                case D3DBLEND.DESTCOLOR:
                    return BlendingFactorDest.DstColor;
                case D3DBLEND.INVDESTCOLOR:
                    return BlendingFactorDest.OneMinusDstColor;
                case D3DBLEND.SRCALPHASAT:
                    return BlendingFactorDest.SrcAlphaSaturate;
                case D3DBLEND.CONSTANTCOLOR:
                    return BlendingFactorDest.ConstantColor;
                case D3DBLEND.INVCONSTANTCOLOR:
                    return BlendingFactorDest.OneMinusConstantColor;
                case D3DBLEND.CONSTANTALPHA:
                    return BlendingFactorDest.ConstantAlpha;
                case D3DBLEND.INVCONSTANTALPHA:
                    return BlendingFactorDest.OneMinusConstantAlpha;
                default:
                    throw new ArgumentOutOfRangeException( nameof( blend ), blend, null );
            }
        }

        public static BlendingFactorSrc ConvertToBlendingFactorSrc( this D3DBLEND blend )
        {
            return ( BlendingFactorSrc ) blend.ConvertToBlendingFactorDest( );
        }

        public static BlendEquationMode ConvertToBlendEquation( this D3DBLENDOP blendOp )
        {
            switch ( blendOp )
            {
                case D3DBLENDOP.ADD:
                    return BlendEquationMode.FuncAdd;
                case D3DBLENDOP.SUBTRACT:
                    return BlendEquationMode.FuncSubtract;
                case D3DBLENDOP.REVSUBTRACT:
                    return BlendEquationMode.FuncReverseSubtract;
                case D3DBLENDOP.MIN:
                    return BlendEquationMode.Min;
                case D3DBLENDOP.MAX:
                    return BlendEquationMode.Max;
                case D3DBLENDOP.ADDSIGNED:
                case D3DBLENDOP.REVSUBTRACTSIGNED:
                case D3DBLENDOP.FORCE_DWORD:
                default:
                    throw new ArgumentOutOfRangeException( nameof( blendOp ), blendOp, null );
            }
        }

        public static IEnumerable<T> TakeSubset<T>( this IEnumerable<T> enumerable, int startIndex, int length )
        {
            return enumerable.Skip(startIndex).Take(length);
        }
    }
}
