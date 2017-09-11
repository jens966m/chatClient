using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChatClient;
using System.Threading;

namespace ChatGui
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        ServerFacade serverFacade;
        string chatName;

        public ChatWindow(ServerFacade serverFacade, string chatName)
        {   
            this.chatName = chatName;
            this.serverFacade = serverFacade;

            serverFacade.threadEvent += guiThread_MessageReceive;
            Thread chatThread = new Thread(serverFacade.RecieveFromServer);
            chatThread.Start();

            InitializeComponent();

            
        }

        private void guiThread_MessageReceive(string message)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new ServerFacade.ThreadEventType(guiThread_MessageReceive), message);
                return;
            }
            string[] messagearray = message.Split(',');
            string newMessage = "";
            if (messagearray[0] == "chat") {
                for (int i = 1; i < messagearray.Length; i++) { newMessage += messagearray[i] + " "; }
                showTextBox.AppendText(newMessage + "\r\n");
            }

        }
        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string message;
            message = "chat," + writingBox.Text;
            

            serverFacade.SendToServer(message);

            showTextBox.SelectionStart = showTextBox.Text.Length;
            showTextBox.ScrollToEnd();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            serverFacade.threadEvent -= guiThread_MessageReceive;
            NavigationScreen navScreen = new NavigationScreen(serverFacade);
            navScreen.Show();
             
        }


    }
}
