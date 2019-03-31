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

namespace Down_of_Nibo
{
    /// <summary>
    /// Interakční logika pro MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            if (GameFileHandle.CanLoadGame())
            {
                Resume_Game.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentCreator.GenerateMaps();
            ContentCreator.GenerateContent();
            // content generate
            Dificlty.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameFileHandle.LoadGame();
            Globals.Scene = 3;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //lehká
            Globals.Turns = 50;
            Globals.Scene = 3;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //střední
            Globals.Turns = 25;
            Globals.Scene = 3;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //těžka
            Globals.Turns = 10;
            Globals.Scene = 3;
        }
    }
}
