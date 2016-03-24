using System.Data;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Excel2Mysql.util
{
    class Mysql
    {
        public static readonly Mysql Instance = new Mysql();
        private static string _configTableName = @"config2";

        private string createSql(DataSet execlDataSet, out string dbTableName)
        {
            dbTableName = "unknown";

            if (execlDataSet.Tables.Count < 2 || execlDataSet.Tables[_configTableName] == null)
            {
                return "";
            }

            DataTable configTbl = execlDataSet.Tables[_configTableName];
            dbTableName = configTbl.Rows[0][0].ToString();

            DataTable dataTbl;

            if (execlDataSet.Tables[@"data"] == null)
            {
                dataTbl = execlDataSet.Tables[@"Sheet1"];
            }
            else
            {
                dataTbl = execlDataSet.Tables[@"data"];
            }

            List<string> sqlKeys = new List<string>();
            List<int> sqlKeyIndexs = new List<int>();

            for(int i = 0; i < dataTbl.Columns.Count; i++)
            {
                string preName = dataTbl.Rows[0][i].ToString();

                for (int j = 0; j < configTbl.Rows.Count; j++ )
                {
                    string _preName = configTbl.Rows[j][0].ToString();

                    if (string.IsNullOrEmpty(_preName))
                    {
                        continue;
                    }

                    string sqlKeyName = configTbl.Rows[j][1].ToString();

                    if (string.IsNullOrEmpty(sqlKeyName))
                    {
                        continue;
                    }

                    if (preName == _preName)
                    {
                        sqlKeys.Add("`" + sqlKeyName + "`");
                        sqlKeyIndexs.Add(i);
                    }
                }
            }

            List<string> sqlItems = new List<string>();

            for (int i = 1; i < dataTbl.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dataTbl.Rows[i][0].ToString()))
                {
                    break;
                }

                List<string> sqlItem = new List<string>();

                for (int j = 0; j < sqlKeys.Count; j++)
                {
                    sqlItem.Add("'" + dataTbl.Rows[i][sqlKeyIndexs[j]].ToString().Replace("'", "''") + "'");
                }

                sqlItems.Add("(" + string.Join(",", sqlItem.ToArray()) + ")");
            }

            return "TRUNCATE TABLE `" + dbTableName + "`;\nINSERT INTO `" + dbTableName + "` (" + 
                string.Join(", ", sqlKeys) + ") VALUES " + string.Join(", ", sqlItems.ToArray()) + ";";
        }

        public void UploadExecl(entity.ServerConfig serverConfig, string filePath, out string errMsg)
        {
            string connStr = "Data Source=" + serverConfig.host + ";Port=" + serverConfig.port + ";User ID=" + serverConfig.user + ";Password=" + serverConfig.password + ";DataBase=" + serverConfig.database + ";Charset=" + serverConfig.charset + ";";

            errMsg = "";
            string mysqlError = "";
            DataSet excelDataSet = Excel.Instance.Load(filePath, out mysqlError);

            if (mysqlError != "")
            {
                errMsg = mysqlError;
                return;
            }
            
            string dbTableName;
            string query = this.createSql(excelDataSet, out dbTableName);

            if (dbTableName == "unknow" || query == "")
            {
                errMsg = System.IO.Path.GetFileName(filePath) + " - " + _configTableName + "配置错误！已自动去除勾选！";
                return;
            }

            MySqlConnection conn = new MySqlConnection();

            try
            {
                conn.ConnectionString = connStr;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("set names " + serverConfig.charset, conn);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch(Exception err)
            {
                errMsg = "上传Mysql失败！失败原因：" + err.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
