using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class User
    {
        string name;
        string password;


        //añadir posible perfil de seguridad?¿
        User(string name,string password)
        {
            this.name = name;
            this.password = password;

        }
        public string GetName()
        {
            return name;

        }
        public string GetPassword()
        {
            return password;
        }

        }
}
