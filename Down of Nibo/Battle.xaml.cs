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
using WpfAnimatedGif;
using System.Windows.Threading;

namespace Down_of_Nibo
{
    /// <summary>
    /// Interakční logika pro Battle.xaml
    /// </summary>
    public partial class Battle : Page
    {
        List<ProgressBar> MobHealth = new List<ProgressBar>(); // try to bind later
        List<Image> MobGif = new List<Image>();
        List<Image> MobImage = new List<Image>();
        public Battle()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            GenerateBattle();
            GetTimerSpeed();
        }
        public void GenerateBattle()
        {
        
            Globals.Mobs[0] = new Mob();
            
            Globals.Mobs[2] = new Mob();
        
            
           
            MobHealth.Add(Mob1_Health);
            MobHealth.Add(Mob2_Health);
            MobHealth.Add(Mob3_Health);

            MobGif.Add(Mob1_Gif);
            MobGif.Add(Mob2_Gif);
            MobGif.Add(Mob3_Gif);

            MobImage.Add(Mob1_IMG);
            MobImage.Add(Mob2_IMG);
            MobImage.Add(Mob3_IMG);


            

            for ( int i = 0 ; i < 3 ; i++ )
            {
                if(Globals.Mobs[i] is null)
                {
                    
                }
                else {
                MobHealth[i].Value = Globals.Mobs[i].Stats.HP;


                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(Globals.Mobs[i].GifPath_Idle, UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(MobGif[i], image);

                MobImage[i].Source = new BitmapImage(new Uri(Globals.Mobs[i].ImgPath, UriKind.Relative));
                }
            }

            Player_Health.Value = Globals.Player.Stats.HP;

            

        }
        public void GetTimerSpeed()
        {
            int BaseLimit = 450;
            int MobSpeed =0;
            for (int i = 0; i < 3; i++)
            {
                if (Globals.Mobs[i] is null)
                {

                }
                else
                {
                    MobSpeed = MobSpeed + Globals.Mobs[i].GetFullStats(Globals.Mobs[i]).speed;
                }
            }
            MobSpeed = MobSpeed * 10;
            int PlayerSpeed = Globals.Player.GetFullStats(Globals.Player).speed * 10;

            if(MobSpeed > PlayerSpeed)
            {
                BaseLimit = BaseLimit - MobSpeed;
                if (BaseLimit < 50)
                {
                    BaseLimit = 50;
                }
            }
            else
            {
                BaseLimit = BaseLimit + PlayerSpeed;
            }

            ActionTime.Maximum = BaseLimit;

        }
        void timer_Tick(object sender, EventArgs e)
        {
            
            if (ActionTime.Value >= ActionTime.Maximum)
            {
                ActionTime.Value = 0; // new round
            }
            ActionTime.Value++;
            //test time
        }
    }
}
