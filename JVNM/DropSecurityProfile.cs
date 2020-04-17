using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class DropSecurityProfile:MiniSQLQuery
    {
        public string Name;
        public DropSecurityProfile(string name)
        {
            Name = name;
        }

        public string Execute(Database database)
        {
            Boolean done=false;
            try
            {
                if (!Name.Equals("admin"))
                {
                    for (int i = 0; i < database.getProfiles().Count; i++)

                    {
                        if (database.getProfiles()[i].getProfileName().Equals(Name))
                        {

                            database.DropSecurityProfile(Name);
                            done = true;
                        }


                    }

                    if (done == true)
                    {
                        return Query.SecurityProfileDeleted;
                    }
                    else
                    {
                        return Query.SecurityProfileDoesNotExist;
                    }
                }
                else
                {
                    return "Error: admin profile can´t be dropped";
                }



            }
            catch
            {
                return Query.Error;
            }

        }


    }
}
