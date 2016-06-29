using System;
using System.Collections.Generic;
using System.Data;

namespace exPanda.Extentions
{
    public static class DbDataReaderExt
    {
        public static List<T> MapTo<T>(this IDataReader dr)
        {
            var list = new List<T>();
            while (dr.Read())
            {
                var obj = Activator.CreateInstance<T>();
                try
                {
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (!Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name]);
                        }
                    }
                    list.Add(obj);

                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return list;
        }

        }
    }

