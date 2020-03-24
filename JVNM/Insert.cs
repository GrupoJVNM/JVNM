using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class Insert : MiniSQLQuery
    {
       public  string TableName = null;
       public List<String> List = null;

        public Insert(string tableName, List<String> list) {
            TableName = tableName;
            List = list;
        }
        public void Execute(Database database)
        {
             database.insert(TableName, List);
        }
    }
}
}
