using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class SelectAll : MiniSQLQuery
    {
        public String Table = null;
        public DataComparator Compare;
        public TableColumn CondiC = null;
        public String Value = null;

        public SelectAll(String table, DataComparator compare, TableColumn condiC, String value)
        {
            Table = table;
            Compare = compare;
            CondiC = condiC;
            Value = value;
        }
        public void Execute(Database database)
        {
            database.SelectAll(Table, Compare, CondiC, Value);
        }
    }
}

