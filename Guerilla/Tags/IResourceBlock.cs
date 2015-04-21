namespace Moonfish.Guerilla.Tags
{
    public interface IResourceBlock
    {
        void LoadRawResources( );
        byte[] GetRawResourceBytes( );
    }
}