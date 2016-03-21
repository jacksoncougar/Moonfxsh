using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics.RenderingEngine
{
    public static class StateManager
    {
        public static EventHandler<bool> AlphaBlendEnableChanged;
        public static EventHandler<bool> AlphaTestEnableChanged;
        public static EventHandler<D3DCMPFUNC> AlphaFuncChanged;
        public static EventHandler<float> AlphaRefChanged;

        /// <summary>
        ///     Tracks changes across the render states to avoid dispatching redundant calls
        /// </summary>
        private static readonly Dictionary<D3DRENDERSTATETYPE, int> CurrentState =
            new Dictionary<D3DRENDERSTATETYPE, int>( );

        /// <summary>
        ///     Handles dispatching state changes for updating
        /// </summary>
        /// <param name="stateHandle"></param>
        public static void DispatchState( MaterialShader.RenderStateHandle stateHandle )
        {
            // Quit early if updating is pointless
            if (CurrentState.ContainsKey(stateHandle.RenderState) &&
                 CurrentState[stateHandle.RenderState] == stateHandle.UnionValue)
                return;

            switch ( stateHandle.RenderState )
            {
                case D3DRENDERSTATETYPE.ALPHATESTENABLE:
                {
                    var enable = stateHandle.UnionValue > 0;
                    AlphaTestEnableChanged?.Invoke( null, enable );
                }
                    break;
                case D3DRENDERSTATETYPE.ALPHAFUNC:
                {
                    var function = ( D3DCMPFUNC ) stateHandle.UnionValue;
                    AlphaFuncChanged?.Invoke( null, function );
                }
                    break;
                case D3DRENDERSTATETYPE.ALPHAREF:
                {
                    var alphaReference = ( float ) stateHandle.UnionValue / byte.MaxValue;
                    AlphaRefChanged?.Invoke( null, alphaReference );
                }
                    break;
                case D3DRENDERSTATETYPE.COLORWRITEENABLE:
                {
                    var writeMask = new ColourWriteMask( stateHandle.UnionValue );
                    GL.ColorMask( writeMask.R, writeMask.G, writeMask.B, writeMask.A );
                }
                    break;
                case D3DRENDERSTATETYPE.ALPHABLENDENABLE:
                {
                    var enable = stateHandle.UnionValue > 0;
                    if ( enable ) GL.Enable( EnableCap.Blend );
                    else GL.Disable( EnableCap.Blend );
                    AlphaBlendEnableChanged?.Invoke( null, enable );
                }
                    break;
                case D3DRENDERSTATETYPE.DESTBLEND:
                {
                    EnableBlendFunc( D3DRENDERSTATETYPE.DESTBLEND, stateHandle );
                }
                    break;
                case D3DRENDERSTATETYPE.SRCBLEND:
                {
                    EnableBlendFunc( D3DRENDERSTATETYPE.SRCBLEND, stateHandle );
                }
                    break;
                case D3DRENDERSTATETYPE.BLENDOP:
                {
                    var blendOp = ( D3DBLENDOP ) stateHandle.UnionValue;
                    var blendEquation = blendOp.ConvertToBlendEquation( );
                    GL.BlendEquation( blendEquation );
                }
                    break;
                    case D3DRENDERSTATETYPE.ZWRITEENABLE:
                {
                    //var enable = stateHandle.unionValue > 0;
                    //GL.DepthMask( enable );
                }
                    break;
                    case D3DRENDERSTATETYPE.CULLMODE:
                {
                    var value = ( D3DCULL ) stateHandle.UnionValue;
                    var cullMode = value.ConvertCullMode( );
                    GL.Enable( EnableCap.CullFace );
                    GL.CullFace( cullMode );
                }
                    break;
                default:
                {
                    
                }
                    break;
            }
            // Update the current states
            CurrentState[ stateHandle.RenderState ] = stateHandle.UnionValue;
        }

        /// <summary>
        ///     Enables the GL.BlendFunc parameter
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stateHandle"></param>
        private static void EnableBlendFunc( D3DRENDERSTATETYPE type, MaterialShader.RenderStateHandle stateHandle )
        {
            var other = type == D3DRENDERSTATETYPE.SRCBLEND ? D3DRENDERSTATETYPE.DESTBLEND : D3DRENDERSTATETYPE.SRCBLEND;

            int value = CurrentState.TryGetValue( other, out value )
                ? value
                : 0;
            var otherBlend = ( D3DBLEND ) value;
            var blend = ( D3DBLEND ) stateHandle.UnionValue;

            if ( other == D3DRENDERSTATETYPE.SRCBLEND )
                GL.BlendFunc( otherBlend.ConvertToBlendingFactorSrc( ), blend.ConvertToBlendingFactorDest( ) );
            else
                GL.BlendFunc( blend.ConvertToBlendingFactorSrc( ), otherBlend.ConvertToBlendingFactorDest( ) );
        }

        private struct ColourWriteMask
        {
            public readonly bool R;
            public readonly bool G;
            public readonly bool B;
            public readonly bool A;

            public ColourWriteMask( int value )
            {
                var bytes = BitConverter.GetBytes( value );
                R = bytes[ 0 ] != 0;
                G = bytes[ 1 ] != 0;
                B = bytes[ 2 ] != 0;
                A = bytes[ 3 ] != 0;
            }
        }
    }
}