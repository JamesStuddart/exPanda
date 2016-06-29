using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;


namespace exPanda.Extentions
{
    public static class CollectionsExt
    {
        public static DataTable ToDataTable<T>(this ICollection<T> collection)
        {
            var table = CreateTable<T>();
            var entityType = typeof(T);
            var properties = TypeDescriptor.GetProperties(entityType);

            foreach (var item in collection)
            {
                var row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private static DataTable CreateTable<T>()
        {
            var entityType = typeof(T);
            var table = new DataTable(entityType.Name);
            var properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
                    prop.PropertyType) ?? prop.PropertyType);
            }
            return table;
        }
    }
}
