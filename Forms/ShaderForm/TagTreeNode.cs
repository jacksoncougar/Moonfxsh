using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fasterflect;

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
