using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using JVNM;

namespace Server
{
    public class Program
    {
        static void Main()
        {

            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 1200;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        MiniSQLQuery query = Parser.Parse(data);
                        string sentence = query.Execute(MiniSQLTester.database);

                        byte[] msg = null;
                        //AÑADIR ERRORESSS
                        while (sentence.Equals(Query.SecurityUserDoesNotExist) || sentence.Equals(Query.SecurityIncorrectLogin))
                        {
                            //database1,eva,123
                            if (sentence.Equals(Query.SecurityUserDoesNotExist))
                            {
                                //ENVIAR A LA CONSOLA
                                msg = System.Text.Encoding.ASCII.GetBytes(sentence);

                                //Console.WriteLine("Write the name of the user: ");
                                //nameUser = Console.ReadLine();

                            }
                            if (sentence.Equals(Query.SecurityIncorrectLogin))
                            {
                                msg = System.Text.Encoding.ASCII.GetBytes(sentence);

                                //Console.WriteLine("Incorrect password ");
                                //Console.WriteLine("Write the password of the user: ");
                                //pass = Console.ReadLine();

                            }
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", msg);
                        }

                        msg = System.Text.Encoding.ASCII.GetBytes("correct login");

                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", msg);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }


    }
}