using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class Update : MiniSQLQuery
    {
        public string tc;
        public string data;
        public DataComparator compare;
        public string conditionData;
        public string columnCondition;
        public string table;
    
        public Update(string table, string tc, string data, DataComparator compare, string conditionData, string columnCondition)
        {
            this.table = table;
            this.tc = tc;
            this.data = data;
            this.compare = compare;
            this.conditionData = conditionData;
            this.columnCondition = columnCondition;

        }

        public string Execute(Database database)
        {
            try
            {
                database.Update(table, tc, data,  compare,  conditionData,  columnCondition);
                return Query.TupleUpdateSuccess;
            }
            catch
            {
                return Query.Error;
            }
            
        }

    }
}
