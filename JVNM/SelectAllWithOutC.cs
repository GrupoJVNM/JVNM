using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class SelectAllWithOutC : MiniSQLQuery
    {
       public string TableName;

        public SelectAllWithOutC(string tableName) {
           TableName = tableName;
        }
        public void Execute(Database database)
        {
            database.selectAllWithOutC(TableName);
        }
    }
}

