using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace Application.Services
{
    public static class DataHelper
    {
        public static T Read<T>(object from) where T : class, new()
        {
            var to = new T();
            if (from != null)
            {
                var tFrom = from.GetType();
                var tTo = to.GetType();

                PropertyInfo[] propsFrom = tFrom.GetProperties();
                PropertyInfo[] propsTo = tTo.GetProperties();
                foreach (PropertyInfo prpTo in propsTo)
                {
                    var find = propsFrom.Where(x => x.Name.ToLower() == prpTo.Name.ToLower() &&
                                               x.GetType() == prpTo.GetType());
                    if (find.Any() && prpTo.CanWrite)
                    {
                        var value = find.First().GetValue(from, null);
                        if (!IsList(value))
                        {
                            prpTo.SetValue(to, value);
                        }

                    }
                }
            }
            return to;
        }

        public static List<T> List<T>(IEnumerable<object> listFrom) where T : class, new()
        {
            var listTo = new List<T>();
            foreach (var itemFrom in listFrom)
            {
                var itemTo = Read<T>(itemFrom);
                listTo.Add(itemTo);
            }

            return listTo;
        }

        private static bool IsList(object o)
        {
            if (o == null)
            {
                return false;
            }
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }
    }
}

