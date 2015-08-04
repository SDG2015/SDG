using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGD.Entities
{
    public class ColumnInfo
    {
        public String ColumnName { get; set; }
        public String DataType { get; set; }
        public bool IsNullable { get; set; }
        public String ColumnDefault { get; set; }
    }
}
