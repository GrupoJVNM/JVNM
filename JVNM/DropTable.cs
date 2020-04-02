using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class DropTable : MiniSQLQuery
    {
        public String Table;

        public DropTable(String table)
        {
            this.Table = table;
        }

        public string Execute(Database database)
        {
            try
            {
                database.DropTable(Table);
                return "Deleted";
            }
            catch
            {
                return Query.Error;
            }
        }
    }
}
