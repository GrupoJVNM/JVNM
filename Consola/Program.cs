using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using JVNM;
using System.Text;
using System.Threading.Tasks;


namespace Consola
{
    class Program
    {

        
        public static void Main(string[] args)
        {
            Console.WriteLine("Write the name of the database: ");
            string nameDatabase = Console.ReadLine();
            Console.WriteLine("Write the name of the user: ");
            string nameUser = Console.ReadLine();
            Console.WriteLine("Write the password of the user: ");
           string pass = Console.ReadLine();

            MiniSQLTester.database = new Database(nameDatabase, nameUser, pass);
           
            //Database1,admin,admin

          MiniSQLQuery query= Parser.Parse(nameDatabase + "," + nameUser + "," + pass);

           string sentence= query.Execute(MiniSQLTester.database);
            Boolean ok = true;
    
            //AÑADIR ERRORESSS
            while (sentence.Equals(Query.SecurityUserDoesNotExist) || sentence.Equals(Query.SecurityIncorrectLogin) )
            {
                //database1,eva,123
                if (sentence.Equals(Query.SecurityUserDoesNotExist))
                {
                    Console.WriteLine("Write the name of the user: ");
                     nameUser = Console.ReadLine();

                }
                if (sentence.Equals(Query.SecurityIncorrectLogin))
                {
                    Console.WriteLine("Incorrect password ");
                    Console.WriteLine("Write the password of the user: ");
                    pass = Console.ReadLine();

                }

            }
            Console.WriteLine("correct login");


            try
            {
                Console.WriteLine("Write the sentences: ");
                string sen = Console.ReadLine();

                while (!sen.Equals("stop"))
                {
                    //string result = db.ExecuteMiniSQLQuery(sen, true);
                    MiniSQLQuery q1= Parser.Parse(sen);
                    string result = q1.Execute(MiniSQLTester.database);
                    Console.WriteLine(result);
                    Console.WriteLine("Write the sentences: ");
                     sen = Console.ReadLine();

                }


                Console.WriteLine("HAS HECHO STOP");

            }
            finally
            {

            }
           

        }
    }
    }
