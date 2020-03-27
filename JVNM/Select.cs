using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class Select : MiniSQLQuery
    {
        public String Table = null;
        public List<String> SelectedC = null;
        public DataComparator Compare;
        public TableColumn CondiC = null;
        public String Value = null;


        public Select(String table, List<String> selectedC, DataComparator compare, TableColumn condiC, String value)
        {
            Table = table;
            SelectedC = selectedC;
            Compare = compare;
            CondiC = condiC;
            Value = value;
        }
        public void Execute(Database database)
        {
           database.Select(Table, SelectedC, Compare, CondiC, Value);
        }
    }
}

