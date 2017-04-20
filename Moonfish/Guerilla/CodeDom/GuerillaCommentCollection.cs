using System;
using System.Collections.Generic;

namespace Moonfish.Guerilla.CodeDom
{
    internal class GuerillaCommentCollection
    {
        private readonly string[] itemDescriptions;

        public IEnumerable<string> Descriptions
        {
            get { return itemDescriptions; }
        }

        public string Summary { get; private set; }
            
        public bool HasDescriptions
        {
            get { return itemDescriptions.Length > 0; }
        }

        public bool HasSummary
        {
            get { return !string.IsNullOrWhiteSpace(Summary); }
        }

        public GuerillaCommentCollection()
        {
            Summary = "";
            itemDescriptions = new string[0];
        }

        public GuerillaCommentCollection CreateCopy()
        {
            return new GuerillaCommentCollection(Summary, itemDescriptions);
        }

        private GuerillaCommentCollection(string summary, string[] itemDescriptionses)
        {
            Summary = summary;
            itemDescriptions = itemDescriptionses;
        }

        public GuerillaCommentCollection(string value)
        {
            var lines = value.Split(new[] {'*'}, StringSplitOptions.RemoveEmptyEntries);
            Summary = lines[0];
            itemDescriptions = new string[lines.Length - 1];
            for (int u = 0, v = 1; u < lines.Length - 1; ++u, ++v)
            {
                itemDescriptions[u] = lines[v];
            }
        }
    };
}