namespace Moonfish.Guerilla.Reflection
{
    public class GuerillaName
    {
        public string Name
        {
            get { return GuerillaCs.SplitNameDescription( Value )[ 0 ]; }
            set
            {
                if ( HasName )
                    Value = Value.Replace( GuerillaCs.SplitNameDescription( Value )[ 0 ], value );
                else
                    Value = Value.Insert( 0, value );
            }
        }

        public string Description
        {
            get { return GuerillaCs.SplitNameDescription( Value )[ 1 ]; }
            set
            {
                if ( HasDescription )
                    Value = Value.Replace( GuerillaCs.SplitNameDescription( Value )[ 1 ], value );
                else
                    Value = Value.Insert( Name.Length, "#" + value );
            }
        }

        public bool HasName
        {
            get { return !string.IsNullOrEmpty( Name ); }
        }

        public bool HasDescription
        {
            get { return !string.IsNullOrEmpty( Description ); }
        }

        private string Value;

        public GuerillaName( string value )
        {
            Value = value;
        }

        public static implicit operator GuerillaName( string value )
        {
            return new GuerillaName( value );
        }

        public static implicit operator string( GuerillaName guerillaName )
        {
            return guerillaName.Value;
        }
    }
}