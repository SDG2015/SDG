using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGD.Entities
{
    public class TableInfo
    {
        public String TableSchema { get; set; }
        public String TableName { get; set; }
        public String TableType { get; set; }
        public List<ColumnInfo> Columns { get; set; }
        public TableInfo()
        {

        }

    }
}
