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
    /// Interaction logic for AuktionWindow.xaml
    /// </summary>
    public partial class AuktionWindow : Window
    {
        ServerFacade serverFacade;
        string chatName;
        public AuktionWindow(ServerFacade serverFacade, string chatName)
        {
            this.serverFacade = serverFacade;
            this.chatName = chatName;

            serverFacade.threadEvent += guiThread_MessageReceive;
            Thread AuctionThread = new Thread(serverFacade.RecieveFromServer);
            AuctionThread.Start();

            InitializeComponent();
            serverFacade.SendToServer("StartUp");
        }

        private void guiThread_MessageReceive(string message)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new ServerFacade.ThreadEventType(guiThread_MessageReceive), message);
                return;
            }
            string[] messagearray = message.Split(' ');
            if (messagearray[0] == "bet")
            {
                LastPriceL.Content = messagearray[2];
                HigestBetterL.Content = messagearray[1];
            }

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            serverFacade.threadEvent -= guiThread_MessageReceive;
            NavigationScreen navScreen = new NavigationScreen(serverFacade);
            navScreen.Show();
        }

        private void bidButton_Click(object sender, RoutedEventArgs e)
        {
            string message;
            message = "bet " + chatName + " " + bidBox.Text;


            serverFacade.SendToServer(message);
        }
    }
}
