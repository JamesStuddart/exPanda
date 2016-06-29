using System;
using System.ComponentModel;
using System.Linq;

namespace exPanda.Extentions
{
    public static class ClassExt
    {
        /// <summary>
        /// Light weight mapper, this will not map child objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="strict"></param>
        /// <returns></returns>
        public static T MapTo<T>(this object source, bool strict = true) where T : new()
        {
            var destination = new T();
            var sourceProperties = source.GetType().GetProperties();
            var destionationProperties = destination.GetType().GetProperties();

            var commonproperties = strict ? (from x in sourceProperties
                                             join y in destionationProperties on new { x.Name, x.PropertyType } equals
                                                 new { y.Name, y.PropertyType }
                                             select new { x, y }) : (from x in sourceProperties
                                                                     join y in destionationProperties on new { Name = x.Name.ToLower() } equals
                                                                         new { Name = y.Name.ToLower() }
                                                                     select new { x, y });
            foreach (var match in commonproperties)
            {
                try
                {
                   
                        match.y.SetValue(destination, match.x.GetValue(source, null), null);
                }
                catch
                {
                    //match did work, due to different types, we'll just ignore them  for now
                    //TODO: this needs fixing
                }
            }
            return destination;
        }

        public static string GetDescription(this Type type)
        {
            var descriptions = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptions.Length == 0 ? null : descriptions[0].Description;
        }
    }
}
