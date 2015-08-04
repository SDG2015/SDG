using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGD.Entities;
namespace SDG.Dao
{
    public class SqlHelper
    {
        public List<TableInfo> GetSchemaInfo(String connString)
        {
            List<TableInfo> tables = new List<TableInfo>();
            List<ColumnInfo> columns = new List<ColumnInfo>();
            TableInfo tableTmp = new TableInfo();
            ColumnInfo columnTmp = new ColumnInfo();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_TYPE, TABLE_SCHEMA, TABLE_NAME", conn);
                SqlDataReader reader = command.ExecuteReader();

                String tableName;
                while (reader.Read())
                {
                    tableName = "";
                    tableTmp = new TableInfo();
                    columns = new List<ColumnInfo>();
                    tableTmp.TableSchema = (String)reader[0];
                    tableName = (String)reader[1];
                    tableTmp.TableName = tableName;
                    tableTmp.TableType = (String)reader[2];
                    command.Dispose();
                    command = new SqlCommand("SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName", conn);
                    command.Parameters.AddWithValue("@tableName", tableName);
                    SqlDataReader readerColumns = command.ExecuteReader();

                    while (readerColumns.Read())
                    {
                        columnTmp = new ColumnInfo();
                        columnTmp.ColumnName = (String)readerColumns[0];
                        columnTmp.DataType = (String)readerColumns[1];
                        if (readerColumns[2].ToString() == "YES")
                        {
                            columnTmp.IsNullable = true;
                        }
                        else
                        {
                            columnTmp.IsNullable = false;
                        }

                        columnTmp.ColumnDefault = readerColumns[3].ToString();
                        columns.Add(columnTmp);
                    }

                    tableTmp.Columns = columns;
                    tables.Add(tableTmp);
                }


                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tables;
        }
    }
}
