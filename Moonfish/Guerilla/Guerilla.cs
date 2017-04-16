using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;


namespace Moonfish.Guerilla
{
    public partial class Guerilla
    {
        public static IEnumerable<MoonfishTagField> PostProcess(string name, IList<MoonfishTagField> fields)
        {
            var preProcess =
                preProcessFieldsFunctions.Where(x => x.Key == name).Select(x => x.Value).FirstOrDefault();
            return preProcess != null ? preProcess(fields) : fields;
        }
    }
}