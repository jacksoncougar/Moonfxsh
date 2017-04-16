using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     Container of an atomic draw element ( ie; smallest sortable draw I want to deal with :} )
    ///     This should be processed more to create batches
    /// </summary>
    public class PatchData
    {
        public PatchData( GlobalGeometryPartBlockNew part, InstanceData data )
        {
            Part = part;
            Data = data;
        }


        public InstanceData Data { get; }
        public GlobalGeometryPartBlockNew Part { get; }
    }
}