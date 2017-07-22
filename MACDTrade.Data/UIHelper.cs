namespace MACDTrade.Data
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    class UIHelper
    {
        #region From DataTable

        public static List<T> ConvertToObjList<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            T obj = Activator.CreateInstance<T>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!object.Equals(item[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, item[prop.Name], null);
                        }
                    }
                    list.Add(obj);
                }
            }
            return list;
        }

        public static T ConvertToObj<T>(DataTable dt)
        {
            T obj = default(T);
            if (dt != null && dt.Rows.Count == 1)
            {
                obj = Activator.CreateInstance<T>();
                var dr = dt.Rows[0];
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
            }
            return obj;
        }

        #endregion

        #region From DataReader

        public static List<T> ConvertToObjList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static T ConvertToObj<T>(IDataReader dr)
        {
            T obj = default(T);
            var dt = dr.Read();
            if (dt)
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
            }
            return obj;
        }

        #endregion
    }
}
