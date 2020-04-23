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

        public string CreateBDExecute()
        {
            string pathOK = @"/MyDB/" + DBName + ".txt";
            string path = @"/MyDB/"; 
            string fileName = DBName + ".txt";
            path = Path.Combine(path, fileName);
            if (!File.Exists(pathOK))
            {
                System.IO.FileStream fs = System.IO.File.Create(path);
                Database db = new Database(DBName, UserName, Psw);
                return Query.CreateDatabaseSuccess;
            }
            else
            {
                Database db = new Database(DBName, UserName, Psw);
                db.Load(DBName);
                return Query.OpenDatabaseSuccess;
            }
            
        }
    }
}
