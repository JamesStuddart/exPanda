using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace exPanda.Extentions
{
    public static class StringExt
    {
        public static string ToMD5Hash(this string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var item in hash)
            {
                sb.Append(item.ToString("X2"));
            }
            return sb.ToString();
        }

        public static string CamelCaseToHumanReadable(this string camelCase, bool? toUpper = null)
        {
            var regEx = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return toUpper == null ? regEx.Replace(camelCase, " ") : toUpper.Value ? regEx.Replace(camelCase, " ").ToUpper() : regEx.Replace(camelCase, " ").ToLower();
        }

        public static bool IsNumeric(this string value)
        {
            return new Regex(@"^\d+$").Match(value).Success;
        }

        /// <summary>
        /// Convert string to proper case
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string value)
        {
            try
            {
                //Convert to lower as ToTitleCase doesnt work on uppercase
                return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
            catch
            { return value; }
        }

        public static string RemoveAccent(this string value)
        {
            return Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(value));
        }

        public static string ToUrlFormat(this string value)
        {
            var str = value.RemoveAccent().ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); //Remove all non valid chars          
            str = Regex.Replace(str, @"\s+", " ").Trim(); //Convert multiple spaces into one space  
            str = Regex.Replace(str, @"\s", "-"); //Replace spaces by dashes
            return str;
        }

        public static T ToType<T>(this string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static string Concatenate(this string[] values, string separator)
        {
            var output = new StringBuilder();
            if (values != null)
            {
                foreach (var s in values.Where(s => !string.IsNullOrEmpty(s)))
                {
                    if (output.Length > 0)
                        output.Append(separator ?? string.Empty);
                    output.Append(s.Trim());
                }
            }
            return output.ToString();
        }

        public static SecureString ToSecureString(this string value)
        {


            var secure = new SecureString();
            foreach (var c in value)
            {
                secure.AppendChar(c);
            }
            return secure;
        }
    }
}
