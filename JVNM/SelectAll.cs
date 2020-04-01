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
        public String CondiC = null;
        public String Value = null;

        public SelectAll(String table, DataComparator compare, String condiC, String value)
        {
            Table = table;
            Compare = compare;
            CondiC = condiC;
            Value = value;
        }
        public string Execute(Database database)
        {
            try
            {
                database.SelectAll(Table, Compare, CondiC, Value);
                return "Select success";
            }
            catch
            {
                return Query.Error;
            }
            
        }
    }
}

