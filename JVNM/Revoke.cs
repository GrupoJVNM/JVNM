using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    class Revoke:MiniSQLQuery
    {
        public string Name;
        public string Table;
        public string Privilege;


        public Revoke(string name, string table, string privilege)
        {
            Name = name;
            Table = table;
            Privilege = privilege;
        }




        public string Execute(Database database)
        {
            Boolean done = false;
            try
            {
                for (int i = 0; i < database.getProfiles().Count; i++)
                {
                    if (database.getProfiles()[i].getProfileName().Equals(Name))
                    {
                        database.getProfiles()[i].Revoke(Table, Privilege);
                        done = true;
                    }

                }
                if (done == true)
                {
                    return Query.SecurityPrivilegeRevoked;
                }
                else
                {
                    return Query.SecurityProfileDoesNotExist;
                }
            }
            catch
            {
                return "SecurityPriviledgeNotExists";
            }

        }

    }
}
