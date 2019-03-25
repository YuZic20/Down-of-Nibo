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

            string RewardName;
            if(Globals.Quests[Globals.Scene][0].Reward is null)
            {
                RewardName = "Cvičení";
            }
            else
            {
                RewardName = Globals.Quests[Globals.Scene][0].Reward.Name;
            }
            
            Descripion.Text = Globals.Quests[Globals.Scene][0].decription;
            Reward.Content = "Odměna: " + RewardName;
            QestInfo.Visibility = Visibility.Visible;
        }

        

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {

            Globals.Scene = 3;
        }

        private void Button_Click_Accept(object sender, RoutedEventArgs e)
        {
            if (Globals.Quests[Globals.Scene][0].Reward is null)
            {
                if (Globals.Scene == 0) { Globals.Traing.Def = 10; } else { Globals.Traing.Def = 0; }
                Globals.Traing.dex = 0;
                if (Globals.Scene == 1) { Globals.Traing.speed = 10; } else { Globals.Traing.speed = 0; }
                Globals.Traing.HP = 0;
                if (Globals.Scene == 1) { Globals.Traing.Dmg = 10; } else { Globals.Traing.Dmg = 0; }
                Globals.Traing.str = 0;

                Globals.Scene = 6;
            }
            else
            {
                Globals.Quests[Globals.Scene][0].StartBattle();
                Globals.Player.Inventory.items.Add(Globals.Quests[Globals.Scene][0].Reward);
                Globals.Quests[Globals.Scene].RemoveAt(0);
                Globals.Scene = 5;
            }
        }
        private void Button_Click_Reject(object sender, RoutedEventArgs e)
        {
            QestInfo.Visibility = Visibility.Hidden;
        }
    }
}
