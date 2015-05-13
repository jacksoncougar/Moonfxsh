namespace Moonfish.Guerilla
{
    public interface IWriteQueueable
    {
        void QueueWrites(QueueableBinaryWriter binaryWriter);
    }
}