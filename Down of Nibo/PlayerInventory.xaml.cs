using ClassLibrary2;
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
    /// Interakční logika pro PlayerInventory.xaml
    /// </summary>
    public partial class PlayerInventory : Page
    {
        int SelectedItem =0;
        public PlayerInventory()
        {
            InitializeComponent();
            PrintItems();
            

        }
        public void PrintItem(Item ItemToPrint)
        {
            if(ItemToPrint == null)
            {
                ItemName.Content = "";
                ItemType.Content = "";
                ItemEffects.Children.Clear();

                return;
            }
            ItemName.Content = ItemToPrint.Name;

            if (ItemToPrint.usable)
            {
                ItemType.Content = "Item dá použít";
            }else if (ItemToPrint.Eqip == 1)
            {
                ItemType.Content = "Item dá obléknout na nohy";
            }
            else if (ItemToPrint.Eqip == 2)
            {
                ItemType.Content = "Item dá obléknout na tělo";
            }
            else if (ItemToPrint.Eqip == 3)
            {
                ItemType.Content = "Item dá použít jako zbraň";
            }



            ItemEffects.Children.Clear();
            foreach(AEffect effect in ItemToPrint.Efects)
            {
                Label labelName = new Label();
                Label labelDes = new Label();
                labelName.Content = effect.Name;
                ItemEffects.Children.Add(labelName);

                labelDes.Content = effect.Description;

                ItemEffects.Children.Add(labelDes);
            }
            
        }
        public void PrintItems()
        {
            if(Globals.Player.Eqiped.Body is null)
            {
                Body.Content = "Nic";
                Body.Tag = null;
            }
            else
            {
                Body.Content = Globals.Player.Eqiped.Body.Name;
            }
            if (Globals.Player.Eqiped.Shoes is null)
            {
                Shoes.Content = "Nic";
                Shoes.Tag = null;
            }
            else
            {
                Shoes.Content = Globals.Player.Eqiped.Shoes.Name;
            }
            if (Globals.Player.Eqiped.Weapon is null)
            {
                Weapon.Content = "Nic";
                Weapon.Tag = null;
            }
            else
            {
                Weapon.Content = Globals.Player.Eqiped.Weapon.Name;
            }

            ItemsList.Children.Clear();
            for(int i =0; i> Globals.Player.Inventory.items.Count();i++)
            {
                Button button = new Button();
                button.Content = Globals.Player.Inventory.items[i].Name;
                button.Tag = i;
                button.Click += Button_Click;
                ItemsList.Children.Add(button);
            }
            PrintPlayerStats();

        }

        private void Body_Click(object sender, RoutedEventArgs e)
        {
           
            PrintItem(Globals.Player.Eqiped.Body);
            SelectedItem = 1;
        }

        private void Shoes_Click(object sender, RoutedEventArgs e)
        {
            PrintItem(Globals.Player.Eqiped.Shoes);
            SelectedItem = 2;
        }

        private void Weapon_Click(object sender, RoutedEventArgs e)
        {
            PrintItem(Globals.Player.Eqiped.Weapon);
            SelectedItem = 3;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            PrintItem(Globals.Player.Inventory.items[(int)button.Tag]);
            SelectedItem = 4;
            Action.Tag = (int)button.Tag;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (SelectedItem == 1)
            {
                Globals.Player.Inventory.items.Add(Globals.Player.Eqiped.Body);
                Globals.Player.Eqiped.Body = null;
                SelectedItem = 0;
            }
            else if(SelectedItem == 2)
            {
                Globals.Player.Inventory.items.Add(Globals.Player.Eqiped.Shoes);
                Globals.Player.Eqiped.Shoes = null;
                SelectedItem = 0;
            }
            else if (SelectedItem == 3)
            {
                Globals.Player.Inventory.items.Add(Globals.Player.Eqiped.Weapon);
                Globals.Player.Eqiped.Weapon = null;
                SelectedItem = 0;
            }
            else if (SelectedItem == 4)
            {
                if (Globals.Player.Inventory.items[(int)button.Tag].Eqip == 1)
                {
                    Globals.Player.Eqiped.Body = Globals.Player.Inventory.items[(int)button.Tag];
                    Globals.Player.Inventory.items.RemoveAt((int)button.Tag);
                }
                else if (Globals.Player.Inventory.items[(int)button.Tag].Eqip == 2)
                {
                    Globals.Player.Eqiped.Shoes = Globals.Player.Inventory.items[(int)button.Tag];
                    Globals.Player.Inventory.items.RemoveAt((int)button.Tag);
                }
                else if (Globals.Player.Inventory.items[(int)button.Tag].Eqip == 3)
                {
                    Globals.Player.Eqiped.Weapon = Globals.Player.Inventory.items[(int)button.Tag];
                    Globals.Player.Inventory.items.RemoveAt((int)button.Tag);
                }
                else if (Globals.Player.Inventory.items[(int)button.Tag].usable)
                {
                    Globals.Player.efects.AddRange(Globals.Player.Inventory.items[(int)button.Tag].Efects);
                    Globals.Player.Inventory.items.RemoveAt((int)button.Tag);
                }
            }
            
            PrintItem(null);
            PrintItems();
            
        }
        private void Button_Inventory(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 3;
        }
        public void PrintPlayerStats()
        {
            Stats playerRealStats = Globals.Player.GetFullStats(Globals.Player);

            Hp.Content = "Životy: " + playerRealStats.HP;
            Speed.Content = "Ryclost: " + playerRealStats.speed;
            Def.Content = "Ochrana: " + playerRealStats.Def;
            DMG.Content = "Síla: " + playerRealStats.Dmg;

        }
    }
}
