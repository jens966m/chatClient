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
    /// Interaction logic for AuktionWindow.xaml
    /// </summary>
    public partial class AuktionWindow : Window
    {
        ServerFacade serverFacade;
        public AuktionWindow(ServerFacade serverFacade)
        {
            this.serverFacade = serverFacade;
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            NavigationScreen navScreen = new NavigationScreen(serverFacade);
            navScreen.Show();
        }
    }
}
