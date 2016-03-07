using System.Diagnostics.CodeAnalysis;
// ReSharper disable All

namespace Moonfish.Graphics.RenderingEngine
{
    public enum D3DRENDERSTATETYPE
    {
        // Simple render states that are processed by D3D immediately:

        PS_MIN = 0,

        // The following pixel-shader renderstates are all Xbox extensions:

        PS_ALPHAINPUTS0 = 0, // Pixel shader, Stage 0 alpha inputs
        PS_ALPHAINPUTS1 = 1, // Pixel shader, Stage 1 alpha inputs
        PS_ALPHAINPUTS2 = 2, // Pixel shader, Stage 2 alpha inputs
        PS_ALPHAINPUTS3 = 3, // Pixel shader, Stage 3 alpha inputs
        PS_ALPHAINPUTS4 = 4, // Pixel shader, Stage 4 alpha inputs
        PS_ALPHAINPUTS5 = 5, // Pixel shader, Stage 5 alpha inputs
        PS_ALPHAINPUTS6 = 6, // Pixel shader, Stage 6 alpha inputs
        PS_ALPHAINPUTS7 = 7, // Pixel shader, Stage 7 alpha inputs
        PS_FINALCOMBINERINPUTSABCD = 8, // Pixel shader, Final combiner inputs ABCD
        PS_FINALCOMBINERINPUTSEFG = 9, // Pixel shader, Final combiner inputs EFG
        PS_CONSTANT0_0 = 10, // Pixel shader, C0 in stage 0
        PS_CONSTANT0_1 = 11, // Pixel shader, C0 in stage 1
        PS_CONSTANT0_2 = 12, // Pixel shader, C0 in stage 2
        PS_CONSTANT0_3 = 13, // Pixel shader, C0 in stage 3
        PS_CONSTANT0_4 = 14, // Pixel shader, C0 in stage 4
        PS_CONSTANT0_5 = 15, // Pixel shader, C0 in stage 5
        PS_CONSTANT0_6 = 16, // Pixel shader, C0 in stage 6
        PS_CONSTANT0_7 = 17, // Pixel shader, C0 in stage 7
        PS_CONSTANT1_0 = 18, // Pixel shader, C1 in stage 0
        PS_CONSTANT1_1 = 19, // Pixel shader, C1 in stage 1
        PS_CONSTANT1_2 = 20, // Pixel shader, C1 in stage 2
        PS_CONSTANT1_3 = 21, // Pixel shader, C1 in stage 3
        PS_CONSTANT1_4 = 22, // Pixel shader, C1 in stage 4
        PS_CONSTANT1_5 = 23, // Pixel shader, C1 in stage 5
        PS_CONSTANT1_6 = 24, // Pixel shader, C1 in stage 6
        PS_CONSTANT1_7 = 25, // Pixel shader, C1 in stage 7
        PS_ALPHAOUTPUTS0 = 26, // Pixel shader, Stage 0 alpha outputs
        PS_ALPHAOUTPUTS1 = 27, // Pixel shader, Stage 1 alpha outputs
        PS_ALPHAOUTPUTS2 = 28, // Pixel shader, Stage 2 alpha outputs
        PS_ALPHAOUTPUTS3 = 29, // Pixel shader, Stage 3 alpha outputs
        PS_ALPHAOUTPUTS4 = 30, // Pixel shader, Stage 4 alpha outputs
        PS_ALPHAOUTPUTS5 = 31, // Pixel shader, Stage 5 alpha outputs
        PS_ALPHAOUTPUTS6 = 32, // Pixel shader, Stage 6 alpha outputs
        PS_ALPHAOUTPUTS7 = 33, // Pixel shader, Stage 7 alpha outputs
        PS_RGBINPUTS0 = 34, // Pixel shader, Stage 0 RGB inputs
        PS_RGBINPUTS1 = 35, // Pixel shader, Stage 1 RGB inputs
        PS_RGBINPUTS2 = 36, // Pixel shader, Stage 2 RGB inputs
        PS_RGBINPUTS3 = 37, // Pixel shader, Stage 3 RGB inputs
        PS_RGBINPUTS4 = 38, // Pixel shader, Stage 4 RGB inputs
        PS_RGBINPUTS5 = 39, // Pixel shader, Stage 5 RGB inputs
        PS_RGBINPUTS6 = 40, // Pixel shader, Stage 6 RGB inputs
        PS_RGBINPUTS7 = 41, // Pixel shader, Stage 7 RGB inputs
        PS_COMPAREMODE = 42, // Pixel shader, Compare modes for clipplane texture mode
        PS_FINALCOMBINERCONSTANT0 = 43, // Pixel shader, C0 in final combiner
        PS_FINALCOMBINERCONSTANT1 = 44, // Pixel shader, C1 in final combiner
        PS_RGBOUTPUTS0 = 45, // Pixel shader, Stage 0 RGB outputs
        PS_RGBOUTPUTS1 = 46, // Pixel shader, Stage 1 RGB outputs
        PS_RGBOUTPUTS2 = 47, // Pixel shader, Stage 2 RGB outputs
        PS_RGBOUTPUTS3 = 48, // Pixel shader, Stage 3 RGB outputs
        PS_RGBOUTPUTS4 = 49, // Pixel shader, Stage 4 RGB outputs
        PS_RGBOUTPUTS5 = 50, // Pixel shader, Stage 5 RGB outputs
        PS_RGBOUTPUTS6 = 51, // Pixel shader, Stage 6 RGB outputs
        PS_RGBOUTPUTS7 = 52, // Pixel shader, Stage 7 RGB outputs
        PS_COMBINERCOUNT = 53, // Pixel shader, Active combiner count (Stages 0-7)
        // Pixel shader, Reserved
        PS_DOTMAPPING = 55, // Pixel shader, Input mapping for dot product modes
        PS_INPUTTEXTURE = 56, // Pixel shader, Texture source for some texture modes

        PS__MAX = 57,

        ZFUNC = 57, // D3DCMPFUNC
        ALPHAFUNC = 58, // D3DCMPFUNC
        ALPHABLENDENABLE = 59, // TRUE to enable alpha blending
        ALPHATESTENABLE = 60, // TRUE to enable alpha tests
        ALPHAREF = 61, // BYTE
        SRCBLEND = 62, // D3DBLEND
        DESTBLEND = 63, // D3DBLEND
        ZWRITEENABLE = 64, // TRUE to enable Z writes
        DITHERENABLE = 65, // TRUE to enable dithering
        SHADEMODE = 66, // D3DSHADEMODE
        COLORWRITEENABLE = 67, // D3DCOLORWRITEENABLE_ALPHA, etc. per-channel write enable
        STENCILZFAIL = 68, // D3DSTENCILOP to do if stencil test passes and Z test fails
        STENCILPASS = 69, // D3DSTENCILOP to do if both stencil and Z tests pass
        STENCILFUNC = 70, // D3DCMPFUNC
        STENCILREF = 71, // BYTE reference value used in stencil test
        STENCILMASK = 72, // BYTE mask value used in stencil test
        STENCILWRITEMASK = 73, // BYTE write mask applied to values written to stencil buffer
        BLENDOP = 74, // D3DBLENDOP setting
        BLENDCOLOR = 75, // D3DCOLOR for D3DBLEND_CONSTANTCOLOR, etc. (Xbox extension)
        SWATHWIDTH = 76, // D3DSWATHWIDTH (Xbox extension)
        POLYGONOFFSETZSLOPESCALE = 77, // float Z factor for shadow maps (Xbox extension)
        POLYGONOFFSETZOFFSET = 78, // float bias for polygon offset (Xbox extension)
        POINTOFFSETENABLE = 79, // TRUE to enable polygon offset for points (Xbox extension)
        WIREFRAMEOFFSETENABLE = 80, // TRUE to enable polygon offset for lines (Xbox extension)
        SOLIDOFFSETENABLE = 81, // TRUE to enable polygon offset for fills (Xbox extension)
        DEPTHCLIPCONTROL = 82, // D3DDCC_CULLPRIMITIVE, etc. (Xbox extension)
        STIPPLEENABLE = 83, // TRUE to enable stipple for polygons (Xbox extension)
        SIMPLE_UNUSED8 = 84, // Reserved
        SIMPLE_UNUSED7 = 85, // Reserved
        SIMPLE_UNUSED6 = 86, // Reserved
        SIMPLE_UNUSED5 = 87, // Reserved
        SIMPLE_UNUSED4 = 88, // Reserved
        SIMPLE_UNUSED3 = 89, // Reserved
        SIMPLE_UNUSED2 = 90, // Reserved
        SIMPLE_UNUSED1 = 91, // Reserved

        SIMPLE_MAX = 92,

        // State whose handling is deferred until the next Draw[Indexed]Vertices
        // call because of interdependencies on other states:

        FOGENABLE = 92, // TRUE to enable fog blending
        FOGTABLEMODE = 93, // D3DFOGMODE
        FOGSTART = 94, // float fog start (for both vertex and pixel fog)
        FOGEND = 95, // float fog end
        FOGDENSITY = 96, // float fog density
        RANGEFOGENABLE = 97, // TRUE to enable range-based fog
        WRAP0 = 98, // D3DWRAPCOORD_0, etc. for 1st texture coord.
        WRAP1 = 99, // D3DWRAPCOORD_0, etc. for 2nd texture coord.
        WRAP2 = 100, // D3DWRAPCOORD_0, etc. for 3rd texture coord.
        WRAP3 = 101, // D3DWRAPCOORD_0, etc. for 4th texture coord.
        LIGHTING = 102, // TRUE to enable lighting
        SPECULARENABLE = 103, // TRUE to enable specular
        LOCALVIEWER = 104, // TRUE to enable camera-relative specular highlights
        COLORVERTEX = 105, // TRUE to enable per-vertex color
        BACKSPECULARMATERIALSOURCE = 106, // D3DMATERIALCOLORSOURCE (Xbox extension)
        BACKDIFFUSEMATERIALSOURCE = 107, // D3DMATERIALCOLORSOURCE (Xbox extension)
        BACKAMBIENTMATERIALSOURCE = 108, // D3DMATERIALCOLORSOURCE (Xbox extension)
        BACKEMISSIVEMATERIALSOURCE = 109, // D3DMATERIALCOLORSOURCE (Xbox extension)
        SPECULARMATERIALSOURCE = 110, // D3DMATERIALCOLORSOURCE
        DIFFUSEMATERIALSOURCE = 111, // D3DMATERIALCOLORSOURCE
        AMBIENTMATERIALSOURCE = 112, // D3DMATERIALCOLORSOURCE
        EMISSIVEMATERIALSOURCE = 113, // D3DMATERIALCOLORSOURCE
        BACKAMBIENT = 114, // D3DCOLOR (Xbox extension)
        AMBIENT = 115, // D3DCOLOR
        POINTSIZE = 116, // float point size
        POINTSIZE_MIN = 117, // float point size min threshold
        POINTSPRITEENABLE = 118, // TRUE to enable point sprites
        POINTSCALEENABLE = 119, // TRUE to enable point size scaling
        POINTSCALE_A = 120, // float point attenuation A value
        POINTSCALE_B = 121, // float point attenuation B value
        POINTSCALE_C = 122, // float point attenuation C value
        POINTSIZE_MAX = 123, // float point size max threshold
        PATCHEDGESTYLE = 124, // D3DPATCHEDGESTYLE
        PATCHSEGMENTS = 125, // DWORD number of segments per edge when drawing patches
        SWAPFILTER = 126, // D3DTEXF_LINEAR etc. filter to use for Swap (Xbox extension)
        PRESENTATIONINTERVAL = 127, // D3DPRESENT_INTERVAL_ONE, etc. (Xbox extension)
        DEFERRED_UNUSED8 = 128, // Reserved
        DEFERRED_UNUSED7 = 129, // Reserved
        DEFERRED_UNUSED6 = 130, // Reserved
        DEFERRED_UNUSED5 = 131, // Reserved
        DEFERRED_UNUSED4 = 132, // Reserved
        DEFERRED_UNUSED3 = 133, // Reserved
        DEFERRED_UNUSED2 = 134, // Reserved
        DEFERRED_UNUSED1 = 135, // Reserved

        DEFERRED_MAX = 136,

        // Complex state that has immediate processing:

        PS_TEXTUREMODES = 136, // Pixel shader, Texture addressing modes (Xbox extension)
        VERTEXBLEND = 137, // D3DVERTEXBLENDFLAGS
        FOGCOLOR = 138, // D3DCOLOR
        FILLMODE = 139, // D3DFILLMODE
        BACKFILLMODE = 140, // D3DFILLMODE (Xbox extension)
        TWOSIDEDLIGHTING = 141, // TRUE to enable two-sided lighting (Xbox extension)
        NORMALIZENORMALS = 142, // TRUE to enable automatic normalization
        ZENABLE = 143, // D3DZBUFFERTYPE (or TRUE/FALSE for legacy)
        STENCILENABLE = 144, // TRUE to enable stenciling
        STENCILFAIL = 145, // D3DSTENCILOP to do if stencil test fails
        FRONTFACE = 146, // D3DFRONT (Xbox extension)
        CULLMODE = 147, // D3DCULL
        TEXTUREFACTOR = 148, // D3DCOLOR used for multi-texture blend
        ZBIAS = 149, // LONG Z bias
        LOGICOP = 150, // D3DLOGICOP (Xbox extension)
        EDGEANTIALIAS = 151, // TRUE to enable edge antialiasing (Xbox extension)
        MULTISAMPLEANTIALIAS = 152, // TRUE to enable multisample antialiasing
        MULTISAMPLEMASK = 153, // DWORD per-pixel and per-sample enable/disable
        MULTISAMPLEMODE = 154, // D3DMULTISAMPLEMODE for the backbuffer (Xbox extension)
        MULTISAMPLERENDERTARGETMODE = 155, // D3DMULTISAMPLEMODE for non-backbuffer render targets (Xbox extension)
        SHADOWFUNC = 156, // D3DCMPFUNC (Xbox extension)
        LINEWIDTH = 157, // float (Xbox extension)
        SAMPLEALPHA = 158, // D3DSAMPLEALPHA_TOCOVERAGE, etc. (Xbox extension)
        DXT1NOISEENABLE = 159, // TRUE to enable DXT1 decompression noise (Xbox extension)
        YUVENABLE = 160, // TRUE to enable use of D3DFMT_YUY2 and D3DFMT_UYVY texture formats (Xbox extension)
        OCCLUSIONCULLENABLE = 161, // TRUE to enable Z occlusion culling (Xbox extension)
        STENCILCULLENABLE = 162, // TRUE to enable stencil culling (Xbox extension)
        ROPZCMPALWAYSREAD = 163, // TRUE to always read target packet when Z enabled (Xbox extension)
        ROPZREAD = 164, // TRUE to always read Z (Xbox extension)
        DONOTCULLUNCOMPRESSED = 165,
        // TRUE to never attempt occlusion culling (stencil or Z) on uncompressed packets (Xbox extension)

        MAX = 166, // Total number of renderstates

        // Render states that are not supported on Xbox:
        //
        // LINEPATTERN
        // LASTPIXEL
        // CLIPPING
        // FOGVERTEXMODE
        // CLIPPLANEENABLE
        // SOFTWAREVERTEXPROCESSING
        // DEBUGMONITORTOKEN
        // INDEXEDVERTEXBLENDENABLE
        // TWEENFACTOR

        FORCE_DWORD = 0x7fffffff /* force 32-bit size enum */
    };
    
    public enum D3DBLEND
    {
        ZERO = 0,
        ONE = 1,
        SRCCOLOR = 0x300,
        INVSRCCOLOR = 0x301,
        SRCALPHA = 0x302,
        INVSRCALPHA = 0x303,
        DESTALPHA = 0x304,
        INVDESTALPHA = 0x305,
        DESTCOLOR = 0x306,
        INVDESTCOLOR = 0x307,
        SRCALPHASAT = 0x308,
        CONSTANTCOLOR = 0x8001,
        INVCONSTANTCOLOR = 0x8002,
        CONSTANTALPHA = 0x8003,
        INVCONSTANTALPHA = 0x8004,

        // D3DBLEND_BOTHSRCALPHA not supported on Xbox
        // D3DBLEND_BOTHINVSRCALPHA not supported on Xbox
    };

    public enum D3DCMPFUNC
    {
        NEVER = 0x200,
        LESS = 0x201,
        EQUAL = 0x202,
        LESSEQUAL = 0x203,
        GREATER = 0x204,
        NOTEQUAL = 0x205,
        GREATEREQUAL = 0x206,
        ALWAYS = 0x207,
        FORCE_DWORD = 0x7fffffff, /* force 32-bit size enum */
    };
    
    enum D3DBLENDOP
    {
        ADD = 0x8006,
        SUBTRACT = 0x800a,
        REVSUBTRACT = 0x800b,
        MIN = 0x8007,
        MAX = 0x8008,
        ADDSIGNED = 0xf006, // Xbox extension
        REVSUBTRACTSIGNED = 0xf005, // Xbox extension
        FORCE_DWORD = 0x7fffffff, /* force 32-bit size enum */
    };
}