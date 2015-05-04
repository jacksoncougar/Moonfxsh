using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelBlock
    {
        public RenderModelBlock RenderModel
        {
            get { return Halo2.GetReferenceObject(this.renderModel); }
        }
    }

    public partial class ModelVariantObjectBlock
    {
        public object ChildObject
        {
            get { return Halo2.GetReferenceObject(this.childObject); }
        }
    }
}