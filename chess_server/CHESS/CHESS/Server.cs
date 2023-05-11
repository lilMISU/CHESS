using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESS
{
    public partial class Server : Form
    {
        private static Server serverForm;
        int clientCount;
        Piece previousPiece;
        static Chessboard myBoard = new Chessboard(8);
        public bool getPiece=false;
        Image previousPieceImage = null;
        int prevX;
        int prevY;
        static IPAddress ipAd = IPAddress.Parse("127.0.0.1");
        static int PortNumber = 8888;
        TcpListener ServerListener = new TcpListener(ipAd, PortNumber);
        TcpClient clientSocket = default(TcpClient);

        public Server()
        {
            InitializeComponent();
            initializeBoard();
            serverForm = this;
            Thread ThreadingServer = new Thread(StartServer);
            ThreadingServer.Start();

        }

   
        private void initializeBoard()
        {
            int cellSize = panel2.Width / myBoard.returnSize();
            panel2.Height = panel2.Width;

            for(int i=0;i<myBoard.returnSize();i++)
                for (int j = 0; j < myBoard.returnSize(); j++)
                {
                    
                    myBoard.theGrid[i, j].Height = cellSize;
                    myBoard.theGrid[i, j].Width = cellSize;
                    myBoard.theGrid[i, j].Click += new EventHandler(this.cell_Click);
                    panel2.Controls.Add(myBoard.theGrid[i, j]);
                    myBoard.theGrid[i, j].Location = new Point(i * cellSize, j * cellSize);
                    
                    
                }

        }

       

        private void cell_Click(object sender,EventArgs e)
       {
           
            Cell clickedButton = (Cell)sender;
            if (getPiece == false)
            {
                if (clickedButton.BackgroundImage != null)
                {
                    getPiece = true;
                    previousPieceImage = clickedButton.BackgroundImage;
                    previousPiece = clickedButton.piece;
                }
                prevX = clickedButton.returnRowNumber(); 
                prevY = clickedButton.returnColumnNumber();;
            }
            else
            {
                clickedButton.piece = previousPiece;
                clickedButton.BackgroundImage = previousPieceImage;
                clickedButton.BackgroundImageLayout = ImageLayout.Center;
                myBoard.theGrid[prevX, prevY].BackgroundImage = null;
                getPiece = false;
                
                clickedButton.piece.ColorChange(myBoard.theGrid);

                String sentData = Convert.ToString(myBoard.theGrid[prevX,prevY].returnRowNumber()) + "_" + Convert.ToString(myBoard.theGrid[prevX, prevY].returnColumnNumber()) + "_" + Convert.ToString(clickedButton.returnRowNumber()) + "_" + Convert.ToString(clickedButton.returnColumnNumber())+"$";
                if (clientCount != 0)
                {
                    Stream stream = clientSocket.GetStream();

                    ASCIIEncoding encoder = new ASCIIEncoding();
                    byte[] bytesSent = encoder.GetBytes(sentData);
                    stream.Write(bytesSent, 0, bytesSent.Length);
                }
               

            }

       }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }
        private void StartServer()
        {
            
            ServerListener.Start();
            clientSocket = ServerListener.AcceptTcpClient();

            while (true)
            {
                try
                {
                    clientCount++;
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[1024];
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    MethodInvoker m = new MethodInvoker(() => serverForm.label1.Text = dataFromClient);
                    serverForm.Invoke(m);
                    Schimba(dataFromClient); 
                    
                }
                catch
                {
                    ServerListener.Stop();
                    ServerListener.Start();
                    clientSocket = ServerListener.AcceptTcpClient();
                }

            }
        }

        public static void Schimba(string date)
        {
            string[] info = date.Split('_');
 
            int currentX = Convert.ToInt32(info[2]);
            int currentY = Convert.ToInt32(info[3]);
            int prevX = Convert.ToInt32(info[0]);
            int prevY = Convert.ToInt32(info[1]);
            myBoard.theGrid[currentX, currentY].piece = myBoard.theGrid[prevX, prevY].piece;
            myBoard.theGrid[prevX,prevY].piece.ColorChange(myBoard.theGrid);                    
            myBoard.theGrid[currentX, currentY].BackgroundImage = myBoard.theGrid[prevX,prevY].BackgroundImage;
            myBoard.theGrid[prevX,prevY].BackgroundImage = null;
        
        }
    }
}
