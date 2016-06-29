using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace exPanda.Web
{
    public  static class HtmlExt
    {
        public static HtmlString ToHtmlTable(this DbDataReader reader)
        {
            var dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable.ToHtmlTable();
        }

        public static HtmlString ToHtmlTable(this DataTable dt)
        {
            var builder = new StringBuilder();

            builder.AppendLine("<table>");
            builder.AppendLine("<thead>");
            builder.AppendLine("<tr>");
            for (var i = 0; i < dt.Columns.Count; i++)
                builder.AppendLine("<th>" + dt.Columns[i].ColumnName + "</th>");
            builder.AppendLine("</tr>");
            builder.AppendLine("</thead>");

            builder.AppendLine("<tbody>");
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                builder.AppendLine("<tr>");
                for (var j = 0; j < dt.Columns.Count; j++)
                    builder.AppendLine("<td>" + dt.Rows[i][j] + "</td>");
                builder.AppendLine("</tr>");
            }
            builder.AppendLine("</tbody>");
            builder.AppendLine("</table>");
            return new HtmlString(builder.ToString());
        }
    }
}
