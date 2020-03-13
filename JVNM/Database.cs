using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Database Load()
        {
            return null;
        }

      

        public Database Save()
        {   



            //directorio 
           // writeAllText
            return null;
        }
        public void AddTable(Table table)
        {
            tables.Add(table);
            
        }
        public void DeleteTable(Table table)
        {
            tables.Remove(table);
        }
        public void DropDatabase()
        {

        }

        //select all the tuples
        public void SelectAllTuples()
        { }
         

        //Print all the tuples from the tables and close it
         public void PrintAllTables ()
        {
            //DataComparator compare, TableColumn condiC, String value
            for(int i = 0; i < tables.Count; i++)
            {
                Console.WriteLine(tables[i].selectAllWithOutC());

            }
            Close();




        }
       public void Close()
        {
        }

        public List<Table> getList()
        {
            return tables;
        }

    }
}