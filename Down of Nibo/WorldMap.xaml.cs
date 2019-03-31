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
    /// Interakční logika pro WorldMap.xaml
    /// </summary>
    public partial class WorldMap : Page
    {
        public WorldMap()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 2;
        }
        private void Button_Inventory(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 7;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GameFileHandle.SaveGame();
            Globals.Scene = 4;
        }
    }
}
