using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class Update : MiniSQLQuery
    {
        public string Tc;
        public string Data;
        public DataComparator Compare;
        public string ConditionData;
        public string ColumnCondition;
        public string Table;
    
        public Update(string table, string tc, string data, DataComparator compare, string conditionData, string columnCondition)
        {
            this.Table = table;
            this.Tc = tc;
            this.Data = data;
            this.Compare = compare;
            this.ConditionData = conditionData;
            this.ColumnCondition = columnCondition;

        }

        public string Execute(Database database)
        {
            if (database.permission(Table, "UPDATE") || database.User.Equals("admin"))
            {
                try
                {
                    database.Update(Table, Tc, Data, Compare, ConditionData, ColumnCondition);
                    return Query.TupleUpdateSuccess;
                }
                catch
                {
                    return Query.Error;
                }
            }
            else
            {
                return Query.SecurityNotSufficientPrivileges;
            }
        }

    }
}
