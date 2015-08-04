using SDG.Dao;
using SGD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlHelper helper = new SqlHelper();
            List<TableInfo> infos = helper.GetSchemaInfo("Data Source=.\\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True;Asynchronous Processing=true;MultipleActiveResultSets=true");
            foreach(TableInfo tableInfo in infos)
            {
                foreach(ColumnInfo columnInfo in tableInfo.Columns)
                {
                    Console.WriteLine(columnInfo.DataType); 
                }
            }
            Console.ReadKey();
        }
    }
}
