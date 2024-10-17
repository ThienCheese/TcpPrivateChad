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
using System.Security.Cryptography.X509Certificates;

namespace Client
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private NetworkStream clientStream;
        private Thread clientThread;

        public ClientForm()
        {
            InitializeComponent();
        }
        private void ConnectToServer()
        {
            client = new TcpClient("127.0.0.1", 5000);
            clientStream = client.GetStream();

            string username = textBoxUsername.Text;
            byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
            clientStream.Write(usernameBytes, 0, usernameBytes.Length);
            clientStream.Flush();

            clientThread = new Thread(new ThreadStart(ListenForMessages));
            clientThread.Start();
            UpdateLog("Connected to server...");
        }

        private void ListenForMessages()
        {
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = clientStream.Read(message, 0, message.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                string msg = Encoding.UTF8.GetString(message, 0, bytesRead);
                UpdateLog(msg);
            }
        }

        private void SendMessage(string message)
        {
            string senderUsername = textBoxUsername.Text;
            string recipientUsername = textBoxRecipient.Text;
            string formattedMessage = recipientUsername + ":" + message;
            byte[] buffer = Encoding.UTF8.GetBytes(formattedMessage);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            textBoxLog.AppendText("You: " + message + Environment.NewLine);
            textBoxMessage.Clear();
        }

        private void UpdateLog(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateLog), message);
                return;
            }

            textBoxLog.AppendText(message + Environment.NewLine);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessage(textBoxMessage.Text);
            textBoxMessage.Clear();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }
    }
}