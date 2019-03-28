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
                if (Globals.Scene == 0) { Globals.Training.Def = 10; } else { Globals.Training.Def = 0; }
                Globals.Training.dex = 0;
                if (Globals.Scene == 1) { Globals.Training.speed = 10; } else { Globals.Training.speed = 0; }
                Globals.Training.HP = 0;
                if (Globals.Scene == 1) { Globals.Training.Dmg = 10; } else { Globals.Training.Dmg = 0; }
                Globals.Training.str = 0;
                QestInfo.Visibility = Visibility.Hidden;
                nextQuest();
                Globals.Scene = 6;
            }
            else if (Globals.Quests[Globals.Scene][0].Reward.Name == "Combo")
            {
                ComboName.Content = Repository.AllCombos[Globals.Quests[Globals.Scene][0].Reward.Eqip].Name;
                ComboDescripion.Text = Repository.AllCombos[Globals.Quests[Globals.Scene][0].Reward.Eqip].Description;
                Repository.AllCombos[Globals.Quests[Globals.Scene][0].Reward.Eqip].GenerateCode(Globals.Player.Stats);
                ComboCode.Content = "";

                foreach (int KeyCode in Repository.AllCombos[Globals.Quests[Globals.Scene][0].Reward.Eqip].ComboCode)
                {
                    if (KeyCode == 0)
                    {
                        ComboCode.Content += " A";
                    }
                    else if (KeyCode == 1)
                    {
                        ComboCode.Content += " W";
                    }
                    else if (KeyCode == 2)
                    {
                        ComboCode.Content += " S";
                    }
                    else if (KeyCode == 3)
                    {
                        ComboCode.Content += " D";
                    }

                }

                Globals.learndCombos.Add(Repository.AllCombos[Globals.Quests[Globals.Scene][0].Reward.Eqip]);

                QestInfo.Visibility = Visibility.Hidden;
                ComboInfo.Visibility = Visibility.Visible;
                Globals.AddTimer();
                Globals.updateTimer();
                nextQuest();


            }
            else if (Globals.Quests[Globals.Scene][0].Reward.Name == "Last Training")
            {
                if (Globals.Scene == 0) { Globals.Training.Def = 50; } else { Globals.Training.Def = 0; }
                Globals.Training.dex = 0;
                if (Globals.Scene == 1) { Globals.Training.speed = 50; } else { Globals.Training.speed = 0; }
                Globals.Training.HP = 0;
                if (Globals.Scene == 1) { Globals.Training.Dmg = 50; } else { Globals.Training.Dmg = 0; }
                Globals.Training.str = 0;
                QestInfo.Visibility = Visibility.Hidden;
                nextQuest();
                Globals.Scene = 6;


                QuestButton.Visibility = Visibility.Hidden;


            }
            else
            {
                Globals.Quests[Globals.Scene][0].StartBattle();
                Globals.Player.Inventory.items.Add(Globals.Quests[Globals.Scene][0].Reward);
                Globals.Quests[Globals.Scene].RemoveAt(0);
                QestInfo.Visibility = Visibility.Hidden;
                nextQuest();
                Globals.Scene = 5;

            }
            
        }
        private void Button_Click_Reject(object sender, RoutedEventArgs e)
        {
            QestInfo.Visibility = Visibility.Hidden;
        }

        private void Button_Click_ComboClose(object sender, RoutedEventArgs e)
        {
            ComboInfo.Visibility = Visibility.Hidden;
        }
        private void nextQuest()
        {
            Globals.Quests[Globals.Scene].RemoveAt(0);
        }
    }
}
