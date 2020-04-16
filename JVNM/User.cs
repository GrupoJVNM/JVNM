using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class User
    {
        string name;
        string password;
        SecurityProfile secperfil;

        public User(string name,string password, SecurityProfile secperfil)
        {
            this.name = name;
            this.password = password;
            this.secperfil = secperfil;
        }
        public string GetName()
        {
            return name;
        }
        public string GetPassword()
        {
            return password;
        }
        //obtener perfil de seguridad
        public SecurityProfile GetSecurityProfile()
        {
            return secperfil;
        }
        public void SetSecurityProfile (SecurityProfile sec)
        {
            secperfil = sec;
        }
        }
}
