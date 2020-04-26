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
            Boolean existe = false;
            int i = 0;
           
            try
            {
                if (database.getProfiles().Count == 0)
                {
                    existe = false;
                }
                while(existe && i<database.getProfiles().Count)
                {

                    if (!database.getProfiles()[i].getProfileName().Equals(Name))
                    {
                     
                        existe = true;
                       
                    }   

                    i++;
                }
                if (existe == false)
                {
                    SecurityProfile sp = new SecurityProfile(Name);
                    database.getProfiles().Add(sp);
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
