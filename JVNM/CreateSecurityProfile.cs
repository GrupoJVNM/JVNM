using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class CreateSecurityProfile : MiniSQLQuery
    {
        public string Name;
        public CreateSecurityProfile(string name)
           {
            Name = name;
         }

        public string Execute(Database database)
        {
            Boolean done = false;
           
            try
            {
                for (int i = 0; i < database.getProfiles().Count; i++)
                {

                    if (!database.getProfiles()[i].getProfileName().Equals(Name))
                    {
                        SecurityProfile sp = new SecurityProfile(Name);
                        done = true;
                       
                    }
                   
                   
                }
                if (done == true)
                {
                    return Query.SecurityProfileCreated;
                }
                else
                {
                    return Query.SecurityProfileAlreadyExists;
                }
            }
           
            catch
                {
                        return Query.Error ;
                }

        }


    }
}
