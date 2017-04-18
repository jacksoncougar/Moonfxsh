namespace Moonfish.Guerilla
{
    /// <summary>
    /// Exposes the implementing class as supporting writing with <see cref="QueueableBlamBinaryWriter"/>.
    /// </summary>
    public interface IWriteQueueable
    {
        void QueueWrites(QueueableBlamBinaryWriter blamBinaryWriter);
    }
}