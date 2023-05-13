using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBAccess
{
    public class DBOperation
    {
        public static string ConfigDBstr =
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConfigDBConnection"].ToString();

        private static string GetDBStr(){
            return ConfigDBstr;
        }
        //执行insert into 语句
        public static int ExecuteInsert(String insertSql)
        {
            try
            {
                return SqlOperator.ExecuteNonQuery(GetDBStr(), CommandType.Text, insertSql, null);
            }
            catch{            
                return -1;
            }
        }
        //执行select语句
        public static MySqlDataReader ExecuteSelect(String selectSql)
        {
            return SqlOperator.ExecuteReader(GetDBStr(), CommandType.Text, selectSql, null);
        }
        public static DataSet ExecuteSelectForDataSet(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(GetDBStr()))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        //执行存储过程select语句
        public static DataSet ExecuteSelectByStoreProc(string spname, MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(GetDBStr()))
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommandForSP(cmd, connection, spname, cmdParms);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        private static void PrepareCommandForSP(MySqlCommand cmd, MySqlConnection conn, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        //执行存储过程更新
        public static bool UpdateByStoreProc(int DBType, string spname, Hashtable args)
        {
            try
            {
                return SqlOperator.UpdateByStoreProc(GetDBStr(), spname, args) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
