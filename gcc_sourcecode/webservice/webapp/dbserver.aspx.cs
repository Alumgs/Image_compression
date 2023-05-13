using DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class dbserver : JSONPageBase
{
    public class ReadSQL
    {
        public static List<int> GetTable(int column)
        {
            string myConnection = "Data Source = LAPTOP-SO5BK3FN; Initial Catalog = 老人体征信息管理系统; User ID = sa; Password = 123456789";
            SqlConnection conn = new SqlConnection(myConnection);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from 爷爷信息";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            conn.Close();
            conn.Dispose();
            comm.Dispose();
            List <int>seq = new List<int>();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int j = column;
                //for (int j = column; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "  ");
                    seq.Add(ConvertUtility.ConvertInt(dt.Rows[i][j]));

                }
                Console.WriteLine();
            }
            return seq;
            //Console.ReadLine();
        }
    }   


    public dbserver()
    {
        isCheck = false;
    }
    public override Object GetResponseObj()
    {
        string function = GetStringPara("f");
        string action = GetStringPara("a");
        if (function == "query")
        {
            if (action == "heartbeat")
            {
                string p1 = GetStringPara("p1");
                MiniResponse res = new MiniResponse();
                List<float> values = new List<float>();
                //for (int i = 0; i < 31; i++)
                //   values.Add(i + 1);
                //values.Add(ReadSQL.GetTable(1));

                res.data = ReadSQL.GetTable(1);
                return res;
            }

            if (action == "bloodpressure")
            {
                string p1 = GetStringPara("p1");
                MiniResponse res = new MiniResponse();
                List<int> values = new List<int>();
                //values= DBOperation.ExecuteSelect();
                //for (int i = 0; i < 31; i++)
                //values.add(i + 2);

                res.data = ReadSQL.GetTable(2); ;
                return res;
            }

            if (action == "temperature")
            {
                string p1 = GetStringPara("p1");
                MiniResponse res = new MiniResponse();
                res.data = ReadSQL.GetTable(3); ;
                return res;
            }

            if (action == "glucose")
            {
                string p1 = GetStringPara("p1");
                MiniResponse res = new MiniResponse();
                res.data = ReadSQL.GetTable(4); ;
                return res;

            }
        }
        else if (function == "login")
        {
            if (action == "check")
            {
                string username = GetStringPara("p1");
                string password = GetStringPara("p2");
                MiniResponse res = DBUtility.CheckMobileUser(username, password);
                return res;
            }
        }
        else if (function == "chart")
        {
            if (action == "trend")
            {
                return DBUtility.GetProductionConsume(GetStringPara("p1"), GetStringPara("p2"), GetStringPara("p3"));
            }
            else if (action == "pie")
            {
                return DBUtility.GetSummaryPie(GetStringPara("p1"), GetStringPara("p2"));
            }
        }
        return null;
    }
}