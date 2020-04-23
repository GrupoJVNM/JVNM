using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace JVNM
{
    public class Database
    {
        public List<Table> Tables;
        public string Name;
        public string User;
        public string Password;
        private List<User> Users;
        public List<SecurityProfile> Profiles;
        
        //Constructor
        //create a database with commons parameters
        public Database(string name, string user, string password)
        {
            Name = name;
            User = user;
            Password = password;

            Tables = new List<Table>();
            Users = new List<User>();
            Profiles = new List<SecurityProfile>();
            //Create(Name);
        }


        public List<List<String>> SelectWithOutC(string tableName, List<String> selectedC )
        {
            return Tables.Find(table => table.GetTableName().Equals(tableName)).SelectWithOutC(selectedC);

        }

        public List<List<String>> Select(string tableName, List<String> selectedC, DataComparator compare, String condiC, String value)
        {
            TableColumn t = Tables.Find(table => table.GetTableName().Equals(tableName)).GetListTableColumn().Find(column => column.GetColumnName().Equals(condiC));
            return Tables.Find(table => table.GetTableName().Equals(tableName)).Select(selectedC, compare, t, value);
            
        }

        public List<List<String>> SelectAll(string tableName, DataComparator compare, String condiC, String value)
        {
            TableColumn t = Tables.Find(table => table.GetTableName().Equals(tableName)).GetListTableColumn().Find(column => column.GetColumnName().Equals(condiC));
            return Tables.Find(table => table.GetTableName().Equals(tableName)).SelectAll(compare, t, value);

        }
        public List<List<String>> selectAllWithOutC(string tableName)
        {
            return Tables.Find(table => table.GetTableName().Equals(tableName)).SelectAllWithOutC();
        }

        public void Insert(string tableName, List<String> list)
        {
            Tables.Find(table => table.GetTableName().Equals(tableName)).AddTuple(list);
        }

        public void Delete(string tableName, String tc, DataComparator c, String data)
        {
            TableColumn t = Tables.Find(table => table.GetTableName().Equals(tableName)).GetListTableColumn().Find(column => column.GetColumnName().Equals(tc));
            Tables.Find(table => table.GetTableName().Equals(tableName)).DeleteTupleWithC(t, data, c);
        }

        public void DropTable(string tableName)
        {
            for(int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].GetTableName().Equals(tableName))
                {
                    Tables.RemoveAt(i);
                }

            }
            
           
        }

        public void Update(String tableName, String tc, String data, DataComparator compare, String conditionData, String columnCondition)
        {
            TableColumn t = Tables.Find(table => table.GetTableName().Equals(tableName)).GetListTableColumn().Find(column => column.GetColumnName().Equals(tc));
            TableColumn t2 = Tables.Find(table => table.GetTableName().Equals(tableName)).GetListTableColumn().Find(column => column.GetColumnName().Equals(columnCondition));

            Tables.Find(table => table.GetTableName().Equals(tableName)).Update(t, data, compare, conditionData, t2);
        }
        //Method: Load any database
        public void Load(String BDname)
        {
            //conexion abrir
            string path = "../Debug/MyDB_CODIGO/" + BDname + ".txt";
            
                if (File.Exists(path)==false)
                {

                Console.WriteLine(Query.DatabaseDoesNotExist);
                }
            
            else
            {
                
                File.ReadAllText(path);
               
            }
        }

        public void DeleteUser(String user)
        {
            for(int i = 0; i<Users.Count; i++)
            {
                if (Users[i].GetName().Equals(user))
                {
                    Users.RemoveAt(i);
                }
            }

        }

        public String AddUser(String name, String password, String securityProfile)
        {
            SecurityProfile sP = null;
            Boolean existe = false;
            Boolean existe2 = false;
            int i = 0;
            int j = 0;
            
            while(!existe|| j < Users.Count())
            {
                if (!Users[j].GetName().Equals(name))
                {
                    j++;
                }
                else
                {
                    existe = true;
                    return Query.SecurityUserAlreadyExists;
                }

            }
            while (!existe2 || i < Profiles.Count())
            {
                if (Profiles[i].getProfileName().Equals(securityProfile))
                {
                    existe2 = true;
                    sP = Profiles[i];
                }

                else
                {
                    i++;
                }
            }

                if(!existe && existe2)
                {
                    Users.Add(new User(name, password, sP));
                return Query.SecurityUserAdded;
                }
                else if(!existe && !existe2)
            {
                sP = new SecurityProfile("admin");
                Users.Add(new User(name, password,sP));
                return Query.SecurityUserAdded;
            }
            return null;

            }

        
        
        //This method create the folder if dont exist and create the bd.txt
        public void Create(string BDname)
        {
            string pathOk = "../Debug/MyDB_CODIGO/" + BDname + ".txt"; 
         
            string folder = "../Debug/";
            string path = Path.Combine(folder, "MyDB_CODIGO");
            //It doesnt create a new folder if already exist
            Directory.CreateDirectory(path);
           // if (!File.Exists(pathOk))
            
                string fileName = BDname + ".txt";
                path = Path.Combine(path, fileName);
                System.IO.FileStream fs = System.IO.File.Create(path);
                  
        }
        
         //Method that save the database in our path  
        public void Save(string BDname)
        {
            string path = "../Debug/MyDB_CODIGO/" + BDname + ".txt";
           
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < Tables.Count; i++)
                {
                    sw.Write("[");
                    for (int k = 0; k < Tables[i].GetListTableColumn().Count; k++)
                    {
                        sw.Write("'" + Tables[i].GetListTableColumn()[k].GetColumnName() + "'");
                    }
                    sw.Write("]{");
                    for (int j = 0; j < Tables[i].Columns.Count; j++)
                    {                  
                        //guarda directamente la informacion de las tuplas 
                        for (int k = 0; k < Tables[i].Columns[j].GetList().Count; k++)
                        {
                            string s = Tables[i].Columns[j].GetList()[k];
                           
                            sw.Write("'" + s + "'");
                        }

                    }
                    sw.Write("}");
                    sw.Write("\n");
                } 
            }
        }
        public void AddTable(Table table)
        {
            Tables.Add(table);
            
        }
       /* public void DropDatabase(String BDname)
        {
            string path = "../Debug/MyDB_CODIGO/" + BDname + ".txt";

            //busca la bd 
            if (File.Exists(path))
            {
                File.Delete(path);
            }


        }*/
        
        public void Close(String BDname)
        {
            string myFile = Directory.GetCurrentDirectory();
            myFile = null;
        }

        public List<Table> GetList()
        {
            return Tables;
        }


        public string ExecuteMiniSQLQuery(string query)
        {
            //Parse the query
            MiniSQLQuery miniSQLQuery = Parser.Parse(query);

            if (miniSQLQuery == null)
                return "ErrorDatabase";

            string result = miniSQLQuery.Execute(this);
            
            //Save(Name);
            return result;
        }

        public void DropSecurityProfile(string name)
        {
            //hay que borrar tambien de la lista de los users ademas de los de profile
            SecurityProfile sp = new SecurityProfile("admin");
          
            for(int i=0; i< Users.Count; i++){
                if (Users[i].GetSecurityProfile().getProfileName().Equals(name))
                {
                    //borrar 
                    Users[i].SetSecurityProfile(sp);
                   
                }
             
            }
            for(int j=0; j<Profiles.Count; j++)
            {
               if(Profiles[j].getProfileName().Equals(name))
                {
                    Profiles.RemoveAt(j);
                }
            }


        }

        public List<SecurityProfile> getProfiles()
        {
            return Profiles;
        }
        public List<User> getUsers()
        {
            return Users;
        }

    }
}