/*using System;

public class Class1
{
	public Class1()
	{
         static DataTable GetTable()
        {
            string connstring = "server=127.0.0.1\\SQLEXPRESS;database=数据库名;uid=用户名;pwd=密码";//连接串，连接你的数据库
            SqlConnection conn = new SqlConnection(connstring);
            string sql = "select * from Users";//查询SQL，根据你的表来写
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);//执行查询并加载数据到DataTable中
            conn.Close();
            cmd.Dispose();
            return dt;
        }

        //vs自带的sql文件也可做数据库是Express版本

        dataGridView1.DataSourse = dt;

         static DataTable GetDataTableBLL()
        {
            string sql = "select * from table";
            DataTable dt = new DataTable();
            dt = GetDataTable(sql);
            return dt;
        }
    }
}*/

using System;
using System.Data;
using System.Data.SqlClient;

namespace MyDbTest
{
    class Program
    {
        static void Main(string[] args)
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
