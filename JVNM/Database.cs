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

        //Constructor
        //create a database with commons parameters
        public Database(string name, string user, string password)
        {
            Name = name;
            User = user;
            Password = password;

            Tables = new List<Table>();
        }


        public List<List<String>> selectWithOutC(string tableName, List<String> selectedC )
        {
            return Tables.Find(table => table.getTableName().Equals(tableName)).selectWithOutC(selectedC);

        }

        public List<List<String>> Select(string tableName, List<String> selectedC, DataComparator compare, TableColumn condiC, String value)
        {
            return Tables.Find(table => table.getTableName().Equals(tableName)).Select(selectedC, compare, condiC, value);
            
        }

        public List<List<String>> SelectAll(string tableName, DataComparator compare, TableColumn condiC, String value)
        {
            return Tables.Find(table => table.getTableName().Equals(tableName)).SelectAll(compare, condiC, value);

        }
        public List<List<String>> selectAllWithOutC(string tableName)
        {
            return Tables.Find(table => table.getTableName().Equals(tableName)).selectAllWithOutC();
        }

        public void insert(string tableName, List<String> list)
        {
            Tables.Find(table => table.getTableName().Equals(tableName)).AddTuple(list);
        }

        public void delete(string tableName, TableColumn tc, String data)
        {
            Tables.Find(table => table.getTableName().Equals(tableName)).DeleteTuple(tc, data);
        }
        //Method: Load any database
        public void Load(String BDname)
        {

            // string path = Path.GetFullPath(BDname + ".txt");
            // Console.WriteLine(path);


            //conexion abrir
            string path = "../Debug/MisBD/"+BDname+".txt";
            
            
            if (path != null)
            {
                string rt = File.ReadAllText(path);
                Console.WriteLine(rt);
            }
            else
            {
                Console.WriteLine(Query.DatabaseDoesNotExist);
               }
        }

        
         //Method that save the database in our path  

        public void Save(string BDname)
        {
            string path = "../Debug/MisBD/" + BDname + ".txt";

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                for (int i = 0; i < Tables.Count; i++)
                {
                    for (int j = 0; j< Tables[i].Columns.Count; j++)
                    {
                        //guarda directamente la informacion de las tuplas 
                        for(int k = 0; k< Tables[i].Columns[j].GetList().Count; k++)
                        {
                            string s = Tables[i].Columns[j].GetList()[k];
                            if (s == null)
                            {
                                File.WriteAllText(BDname + ".txt", " ");
                            }
                            else
                            {
                                File.WriteAllText(BDname + ".txt", s);
                            }
                            File.WriteAllText(BDname + ".txt", "\n");
                        }
                       
                       
                    }

                }
            }
           
        }
        public void AddTable(Table table)
        {
            Tables.Add(table);
            
        }
        public void DeleteTable(Table table)//DROP
        {
            Tables.Remove(table);
        }
        public void DropDatabase(String BDname)
        {
            string path = "../Debug/MisBD/" + BDname + ".txt";

            //busca la bd 
            if (File.Exists(path))
            {
                File.Delete(path);
            }


        }
        /*
        //select all the tuples FROM one table
        public void SelectAllTuples(String tableName)
        {
            for(int i=0; i <= tables.Count; i++)
            {
                if (tableName.Equals(tables[i].getTableName()))
                {
                    tables[i].selectAllWithOutC();
                }
            }
        }
         */

        //Print all the tuples from the tables and close it
         public void PrintAllTables (String BDname)
        {

            //DataComparator compare, TableColumn condiC, String value
            for (int i = 0; i < Tables.Count; i++)
            {
                Console.WriteLine(Tables[i].selectAllWithOutC());
            }
            Close(BDname);
        }
       
        public void Close(String BDname)
        {
            Save(BDname);
            
            
        }

        public List<Table> getList()
        {
            return Tables;
        }

        /*public string RunMiniSQLQuery(string sentence)
        {
            
          for (int i=0; i<=sentence.Length; i++)
            {
                // String [] words= sentence.Split(' ');
                List <String> words = new List<String>();
                 words = sentence.Split(' ').ToList();


                String query = words[0].ToUpper();

                if (query.Equals("SELECT"))
                {
                    //ARRAY ESTRUCTURA SELECT
                    //  CONDICION
                    if (words.Contains("WHERE"))
                    {
                        //existe 
                        //hay asterisco
                        if (words.Contains("*"))
                        {
                        //selectAll()


                        }
                    }
                    else
                    {
                        //metodo selectAllWithOutC()
                    }

                        




                }
                else if(query.Equals("INSERT"))
                {
                    //ARRAY ESTRUCTURA INSERT
                }
                else if (query.Equals("UPDATE"))
                {
                    //ARRAY ESTRUCTURA UPDATE
                }
                else if (query.Equals("DELETE"))
                {
                    //ARRAY ESTRUCTURA DELETE
                }
                else
                {
                    Console.WriteLine(Query.Error);
                }

                

                
            }

            



            return null;
        }*/




    }
}