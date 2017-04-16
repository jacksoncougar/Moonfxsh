namespace Moonfish.Guerilla
{
    /// <summary>
    /// Exposes the implementing class as supporting writing with <see cref="QueueableBinaryWriter"/>.
    /// </summary>
    public interface IWriteQueueable
    {
        void QueueWrites(QueueableBinaryWriter binaryWriter);
    }
}