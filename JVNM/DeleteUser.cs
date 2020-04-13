using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class DeleteUser : MiniSQLQuery
    {
        public string name;
        public DeleteUser(string name)
        {
            this.name = name;
        }

        public string Execute(Database database)
        {
            // return database.DeleteUser(name);
            throw new NotImplementedException();
        }
    }
}
