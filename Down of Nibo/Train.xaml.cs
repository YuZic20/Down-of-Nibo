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
using System.Windows.Threading;

namespace Down_of_Nibo
{
    /// <summary>
    /// Interakční logika pro Train.xaml
    /// </summary>
    public partial class Train : Page
    {
        int Xp = 0;
        int Lvl = 1;
        int Strike = 0;
        List<int> ComboClip = new List<int>();
        List<int> ComboToCopy = new List<int>();

        int KeyDownCombo = 50;
        public Train()
        {
            InitializeComponent();
            Globals.AddTimer();
            GetTimerSpeed();
            GenerateCombo();
            Lvl = 1;
            DispatcherTimer timer = new DispatcherTimer(); //když je myš na okně čas se seká
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        public void GetTimerSpeed()
        {
            int BaseLimit = 300;

            int LimitToReturn = BaseLimit - Lvl*20;

            

            ActionTime.Maximum = LimitToReturn;

            TestSpace.Content = "Xp: " + Xp + "   Lvl: " + Lvl;
            Xp++;

            if(Xp == 2)
            {
                Xp = 0;
                Lvl++;
                
            }
            
        }
        void timer_Tick(object sender, EventArgs e)
        {

            if (ActionTime.Value >= ActionTime.Maximum)
            {
                ActionTime.Value = 0; // new round

                if (!CheckAndExecuteComboClip())
                {
                    Strike++;
                    
                    
                }
                if(Strike == 3)
                {
                    //end
                    Results();
                }

                GenerateCombo();


                GetTimerSpeed();
                
                


            }
            ActionTime.Value++;
            PrintComboClip();
            PrintComboToCopyClip();
            //tests.Content = ActionTime.Value + "/" + ActionTime.Maximum; //debug
            if (((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Space) || Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.D)) && KeyDownCombo > 5))
            {
                KeyPressHandle();
            }
            else
            {
                
                if (KeyDownCombo <= 20)
                {
                    KeyDownCombo++;
                }


            }


        }
        public void KeyPressHandle()
        {

               
            if (Keyboard.IsKeyDown(Key.A))
            {
                ComboClip.Add(0);
                KeyDownCombo = 0;
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                ComboClip.Add(1);
                KeyDownCombo = 0;
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                ComboClip.Add(2);
                KeyDownCombo = 0;
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                ComboClip.Add(3);
                KeyDownCombo = 0;
            }
            

        }
        public bool CheckAndExecuteComboClip()
        {
            
            if (ComboClip.Count() == 0)
            {
                ComboClip.Clear();
                return false;
            }
          
            if (ComboToCopy.Count() != ComboClip.Count())
            {
                ComboClip.Clear();
                return false;
            }

            if (ComboClip.SequenceEqual(ComboToCopy))
            {
                ComboClip.Clear();
                return true;
            }
            else
            {
                ComboClip.Clear();
                return false;
            }                     

        }
        public void PrintComboClip()
        {
            ComboPress.Content = "";
            foreach (int KeyCode in ComboClip)
            {
                if (KeyCode == 0)
                {
                    ComboPress.Content += " A";
                }
                else if (KeyCode == 1)
                {
                    ComboPress.Content += " W";
                }
                else if (KeyCode == 2)
                {
                    ComboPress.Content += " S";
                }
                else if (KeyCode == 3)
                {
                    ComboPress.Content += " D";
                }
                
            }
        }
        public void PrintComboToCopyClip()
        {
            ComboToCopyVisual.Content = "";
            foreach (int KeyCode in ComboToCopy)
            {
                if (KeyCode == 0)
                {
                    ComboToCopyVisual.Content += " A";
                }
                else if (KeyCode == 1)
                {
                    ComboToCopyVisual.Content += " W";
                }
                else if (KeyCode == 2)
                {
                    ComboToCopyVisual.Content += " S";
                }
                else if (KeyCode == 3)
                {
                    ComboToCopyVisual.Content += " D";
                }
                
            }
        }
        public void GenerateCombo()
        {
            ComboToCopy.Clear();
            Random rand = new Random();
            int SizeOfCombo = 4;

            SizeOfCombo = SizeOfCombo + rand.Next(3);

            for (int i = 0; i < SizeOfCombo; i++)
            {
                ComboToCopy.Add(rand.Next(4));
            }
        }
        public void Results()
        {
            
            Globals.Training.Def = Globals.Training.Def * (Lvl/2);
            Globals.Training.dex = Globals.Training.dex * (Lvl / 2);
            Globals.Training.speed = Globals.Training.speed * (Lvl / 2);
            Globals.Training.HP = Globals.Training.HP * (Lvl / 2);
            Globals.Training.Dmg = Globals.Training.Dmg * (Lvl / 2);
            Globals.Training.str = Globals.Training.str * (Lvl / 2);

            Globals.Player.AddStats(Globals.Training);

            Globals.Training = new ClassLibrary2.Stats();

            Globals.Scene = 3;

            //end here
        }









    }
}
