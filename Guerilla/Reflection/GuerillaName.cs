namespace Moonfish.Guerilla.Reflection
{
    public class GuerillaName
    {
        private string _description;
        private string _name;
        private string _range;

        public GuerillaName(string value)
        {
            var hasDescription = value.Contains("#");
            var hasRange = value.Contains(":");
            var hasStar = value.Contains("*");

            var tokens = value.Split('#', ':');

            Name = tokens[0];
            if (hasRange)
            {
                Range = tokens[1];
                if (hasDescription) Description = tokens[2];
            }
            else if (hasDescription) Description = tokens[1];
        }

        public string Name { get; set; }
        public string Range { get; set; }
        public string Description { get; set; }

        public bool HasName
        {
            get { return !string.IsNullOrEmpty(Name); }
        }

        public bool HasDescription
        {
            get { return !string.IsNullOrEmpty(Description); }
        }

        public bool HasRange
        {
            get { return !string.IsNullOrEmpty(Range); }
        }

        public static implicit operator GuerillaName(string value)
        {
            return new GuerillaName(value);
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}",
                HasName ? Name : "",
                HasRange ? Description : "",
                HasDescription ? Description : "");
        }

        public static implicit operator string(GuerillaName guerillaName)
        {
            return guerillaName.ToString();
        }
    }
}