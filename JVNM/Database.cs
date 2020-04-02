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


        public string ExecuteMiniSQLQuery(string query)
        {
            //Parse the query
            MiniSQLQuery miniSQLQuery = Parser.Parse(query);

            if (miniSQLQuery == null)
                return "ErrorDatabase";

            string result = miniSQLQuery.Execute(this);
            //string path = "../Debug/MyDB_CODIGO/" + Name + ".txt";
          //  string path = @"output-file.txt";
           /* using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(result);
            }*/
            //Save(Name);
            return result;
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