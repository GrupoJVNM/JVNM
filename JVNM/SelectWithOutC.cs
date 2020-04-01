using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    class SelectWithOutC : MiniSQLQuery
    {
        public string TableName;
        List<String> selectedC;

        public SelectWithOutC(string tableName, List<String> selectedC)
        {
            TableName = tableName;
            this.selectedC = selectedC;
        }

        public string Execute(Database database)
        {
            try
            {
                database.SelectWithOutC(TableName, selectedC);
                return "Select success";
            }
            catch
            {
                return Query.Error;
            }
        }
    }
}
