namespace Moonfish.Guerilla
{
    /// <summary>
    /// Exposes the implementing class as supporting writing with <see cref="LinearBinaryWriter"/>.
    /// </summary>
    public interface IWriteDeferrable
    {
        /// <summary>
        /// Defers writing the reference data of this object using the given <param name="blamBinaryWriter">writer</param>.
        /// </summary>
        void DeferReferences(LinearBinaryWriter blamBinaryWriter);
    }
}