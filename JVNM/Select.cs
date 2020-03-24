using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class Select : MiniSQLQuery
    {
        public String table = null;
        public List<String> selectedC = null;
        public DataComparator compare;
        public TableColumn condiC = null;
        public String value = null;


        public Select(String table, List<String> selectedC, DataComparator compare, TableColumn condiC, String value)
        {
            this.table = table;
            this.selectedC = selectedC;
            this.compare = compare;
            this.condiC = condiC;
            this.value = value;
        }
        public void Execute(Database database)
        {
           database.Select(table, selectedC, compare, condiC, value);
        }
    }
}
}
