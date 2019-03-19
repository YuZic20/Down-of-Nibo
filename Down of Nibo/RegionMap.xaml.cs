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
    /// Interakční logika pro Map.xaml
    /// </summary>
    public partial class RegionMap : Page
    {
        
        public RegionMap()
        {
            InitializeComponent();
        }
        public void AddButton(Button button)
        {
            Buttons.Children.Add(button);
        }
        public void DeleteButtonByName(string name)
        {
            Buttons.Children.Remove((UIElement)this.FindName(name));
        }

        private void Button_Click_Action(object sender, RoutedEventArgs e)
        {
            //aktivace qestů
        }
    }
}
