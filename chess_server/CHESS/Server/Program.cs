using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Net.Sockets;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888);

            TcpClient clientSocket = default(TcpClient);

            serverSocket.Start();

            clientSocket = serverSocket.AcceptTcpClient();

            while ((true))

            {

                try

                {

                    NetworkStream networkStream = clientSocket.GetStream();

                    byte[] bytesFrom = new byte[10025];

                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);

                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                 /*   string serverResponse = "Last Message from client: " + dataFromClient;

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);

                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    networkStream.Flush();*/


                }

                catch (Exception ex)

                {

                }

            }
            clientSocket.Close();

            serverSocket.Stop();


        }
    }
}
