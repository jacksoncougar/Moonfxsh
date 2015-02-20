using Moonfish.Graphics;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Tags
{
    [TagClass( "hlmt" )]
    public partial class ModelBlock
    {
        public RenderModelBlock RenderModel
        {
            get { return Halo2.GetReferenceObject( this.renderModel ); }
        }
    }

    public partial class ModelVariantObjectBlock
    {
        public object ChildObject { get { return Halo2.GetReferenceObject( this.childObject ); } }
    }
}
