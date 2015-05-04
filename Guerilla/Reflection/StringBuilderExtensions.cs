using System.Text;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Reflection
{
    public static class StringBuilderExtensions
    {
        public static void AppendSummary(this StringBuilder stringBuilder, string value)
        {
            stringBuilder.AppendLine("/// <summary>");
            stringBuilder.AppendLine(string.Format("/// {0}", value));
            stringBuilder.AppendLine("/// </summary>");
        }

        [StringFormatMethod("value")]
        public static void AppendFormatLine(this StringBuilder stringBuilder, string value, object arg0)
        {
            stringBuilder.AppendFormat(value, arg0);
            stringBuilder.AppendLine();
        }

        [StringFormatMethod("value")]
        public static void AppendFormatLine(this StringBuilder stringBuilder, string value, object arg0, object arg1)
        {
            stringBuilder.AppendFormat(value, arg0, arg1);
            stringBuilder.AppendLine();
        }

        [StringFormatMethod("value")]
        public static void AppendFormatLine(this StringBuilder stringBuilder, string value, object arg0, object arg1,
            object arg2)
        {
            stringBuilder.AppendFormat(value, arg0, arg1, arg2);
            stringBuilder.AppendLine();
        }

        [StringFormatMethod("value")]
        public static void AppendFormatLine(this StringBuilder stringBuilder, string value, params object[] args)
        {
            stringBuilder.AppendFormat(value, args);
            stringBuilder.AppendLine();
        }
    }
}