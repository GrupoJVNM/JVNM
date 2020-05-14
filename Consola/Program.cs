using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using JVNM;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.IO;

namespace Consola
{
    public class Program
    {


        public static void Main(string[] args)
        {
            Console.WriteLine("Write the port: ");
            int puerto = int.Parse(Console.ReadLine());
            Console.WriteLine("Write the server: ");
            string server = Console.ReadLine();
            TcpClient client = new TcpClient(server, puerto);


            Console.WriteLine("Write the name of the database: ");
            string nameDatabase = Console.ReadLine();
            Console.WriteLine("Write the name of the user: ");
            string nameUser = Console.ReadLine();
            Console.WriteLine("Write the password of the user: ");
            string pass = Console.ReadLine();

            //Database1,admin,admin
            string login = nameDatabase + "," + nameUser + "," + pass;

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(login);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", login);

            Byte[] re = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(re, 0, re.Length);
            responseData = System.Text.Encoding.ASCII.GetString(re, 0, bytes);



            //AÑADIR ERRORESSS
            //while (responseData.Equals(Query.SecurityUserDoesNotExist) || responseData.Equals(Query.SecurityIncorrectLogin))
            //{
            //database1,eva,123
            if (responseData.Equals(Query.SecurityUserDoesNotExist))
            {
                Console.WriteLine("Received: {0}", responseData);
                //Console.WriteLine("Write the name of the user: ");
                //nameUser = Console.ReadLine();

                client.Close();

            }
            else if (responseData.Equals(Query.SecurityIncorrectLogin))
            {
                Console.WriteLine("Received: {0}", responseData);
                //Console.WriteLine("Write the password of the user: ");
                //pass = Console.ReadLine();
                client.Close();

            }
            else {
                login = nameDatabase + "," + nameUser + "," + pass;

                data = System.Text.Encoding.ASCII.GetBytes(login);
            }
                stream.Write(data, 0, data.Length);
               // Console.WriteLine("Sent: {0}", login);




           // }
            Console.WriteLine("correct login");

            try
            {
                Console.WriteLine("Write the sentences: ");
                string sen = Console.ReadLine();
                data = System.Text.Encoding.ASCII.GetBytes(sen);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", sen);

                while (!sen.Contains("stop"))
                {
                    bytes = stream.Read(re, 0, re.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(re, 0, bytes);
                    Console.WriteLine(responseData);

                    Console.WriteLine("Write the sentences: ");
                    sen = Console.ReadLine();

                    data = System.Text.Encoding.ASCII.GetBytes(sen);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", sen);
                }
            }

            finally
            {
                client.Close();
            }
            //}


        }
    }
}
