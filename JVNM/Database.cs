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


        public List<List<String>> SelectWithOutC(string tableName, List<String> selectedC )
        {
            return Tables.Find(table => table.GetTableName().Equals(tableName)).SelectWithOutC(selectedC);

        }

        public List<List<String>> Select(string tableName, List<String> selectedC, DataComparator compare, TableColumn condiC, String value)
        {
            return Tables.Find(table => table.GetTableName().Equals(tableName)).Select(selectedC, compare, condiC, value);
            
        }

        public List<List<String>> SelectAll(string tableName, DataComparator compare, TableColumn condiC, String value)
        {
            return Tables.Find(table => table.GetTableName().Equals(tableName)).SelectAll(compare, condiC, value);

        }
        public List<List<String>> selectAllWithOutC(string tableName)
        {
            return Tables.Find(table => table.GetTableName().Equals(tableName)).SelectAllWithOutC();
        }

        public void Insert(string tableName, List<String> list)
        {
            Tables.Find(table => table.GetTableName().Equals(tableName)).AddTuple(list);
        }

        public void Delete(string tableName, TableColumn tc, String data)
        {
            Tables.Find(table => table.GetTableName().Equals(tableName)).DeleteTuple(tc, data);
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
                    for (int j = 0; j < Tables[i].Columns.Count; j++)
                    {
                        
                        //guarda directamente la informacion de las tuplas 
                        for (int k = 0; k < Tables[i].Columns[j].GetList().Count; k++)
                        {
                            string s = Tables[i].Columns[j].GetList()[k];
                            if (s == null)
                            {
                                sw.Write(" ");
                            }
                            else
                            {
                                sw.Write(s+" ");
                            }
                            
                        }
                       

                    }
                    sw.Write("\n");
                }
            }
        }
        public void AddTable(Table table)
        {
            Tables.Add(table);
            
        }
        public void DropDatabase(String BDname)
        {
            string path = "../Debug/MyDB_CODIGO/" + BDname + ".txt";

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
         /*public void PrintAllTables (String BDname)
        {
            //DataComparator compare, TableColumn condiC, String value
            for (int i = 0; i < Tables.Count; i++)
            {
                Console.WriteLine(Tables[i].SelectAllWithOutC());
            }
        }
       */
        public void Close(String BDname)
        {
            string myFile = Directory.GetCurrentDirectory();
            myFile = null;
        }

        public List<Table> GetList()
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