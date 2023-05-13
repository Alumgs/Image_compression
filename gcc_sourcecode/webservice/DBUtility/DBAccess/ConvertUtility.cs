using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class ConvertUtility
    {
        public static int ConvertInt(Object sourceobj)
        {            
            try
            {
                if (sourceobj != DBNull.Value)
                    return Convert.ToInt32(sourceobj);
            }
            catch
            {
            }
            return 0;
        }
        public static Double ConvertDouble(Object sourceobj)
        {
            try
            {
                if (sourceobj != DBNull.Value)
                    return Convert.ToDouble(sourceobj);
            }
            catch
            {
            }
            return 0.0;
        }
        public static String ConvertString(Object sourceobj)
        {
            try
            {
                if (sourceobj != DBNull.Value)
                    return sourceobj.ToString();
            }
            catch
            {
            }
            return "";
        }
        public static DateTime base_dateTime = Convert.ToDateTime("2000-01-01");
        public static DateTime ToDateTime(Object sourceobj)
        {
            try
            {
                if (sourceobj != DBNull.Value)
                    return Convert.ToDateTime(sourceobj);
            }
            catch
            {
            }

            return base_dateTime;
        }
    }
}
