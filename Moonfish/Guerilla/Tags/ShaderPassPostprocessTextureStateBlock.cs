namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPassPostprocessTextureStateBlock
    {
        /// <summary>
        /// Creates a <see cref="ShaderPassPostprocessTextureStateBlock"/> with the default values.
        /// </summary>
        public static ShaderPassPostprocessTextureStateBlock Default => new ShaderPassPostprocessTextureStateBlock
        {
            fieldskip = new byte[]
            {
                0x32, 0x24, 0x40, 0x00, 0x01, 0x01, 0x01, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            }
        };
    };
}
