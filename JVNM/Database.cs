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
        public List<Table> tables;
        string name;
        string user;
        string password;

        //Constructor
        //create a database with commons parameters
        public Database(string name, string user, string password)
        {
            this.name = name;
            this.user = user;
            this.password = password;

            tables = new List<Table>();
        }

        public void Load(String BDname)
        {
            //conexion abrir
          
            


            string path = @"c:\JVNM\" + BDname + ".txt";
            string rt = File.ReadAllText(path);
            Console.WriteLine(rt);
        }
              

        public void Save(String BDname)
        {
            string path = @"c:\JVNM\" + BDname + ".txt";

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                for (int i = 0; i <= tables.Count; i++)
                {
                    for (int j = 0; j<= tables[i].columns.Count; j++)
                    {
                        for(int k = 0; k<= tables[i].columns[j].GetList().Count; k++)
                        {
                            string s = tables[i].columns[j].GetList()[k];
                            if (s == null)
                            {
                                File.WriteAllText(path, " ");
                            }
                            else
                            {
                                File.WriteAllText(path, s);
                            }
                            
                        }
                        File.WriteAllText(path, "\n");
                    }

                }
            }
           
        }
        public void AddTable(Table table)
        {
            tables.Add(table);
            
        }
        public void DeleteTable(Table table)
        {
            tables.Remove(table);
        }
        public void DropDatabase(String BDname)
        {
            string path = @"c:\JVNM\" + BDname + ".txt";

            //busca la bd 
            if (File.Exists(path))
            {
                File.Delete(path);
            }


        }

        //select all the tuples
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
         

        //Print all the tuples from the tables and close it
         public void PrintAllTables (String BDname)
        {

            //DataComparator compare, TableColumn condiC, String value
            for (int i = 0; i < tables.Count; i++)
            {
                Console.WriteLine(tables[i].selectAllWithOutC());
            }
            Close(BDname);
        }
       
        public void Close(String BDname)
        {
            Save(BDname);
            
        }

        public List<Table> getList()
        {
            return tables;
        }

        public string RunMiniSQLQuery(string sentence)
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
        }




    }
}