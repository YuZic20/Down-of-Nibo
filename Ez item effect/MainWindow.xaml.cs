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
        List<Button> Item_Buttons = new List<Button>();
        Item SelectedItem;
        public List<AEffect> AllEffects { get; set; }
        public List<Item> AllItems { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            AllEffects = fileHandle.LoadDataEfect();
            AllItems = fileHandle.LoadDataItem();
            PrintItems(AllItems);

        }
        public void DefalutColor()
        {
            foreach (Button button in ItemButtons.Children)
            {
                button.Background = Brushes.Gray;
            }
        }
        public void PrintItems(List<Item> items)
        {
            ItemButtons.Children.Clear();
            foreach(Item item in items)
            {
                Button ItemButton = new Button();
                ItemButton.Height = 20;
                ItemButton.Content = item.Name;
                ItemButton.Tag = item;
                ItemButton.Background = Brushes.Gray;
                //color
                ItemButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(ItemButton_Click));
                ItemButtons.Children.Add(ItemButton);
            }
        }
        public void PrintEffects( List<AEffect> aEffects, Item BaseItem)
        {
            EffectsChecks.Children.Clear();
            foreach (AEffect effect in aEffects)
            {

                

                Button ItemButton = new Button();
                ItemButton.Height = 20;
                ItemButton.Content = effect.Name;
                ItemButton.Tag = effect;
                ItemButton.Background = Brushes.Gray;
                //color
                ItemButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(ItemEffect_Click));

                if (BaseItem.Efects.Count() != 0)
                {
                    for (int i = 0; i < BaseItem.Efects.Count(); i++)
                    {
                        if (BaseItem.Efects[i].Description.Equals(effect.Description))
                        {
                            ItemButton.Background = Brushes.Orange;
                        }
                    }
                }
                

                EffectsChecks.Children.Add(ItemButton);
            }
        }


        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            DefalutColor();
            Button ItemSender = (Button)sender;
            ItemSender.Background = Brushes.Orange;
            SelectedItem = (Item)ItemSender.Tag;//obarvit
            PrintEffects(AllEffects, SelectedItem);
            
        }

        private void ItemEffect_Click(object sender, RoutedEventArgs e)
        {
            bool removed = false;
           
            Button ItemSender = (Button)sender;
            

            AEffect effect = (AEffect)ItemSender.Tag;


            if (SelectedItem.Efects.Count() != 0)
            {
                for (int i = 0; i < SelectedItem.Efects.Count(); i++)
                {
                    if (SelectedItem.Efects[i].Description.Equals(effect.Description))
                    {
                        SelectedItem.Efects.RemoveAt(i);
                        removed = true;
                    }
                    
                }
            }
            if (!removed)
            {
                SelectedItem.Efects.Add((AEffect)ItemSender.Tag);

            }
            fileHandle.SaveData(AllItems);
            PrintEffects(AllEffects, SelectedItem);

        }
    }
}
