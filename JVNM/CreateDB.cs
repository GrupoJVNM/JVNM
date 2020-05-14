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

        public CreateDB(string dbName, string userName, string psw)
        {
            DBName = dbName;
            UserName = userName;
            Psw = psw;
        }

        public string Execute(Database database)
        {
            string folder = @"";
            string path2 = Path.Combine(folder, "MyDB");
            //It doesnt create a new folder if already exist
            Directory.CreateDirectory(path2);



            string pathOK = @"./MyDB/" + DBName + ".txt";
            string path = @"./MyDB/";

            MiniSQLTester.SetName(DBName);

            if (!File.Exists(pathOK))
            {
                if (UserName.Equals("admin") && Psw.Equals("admin"))
                {
                    string fileName = DBName + ".txt";
                    path = Path.Combine(path, fileName);
                    System.IO.FileStream fs = System.IO.File.Create(path);
                    MiniSQLTester.database = new Database(DBName, UserName, Psw);
                    MiniSQLTester.database.AddUser("admin", "admin", "admin");
                    fs.Close();
                    return Query.CreateDatabaseSuccess;
                }
                else
                {
                    return Query.SecurityUserDoesNotExist;
                }
            }
            else
            {


                MiniSQLTester.database = new Database(DBName, "admin", "admin");
                MiniSQLTester.database.AddUser("admin", "admin", "admin");
                MiniSQLTester.database.Load(DBName);

                User userName = MiniSQLTester.database.getUsers().Find(user => user.GetName().Equals(UserName));

                try
                {
                    if (userName.GetPassword().Equals(Psw))
                    {

                        MiniSQLTester.database.User = UserName;
                        MiniSQLTester.database.Password = Psw;
                        return Query.OpenDatabaseSuccess;
                    }
                    else
                    {

                        MiniSQLTester.loginOk = false;

                        return Query.SecurityIncorrectLogin;

                    }

                }
                catch
                {
                    MiniSQLTester.loginOk = false;
                    return Query.SecurityUserDoesNotExist;
                }
            }



        }
    }
}
