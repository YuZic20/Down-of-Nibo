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
using System.Windows.Media.Animation;

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
            var image2 = new BitmapImage();
            image2.BeginInit();
            image2.UriSource = new Uri(Globals.Player.GifPath_Idle, UriKind.Relative);
            image2.EndInit();
            ImageBehavior.SetAnimatedSource(Player_Gif, image2);
            

            Player_Health.Value = Globals.Player.Stats.HP;

            

        }
        public void GetTimerSpeed()
        {
            int BaseLimit = 300;
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
                Globals.Player = AiAttacs(Globals.Player, MobAttacValue());
                UpdateHpBar();
                playerAttacVisual();
            }
            ActionTime.Value++;
            tests.Content = ActionTime.Value + "/" + ActionTime.Maximum; //debug
            
            
        }
        public int MobAttacValue()
        {
            int attac = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Globals.Mobs[i] is null)
                {

                }
                else
                {
                    attac = Globals.Mobs[i].GetFullStats(Globals.Mobs[i]).Dmg + attac;
                }
            }
            return attac;
        }
        
        public Character AiAttacs(Character Player, int DMG)
        {
            int givendimg = 0;
            Random rand = new Random();
            int CritChance = rand.Next(100);
            if(CritChance < 15)
            {
                givendimg = Player.GetFullStats(Player).Def - DMG * 2;
            }else if(CritChance > 75)
            {
                givendimg = Player.GetFullStats(Player).Def - DMG /2;
            }
            else
            {
                givendimg = Player.GetFullStats(Player).Def - DMG;
            }

            if (givendimg < 0)
            {
                Player.Stats.HP = Player.Stats.HP + givendimg;
            }
            MobAttacVisual();
            return Player;
        }
        public void MobAttacVisual()
        {

            for (int i = 0; i < 3; i++)
            {
                if (Globals.Mobs[i] is null)
                {

                }
                else
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(Globals.Mobs[i].GifPath_Attac, UriKind.Relative);
                    image.EndInit();
                    ImageBehavior.SetAnimatedSource(MobGif[i], image);
                    ImageBehavior.SetRepeatBehavior(MobGif[i], new RepeatBehavior(1));



                }
            }

        }

        public int playerAttacVisual()
        {
            int attac = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Globals.Mobs[i] is null)
                {

                }
                else
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(Globals.Player.GifPath_Attac, UriKind.Relative);
                    image.EndInit();
                    ImageBehavior.SetAnimatedSource(Player_Gif, image);
                    ImageBehavior.SetRepeatBehavior(Player_Gif, new RepeatBehavior(1));



                }
            }
            return attac;
        }
        

        public void UpdateHpBar()
        {
            Player_Health.Value = Globals.Player.Stats.HP;
            for (int i = 0; i < 3; i++)
            {
                if (Globals.Mobs[i] is null)
                {

                }
                else
                {
                    MobHealth[i].Value = Globals.Mobs[i].Stats.HP;

                }
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            //doo keypress
        }
        private void AnimationCompleted(object sender, System.EventArgs e)
        {

            //reset to idle
            var image = new BitmapImage();
            Image SenderImg = (Image)sender;
            if (Equals(SenderImg.Name, "Mob1_Gif"))
            {
                image.BeginInit();
                image.UriSource = new Uri(Globals.Mobs[0].GifPath_Idle, UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(MobGif[0], image);
                ImageBehavior.SetRepeatBehavior(MobGif[0], RepeatBehavior.Forever);
            }
            else if (Equals(SenderImg.Name, "Mob2_Gif"))
            {
                image.BeginInit();
                image.UriSource = new Uri(Globals.Mobs[1].GifPath_Idle, UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(MobGif[1], image);
                ImageBehavior.SetRepeatBehavior(MobGif[1], RepeatBehavior.Forever);
            }
            else if (Equals(SenderImg.Name, "Mob3_Gif"))
            {
                image.BeginInit();
                image.UriSource = new Uri(Globals.Mobs[2].GifPath_Idle, UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(MobGif[2], image);
                ImageBehavior.SetRepeatBehavior(MobGif[2], RepeatBehavior.Forever);
            }
            else
            {
                image.BeginInit();
                image.UriSource = new Uri(Globals.Player.GifPath_Idle, UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(Player_Gif, image);
                ImageBehavior.SetRepeatBehavior(Player_Gif, RepeatBehavior.Forever);
            }


        }
    }
}
