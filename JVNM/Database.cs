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
            return null;
        }
        public void AddTable(Table table)
        {
            //tables.Add(table);
        }
        public void DeleteTable(Table table)
        {

        }
        //public void DropDatabase ()

        //select all the tuples
        /* public void SelectAllTuples()
         { 
         }*/

        //Print all the tuples from the tables and close it
        /* public void PrintAllTables (Table table)
        {
        Console.WriteLine(table.SelectAllTuples(“myTable”));
            table.Close();
 
        }*/
       /* public void Close()
        {
        }*/
    }
}
