namespace Moonfish.Graphics
{
    /// <summary>
    /// Used to select between different level of detail meshes
    /// </summary>
    public enum DetailLevel
    {
        /// <summary>
        /// Programmatic Value (Level0 + X)
        /// </summary>
        Level0 = 0,

        /// <summary>
        /// Lowest 
        /// </summary>
        Level1 = 1,

        /// <summary>
        /// Lower
        /// </summary>
        Level2 = 2,

        /// <summary>
        /// Medium
        /// </summary>
        Level3 = 3,

        /// <summary>
        /// High
        /// </summary>
        Level4 = 4,
        /// <summary>
        /// Higher
        /// </summary>
        Level5 = 5,

        /// <summary>
        /// Highest 
        /// </summary>
        Level6 = 6,

        /// <summary>
        /// Cinematic (Highest)
        /// </summary>
        Cinematic = 6,
    }
}