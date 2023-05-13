using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class DBUtility
    {
        public static MiniResponse CheckMobileUser(string username, string password)
        {
            MiniResponse mr = new MiniResponse();
            MobileUserInfo uinfo = new MobileUserInfo(0, 0, "");
            //首先检查是否为合法用户
            MySqlParameter[] paras = new MySqlParameter[2];
            paras[0] = new MySqlParameter("l_username", MySqlDbType.VarChar, 32, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Default, username);
            paras[1] = new MySqlParameter("l_password", MySqlDbType.VarChar, 32, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Default, password);
            DataSet sdr = DBOperation.ExecuteSelectByStoreProc("CheckMobileUser", paras);
            if(sdr.Tables[0].Rows.Count>0)
            {
                DataRow mDr = sdr.Tables[0].Rows[0];
                int pkid = ConvertUtility.ConvertInt(mDr["pkid"]);
                if(pkid>0){
                    uinfo.usertype = 1;
                    uinfo.userid =pkid;
                    uinfo.realname = ConvertUtility.ConvertString(mDr["username"]);
                    mr.data = uinfo;
                }
            }         
            return mr;
        }
        public static MiniResponse GetProductionConsume(string p1,string p2,string p3)
        {
            MiniResponse mr = new MiniResponse();
            Mini_ChartData pcdata = new Mini_ChartData();
            pcdata.serial1name = "电";
            pcdata.unit = "千瓦时";
            pcdata.unitname = "千瓦时";
            
            pcdata.xlabel.Add("10-16");
            pcdata.serial1.Add(100);
            pcdata.xlabel.Add("10-17");
            pcdata.serial1.Add(300);
            pcdata.xlabel.Add("10-18");
            pcdata.serial1.Add(200);
            mr.data = pcdata;
            return mr;
        }
        public static MiniResponse GetSummaryPie(string p1, string p2)
        {
            MiniResponse mr = new MiniResponse();
            Mini_ChartData pcdata = new Mini_ChartData();
            
            pcdata.pieTotal += 10;
            pcdata.pieserial.Add(new Mini_ChartData.PieData("水", 10));
            pcdata.unit = "立方米";

            pcdata.pieTotal += 20;
            pcdata.pieserial.Add(new Mini_ChartData.PieData("电", 20));
            pcdata.unit = "千瓦时";

            pcdata.pieTotal += 15;
            pcdata.pieserial.Add(new Mini_ChartData.PieData("燃气", 15));
            pcdata.unit = "立方米";

            mr.data = pcdata;
            return mr;
        }
    }
}
