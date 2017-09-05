using ChatClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ChatGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void connectToButton_Click(object sender, RoutedEventArgs e)
        {

            int port;
            port = int.Parse(portBox.Text);
            string serverName;
            serverName = serverNameBox.Text;

            ServerFacade servicefacade = new ServerFacade(port, serverName);

            NavigationScreen navigationScreen = new NavigationScreen(servicefacade);
            this.Close();
            navigationScreen.Show();
            



        }
    }
}


