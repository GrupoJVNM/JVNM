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
        string securityProfile;
        public AddUser(string user, string password, string securityProfile) {
            this.user = user;
            this.password = password;
            //perfil de seguridad
            this.securityProfile = securityProfile;
        }

        public string Execute(Database database)
        {
            try
            {
                database.AddUser(user, password, securityProfile);


                return Query.SecurityUserAdded;
            }
            catch
            {
                return Query.Error;
            }
        }
    }
}
