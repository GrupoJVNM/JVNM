using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class DeleteTuple : MiniSQLQuery
    {
        public string TableName;
        public String Tc;
        public String Data;
        public DataComparator comparator;

        public DeleteTuple(string tableName, String tc,DataComparator c ,String data) {
            TableName = tableName;
            Tc = tc;
            Data = data;
            comparator = c;

        }
        public string Execute(Database database)
        {
            if (database.permission(TableName, "DELETE") || database.User.Equals("admin"))
            {
                try
                {
                    database.Delete(TableName, Tc, comparator, Data);
                    return Query.TupleDeleteSuccess;
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
