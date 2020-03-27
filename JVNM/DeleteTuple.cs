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
       public TableColumn Tc;
        public String Data;
        public DeleteTuple(string tableName, TableColumn tc, String data) {
            TableName = tableName;
            Tc = tc;
            Data = data;

        }
        public void Execute(Database database)
        {
            database.delete(TableName, Tc, Data);
        }
    }
}
