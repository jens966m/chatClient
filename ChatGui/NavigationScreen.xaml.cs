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

namespace ChatGui
{
    /// <summary>
    /// Interaction logic for NavigationScreen.xaml
    /// </summary>
    public partial class NavigationScreen : Window
    {
        ServerFacade serverFacade;
        string chatName;

        
        public NavigationScreen(ServerFacade serverFacade)
        {
            this.serverFacade = serverFacade;
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            serverFacade.Dispose();
            MainWindow maninWindow = new MainWindow();
            maninWindow.Show();
        }

        private void chatButton_Click(object sender, RoutedEventArgs e)
        {
            chatName = chatNameBox.Text;
            this.Hide();
            ChatWindow chatWindow = new ChatWindow(serverFacade,chatName);
            chatWindow.Show();
        }

        private void auktionButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AuktionWindow auktionWindow = new AuktionWindow(serverFacade,chatNameBox.Text);
            auktionWindow.Show();

        }
    }
}
