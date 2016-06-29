using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace exPanda.Extentions
{
    public static class DictionaryExt
    {
        public static List<SqlParameter> ToSqlParameters(this Dictionary<string, object> source)
        {
            return source?.Select(item => new SqlParameter(item.Key, item.Value)).ToList() ?? new List<SqlParameter>();
        }
    }
}
