using System.Text;

namespace Moonfish.Tags
{
    internal class TagReferenceAttribute : TagFieldAttribute
    {
        private TagClass referenceClass;

        public TagReferenceAttribute( string tagClassString )
        {
            referenceClass = new TagClass( Encoding.UTF8.GetBytes( tagClassString ) );
        }
    }
}