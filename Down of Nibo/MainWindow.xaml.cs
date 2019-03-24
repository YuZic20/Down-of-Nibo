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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int cislo { get; set; } = 5;
        public MainWindow()
        {
            InitializeComponent();
            Battle battle = new Battle();
            Train Training = new Train();
            MainWindowFrame.Content = Training;
        }
    }
}
