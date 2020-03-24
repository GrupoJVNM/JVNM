using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class SelectAllWithOutC : MiniSQLQuery
    {
        string tableName;

        public SelectAllWithOutC(string tableName) {
            this.tableName = tableName;
        }
        public void Execute(Database database)
        {
            database.selectAllWithOutC(tableName);
        }
    }
}

