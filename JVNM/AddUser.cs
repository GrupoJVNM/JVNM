using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class AddUser : MiniSQLQuery
    {
         string user;
         string password;
        //añadir perfil de seguridad?
        AddUser(string user, string password) {
            this.user = user;
            this.password = password;
        }

        public string Execute(Database database)
        {
            // return database.AddUser(user, password);
            throw new NotImplementedException();
        }
    }
}
