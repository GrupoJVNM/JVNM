using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class SelectAll : MiniSQLQuery
    {
        public String table = null;
        public DataComparator compare;
        public TableColumn condiC = null;
        public String value = null;

        public SelectAll(String table, DataComparator compare, TableColumn condiC, String value)
        {
            this.table = table;
            this.compare = compare;
            this.condiC = condiC;
            this.value = value;
        }
        public void Execute(Database database)
        {
            database.SelectAll(table, compare, condiC, value);
        }
    }
}
}
