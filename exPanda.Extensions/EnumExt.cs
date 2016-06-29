using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace exPanda.Extentions
{
    public static class EnumExt
    {
        public static string GetDescription<TEnum>(this TEnum item)
        {
            var descriptions = (DescriptionAttribute[])item.GetType().GetField(item.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptions.Length == 0 ? null : descriptions[0].Description;
        }

        public static string CamelCaseToHumanReadable(this Enum item, bool? toUpper = null)
        {
            var camelCase = item.ToString();
            var regEx = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return toUpper == null ? regEx.Replace(camelCase, " ") : toUpper.Value ? regEx.Replace(camelCase, " ").ToUpper() : regEx.Replace(camelCase, " ").ToLower();
        }
    }
}
