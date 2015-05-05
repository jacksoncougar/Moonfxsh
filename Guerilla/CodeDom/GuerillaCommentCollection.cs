using System;
using System.Collections.Generic;

namespace Moonfish.Guerilla.CodeDom
{
    internal class GuerillaCommentCollection
    {
        private readonly string[] _itemDescriptions;

        public IEnumerable<string> Descriptions
        {
            get { return _itemDescriptions; }
        }

        public string Summary { get; private set; }
            
        public bool HasDescriptions
        {
            get { return _itemDescriptions.Length > 0; }
        }

        public bool HasSummary
        {
            get { return !string.IsNullOrWhiteSpace(Summary); }
        }

        public GuerillaCommentCollection()
        {
            Summary = "";
            _itemDescriptions = new string[0];
        }

        public GuerillaCommentCollection CreateCopy()
        {
            return new GuerillaCommentCollection(Summary, _itemDescriptions);
        }

        private GuerillaCommentCollection(string summary, string[] itemDescriptionses)
        {
            Summary = summary;
            _itemDescriptions = itemDescriptionses;
        }

        public GuerillaCommentCollection(string value)
        {
            var lines = value.Split('*');
            Summary = lines[0];
            _itemDescriptions = new string[lines.Length - 1];
            for (int u = 0, v = 1; u < lines.Length - 1; ++u, ++v)
            {
                _itemDescriptions[u] = lines[v];
            }
        }
    };
}