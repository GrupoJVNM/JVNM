using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
                byte[] msg = null;

                Boolean login = false;

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
                    List<string> v = new List<string>();
                    // Loop to receive all the data sent by the client.
                    try
                    {
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);

                            if (login == false)
                            {
                                v = CommaSeparatedNames(data);
                                MiniSQLTester.database = new Database(v[0], v[1], v[2]);
                            }


                            try
                            {
                                MiniSQLQuery query = Parser.Parse(data);
                                string sentence = query.Execute(MiniSQLTester.database);

                                if (sentence.Equals(Query.SecurityUserDoesNotExist) || sentence.Equals(Query.SecurityIncorrectLogin))
                                {
                                    //ENVIAR A LA CONSOLA
                                    msg = System.Text.Encoding.ASCII.GetBytes(sentence);
                                    stream.Write(msg, 0, msg.Length);

                                    client.Close();
                                }

                                else if (sentence.Equals(Query.CreateDatabaseSuccess) || sentence.Equals(Query.OpenDatabaseSuccess))
                                {
                                    login = true;
                                    msg = System.Text.Encoding.ASCII.GetBytes(sentence);

                                    stream.Write(msg, 0, msg.Length);
                                    Console.WriteLine("Sent: {0}", sentence);

                                }

                                else if (login == true)
                                {

                                    string dbtxt = @"./MyDB/" + MiniSQLTester.database.Name + ".txt";
                                    List<string> lines2 = new List<String>();

                                    if (!data.Contains("stop"))
                                    {
                                        if ((data.Contains("CREATE") || data.Contains("INSERT") || data.Contains("DELETE") || data.Contains("GRANT") || data.Contains("ADD") || data.Contains("REVOKE")) && (!sentence.Contains("ERROR")))
                                        {
                                            lines2.Add(data);
                                        }

                                        msg = System.Text.Encoding.ASCII.GetBytes(sentence);

                                        stream.Write(msg, 0, msg.Length);
                                        Console.WriteLine("Sent: {0}", sentence);

                                        File.AppendAllLines(dbtxt, lines2);
                                        lines2.Clear();
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg = System.Text.Encoding.ASCII.GetBytes(Query.WrongSyntax);
                                stream.Write(msg, 0, msg.Length);
                                Console.WriteLine(msg);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Se ha cerrado la sesión");                       
                        Thread.Sleep(4000);
                        client.Close();
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                Thread.Sleep(10000);
            }
            finally
            {
                Thread.Sleep(10000);
                // Stop listening for new clients.
                server.Stop();
            }
        }

        static List<string> CommaSeparatedNames(string text)
        {
            string t = text.Trim(' ');
            string[] s = t.Split(',');

            return s.ToList();
        }


    }
}