using System.Windows.Forms;
using Moonfish.Tags;

namespace Moonfish.Forms.ShaderForm
{
    public class ClassTreeNode : TreeNode
    {
        public TagClass Class { get; }

        public ClassTreeNode(TagClass @class)
        {

            Text = @class.GetClassType().Name;
            Class = @class;
        }

    }
}