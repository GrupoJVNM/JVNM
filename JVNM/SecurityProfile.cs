using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class SecurityProfile
    {
        private List<String> Privilege;  
        public string NameProfile;
        public List<String> Tables;

        public SecurityProfile(string Name)
        {
            this.NameProfile = Name;
            Privilege = new List<string>();
            Tables = new List<string>();
        }
        //gives a priviledge to a specific table
        public void Grant(string table, string privilege )
        {
            Privilege.Add(privilege);
            Tables.Add(table);
        }
        public string getProfileName()
        {
            return NameProfile;
        }
        public void Revoke(string table, string privilege)
        {
         
            for(int i=0; i<Privilege.Count; i++)
            {
                if(Privilege.ElementAt(i).Equals(privilege) && Tables.ElementAt(i).Equals(table))
                {
                    Privilege.RemoveAt(i);
                    Tables.RemoveAt(i);
                }

            }

        }
       
       


    }
}
