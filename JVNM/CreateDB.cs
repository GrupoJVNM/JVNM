using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class CreateDB : MiniSQLQuery
    {
        public string DBName = null;
        public string UserName = null;
        public string Psw = null;
        
        public CreateDB (string dbName, string userName, string psw) {
            DBName = dbName;
            UserName = userName;
            Psw = psw;
        }

        public string Execute(Database database)
        {
            string pathOK = @"./MyDB/" + DBName + ".txt";
            string path = @"./MyDB/";

            MiniSQLTester.SetName(DBName);

            if (!File.Exists(pathOK))
            {
                string fileName = DBName + ".txt";
                path = Path.Combine(path, fileName);
                System.IO.FileStream fs = System.IO.File.Create(path);
                database = new Database(DBName, UserName, Psw);
                fs.Close();
                return Query.CreateDatabaseSuccess;
            }
            else
            {
                database = new Database(DBName, UserName, Psw);
                database.Load(DBName);
                return Query.OpenDatabaseSuccess;
            }

            
        }
    }
}
