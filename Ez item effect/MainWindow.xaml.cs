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
using ClassLibrary2;

namespace Ez_item_effect
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassLibrary2.FileHandle fileHandle = new FileHandle();
        List<Button> ItemButtons = new List<Button>();
        Item SelectedItem;
        
        public MainWindow()
        {
            InitializeComponent();
            List<AEffect> AllEffects = fileHandle.LoadDataEfect();
            List<Item> AllItems = fileHandle.LoadDataItem();

        }
        public void PrintItems(List<Item> items)
        {
            foreach(Item item in items)
            {
                Button ItemButton = new Button();
                ItemButton.Height = 20;
                ItemButton.Content = item.Name;
                ItemButton.Tag = item;
                //color
                ItemButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(ItemButton_Click));
            }
        }
        public void PrintEffects( List<AEffect> aEffects)
        {

        }

        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button ItemSender = (Button)sender;
            SelectedItem = (Item)ItemSender.Tag;//obarvit
        }
    }
}
