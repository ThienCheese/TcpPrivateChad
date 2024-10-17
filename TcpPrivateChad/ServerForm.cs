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
namespace TcpPrivateChad
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private Dictionary<string, TcpClient> connectedClients = new Dictionary<string, TcpClient>();
        private bool shouldStop = false;


        public ServerForm()
        {
            InitializeComponent();
        }
        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            serverThread = new Thread(new ThreadStart(ListenForClients));
            serverThread.Start();
            UpdateLog("Server started...");
        }

        private async void ListenForClients()
        {
            while (!shouldStop)
            {
                TcpClient client = server.AcceptTcpClient();
                Task clientTask = Task.Run(() => HandleClientComm(client));
            }
            serverThread.Abort();
        }

        private async Task HandleClientComm(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];
            int bytesRead;

            string username = "";

            // Handle the first message (username)
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            if (bytesRead > 0)
            {
                username = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                connectedClients[username] = client;
                UpdateLog($"{username} connected.");
            }

            while (!shouldStop && username != null)
            {
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    break; // Client disconnected
                }

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                await HandleMessage(username, message);
            }

            // Clean up on disconnection
            if (username != null)
            {
                connectedClients.Remove(username);
                UpdateLog($"{username} disconnected.");
            }

            client.Close();
        }

        private async Task HandleMessage(string sender, string message)
        {
            if (message.Contains(":"))
            {
                string[] parts = message.Split(':');
                string recipientUsername = parts[0];
                string messageContent = parts[1];

                if (connectedClients.TryGetValue(recipientUsername, out TcpClient recipientClient))
                {
                    string formattedMessage = $"{sender}: {messageContent}";
                    byte[] response = Encoding.UTF8.GetBytes(formattedMessage);
                    await recipientClient.GetStream().WriteAsync(response, 0, response.Length);
                    await recipientClient.GetStream().FlushAsync();
                }
            }
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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            shouldStop = true;
            UpdateLog("Server has stopped.");
            server.Stop();
        }
        private void buttonStop_CLick(object sender, EventArgs e)
        {
            shouldStop = true;
            server.Stop();
        }
    }
}