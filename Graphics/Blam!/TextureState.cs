namespace Moonfish.Forms
{
    class TextureState
    {
        private AddressMode Unknown;
        private AddressMode Unknown1;
        private AddressMode minFilterMode;
        private AddressMode maxFilterMode;

        private AddressMode UAddressMode;
        private AddressMode VAddressMode;
        private AddressMode WAddressMode;

        enum AddressMode : byte
        {
            Undefined = 0,
            /// <summary>
            /// Tile the texture at every integer junction. 
            /// For example, for u values between 0 and 3, the texture is repeated three times; no mirroring is performed.
            /// </summary>
            Wrap = 1,
            /// <summary>
            /// Similar to WRAP, except that the texture is flipped at every integer junction. 
            /// For u values between 0 and 1, for example, the texture is addressed normally; between 1 and 2, the texture is flipped 
            /// (mirrored); between 2 and 3, the texture is normal again; and so on.
            /// </summary>
            Mirrored = 2,
            /// <summary>
            /// Texture coordinates outside the range [0.0, 1.0] are set to the texture color at 0.0 or 1.0, respectively.
            /// </summary>
            Clamp = 3,
            /// <summary>
            /// Texture coordinates outside the range [0.0, 1.0] are set to the border color.
            /// </summary>
            Border = 4,
            /// <summary>
            /// Similar to D3DTADDRESS_MIRROR and D3DTADDRESS_CLAMP. 
            /// Takes the absolute value of the texture coordinate (thus, mirroring around 0), and then clamps to the maximum value. 
            /// The most common usage is for volume textures, where support for the full D3DTADDRESS_MIRRORONCE texture-addressing mode 
            /// is not necessary, but the data is symmetric around the one axis.
            /// </summary>
            MirrorOnce = 5,
        }

        enum FilterType
        {
            /// <summary>
            /// When used with D3DSAMP_ MAGFILTER or D3DSAMP_MINFILTER, specifies that point filtering is to be used as 
            /// the texture magnification or minification filter respectively. When used with D3DSAMP_MIPFILTER, 
            /// enables mipmapping and specifies that the rasterizer chooses the color from the texel of the nearest mip level.
            /// </summary>
            Point = 1,
            /// <summary>
            /// When used with D3DSAMP_ MAGFILTER or D3DSAMP_MINFILTER, specifies that linear filtering is to be used as 
            /// the texture magnification or minification filter respectively. When used with D3DSAMP_MIPFILTER, enables 
            /// mipmapping and trilinear filtering; it specifies that the rasterizer interpolates between the two nearest mip levels.
            /// </summary>
            Linear = 2,
            /// <summary>
            /// When used with D3DSAMP_ MAGFILTER or D3DSAMP_MINFILTER, specifies that anisotropic texture filtering used as 
            /// a texture magnification or minification filter respectively. Compensates for distortion caused by the difference 
            /// in angle between the texture polygon and the plane of the screen. Use with D3DSAMP_MIPFILTER is undefined.
            /// </summary>
            Anisotropic = 3,
            /// <summary>
            /// A 4-sample tent filter used as a texture magnification or minification filter. Use with D3DSAMP_MIPFILTER is undefined.
            /// </summary>
            Pyramidal = 4,
            /// <summary>
            /// A 4-sample Gaussian filter used as a texture magnification or minification filter. Use with D3DSAMP_MIPFILTER is undefined.
            /// </summary>
            Guassian = 5,
        }
    }
}