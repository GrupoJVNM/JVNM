using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class DeleteTuple : MiniSQLQuery
    {
        string tableName;
        TableColumn tc;
        String data;
        public DeleteTuple(string tableName, TableColumn tc, String data) {
            this.tableName = tableName;
            this.tc = tc;
            this.data = data;

        }
        public void Execute(Database database)
        {
            database.delete(tableName,tc,data);
        }
    }
}
