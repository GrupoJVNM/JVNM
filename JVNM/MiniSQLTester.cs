using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class MiniSQLTester
    {
        //minisql-tester.exe -i input-file.txt -o output-file.txt
        enum Parameter { Unset, InputFile, OutputFile };
        public static Database database;
       public static Boolean loginOk = true;
        static void Main(string[] args)
        {
            string inputFile = "input-file.txt";
            string outputFile = "output-file.txt";
            Parameter lastParameter = Parameter.Unset;
            foreach (string arg in args)
            {
                if (arg == "-i") lastParameter = Parameter.InputFile;
                else if (arg == "-o") lastParameter = Parameter.OutputFile;
                else if (lastParameter == Parameter.InputFile) inputFile = arg;
                else if (lastParameter == Parameter.OutputFile) outputFile = arg;

            }
            string folder = @"";
            string path = Path.Combine(folder, "MyDB");
            //It doesnt create a new folder if already exist
            Directory.CreateDirectory(path);

            database = new Database("database1", "admin", "admin");
            List<string> lines2 = new List<String>();
            string[] lines = System.IO.File.ReadAllLines(@"input-file.txt");
            string output = @"output-file.txt";
            string dbtxt = null;
            //string path = System.IO.Path.Combine(output);
            // System.IO.FileStream fs = System.IO.File.Create(path);
            double total = 0;
            int i = 1;
            
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(output))
            {
                sw.WriteLine("# TEST " + i);
                foreach (string line in lines)
                {
                    DateTime t1 = DateTime.Now;


                    if (line.Equals(""))
                    {
                        sw.WriteLine("TOTAL TIME: " + total + " s");
                        total = 0;
                        sw.WriteLine(" ");
                        i++;
                        sw.WriteLine("# TEST " + i);
                        //database = new Database("database1", "user", "password");
                        File.AppendAllLines(dbtxt, lines2);
                        lines2.Clear();
                        loginOk = true;
                        
                    }
                    else
                    {
                      
                        string query = database.ExecuteMiniSQLQuery(line,loginOk);
                       
                        sw.Write(query);
                        
                        if (line.Contains("CREATE") || line.Contains("INSERT") || line.Contains("DELETE") || line.Contains("GRANT") || line.Contains("ADD") || line.Contains("REVOKE")) {
                            lines2.Add(line);
                        }
                        dbtxt = @"./MyDB/" + database.Name + ".txt";

                        
                        DateTime t2 = DateTime.Now;
                        TimeSpan timeDiff = t2 - t1;
                        double seconds = timeDiff.TotalMilliseconds / 1000.0;
                        sw.WriteLine(" (" + seconds + " s)");
                        total = total + seconds;
                    }

                }

            }
       


            Console.WriteLine("Input file: " + inputFile);
            Console.WriteLine("Output file: " + outputFile);

        }

      
        public static void SetName(string nameDB)
        {
            database.Name = nameDB;
        }
       
    }
}
