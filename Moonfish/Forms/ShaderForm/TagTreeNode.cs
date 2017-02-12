using System.Windows.Forms;

namespace Moonfish.Forms.ShaderForm
{
    public class TagTreeNode :TreeNode
    {
        public TagDatum Info { get; }

        public TagTreeNode(TagDatum tag )
        {
            Text = tag.Path;
            Info = tag;
        }
    }
}
