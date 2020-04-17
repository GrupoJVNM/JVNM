using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class Grant:MiniSQLQuery
    {
        public string Name;
        public string Table;
        public string Privilege;


        public Grant(string name, string table, string privilege)
        {
            Name = name;
            Table = table;
            Privilege = privilege;
        }


        public string Execute(Database database)
        {
            Boolean done = false ;
            try
            {
                for (int i = 0; i < database.getProfiles().Count; i++)
                {
                    if (database.getProfiles()[i].getProfileName().Equals(Name))
                    {
                        database.getProfiles()[i].Grant(Table, Privilege);
                        done = true;
                    }
                    
                }
                if (done == true)
                {
                    return Query.SecurityPrivilegeGranted;
                }
                else
                {
                    return Query.SecurityProfileDoesNotExist;
                }
            }
            catch 
            {
                return "SecurityPriviledgeAlreadyExists";
            }

        }

    }
}
