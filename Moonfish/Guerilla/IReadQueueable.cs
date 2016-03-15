namespace Moonfish.Guerilla
{
    public interface IReadQueueable
    {
        void QueueReads(QueueableBinaryReader binaryReader);
    }
}