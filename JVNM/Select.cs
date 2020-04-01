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
        public String CondiC = null;
        public String Value = null;


        public Select(String table, List<String> selectedC, DataComparator compare, String condiC, String value)
        {
            Table = table;
            SelectedC = selectedC;
            Compare = compare;
            CondiC = condiC;
            Value = value;
        }
        public string Execute(Database database)
        {
            try
            {
                database.Select(Table, SelectedC, Compare, CondiC, Value);
                return "Selection success";
            }
            catch
            {
                return Query.Error;
            }
        }
    }
}

