using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System;
using Excel;
using System.IO;

namespace Excel2Mysql.util
{
    public class Excel
    {
        public static readonly Excel Instance = new Excel();

        public DataSet Load(string filePath, out string mysqlError)
        {
            mysqlError = "";

            DataSet result = null;

            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                excelReader.IsFirstRowAsColumnNames = false;
                result = excelReader.AsDataSet();

                excelReader.Close();
            }
            catch (IOException e)
            {
                mysqlError = e.Message;
            }

            return result;
            
            /*

            string fileExt = System.IO.Path.GetExtension(filePath).ToLower();
            string connStr;

            if (fileExt == ".xls" )
            {
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            }
            else
            {
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml; HDR=NO; IMEX=1'";
            }

            string query = "SELECT * FROM [{0}]";
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                conn.Open();

                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    string sheetName = (string)dtSheetName.Rows[i]["TABLE_NAME"];

                    if (sheetName.Contains("$") && !sheetName.Replace("'", "").EndsWith("$"))
                    {
                        continue;
                    }
                    
                    da.SelectCommand = new OleDbCommand(string.Format(query, sheetName), conn);

                    if (sheetName == "Sheet1$")
                    {
                        sheetName = "data$";
                    }

                    da.Fill(ds, sheetName);
                }

            }
            catch(Exception err)
            {
                mysqlError = err.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    da.Dispose();
                    conn.Dispose();
                }
            }

            return ds;

            */
        }
    }
}
