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
using ClassLibrary2;

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
        List<int> ComboClip = new List<int>();
        int KeyDownSelect = 50;
        int KeyDownCombo = 50;
        public Battle()
        {
            InitializeComponent();
            Globals.AddTimer();
            DispatcherTimer timer = new DispatcherTimer(); //když je myš na okně čas se seká
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            GenerateBattle();
            GetTimerSpeed();

            /* test combo
            Combo combo = new Combo();
            combo.ComboCode.Add(1);
            combo.ComboCode.Add(1);
            combo.ComboCode.Add(1);
            combo.ComboCode.Add(1);
            Effect_Duration effect = new Effect_Duration();
            effect.Duration = 2;
            effect.Name = "ufff";
            effect.FixedStats.HP = 20;
            effect.MStats.HP = 0;
            combo.Effects.Add(effect);
            Globals.Player.Stats.Def = 5;

            Globals.leaarndCombos.Add(combo);
            */
        }
        public void GenerateBattle()
        {
            
            
        
            
           
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
                ExecuteComboClip();
                MobEffectRound();
                PlayerEffectRound();
                Globals.Player = AiAttacs(Globals.Player, MobAttacValue());
                UpdateHpBar();
                RemoveDeadMobs();
                if (isPlayerDead())
                {
                    //game Over
                    ContentCreator.MCDied();
                    Globals.battle = null;
                }
                else if (AreMobsDead())
                {
                    //ecunter won
                    Globals.Scene = 3;
                    Globals.battle.
                }
                GetTimerSpeed();
                playerAttacVisual();
                MobAttacVisual();

            }
            ActionTime.Value++;
            PrintComboClip();
            tests.Content = ActionTime.Value + "/" + ActionTime.Maximum; //debug
            if (((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Space) || Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.D)) && KeyDownCombo > 5) || ((Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.Down)) && KeyDownSelect>10))
            {
                KeyPressHandle();
            }
            else
            {
                if (KeyDownSelect <= 10)
                {
                    KeyDownSelect++;
                }
                if(KeyDownCombo <= 5)
                {
                    KeyDownCombo++;
                }
                
                
            }


        }
        public void KeyPressHandle()
        {
            
            if (Keyboard.IsKeyDown(Key.Up))
            {
                int selected = GetSelectedMob();
                if (selected == 1)
                {
                    System.Windows.Controls.Grid.SetRow(SelectedMob, 1);
                    
                }
                else if (selected == 2){
                    System.Windows.Controls.Grid.SetRow(SelectedMob, 3);
                }
                KeyDownSelect = 0;
                
            }
            else if(Keyboard.IsKeyDown(Key.Down))
            {
                int selected = GetSelectedMob();
                if (selected == 0)
                {
                    System.Windows.Controls.Grid.SetRow(SelectedMob, 3);
                }
                else if (selected == 1)
                {
                    System.Windows.Controls.Grid.SetRow(SelectedMob, 5);
                }
                KeyDownSelect = 0;
            }
            else if (Keyboard.IsKeyDown(Key.A))
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
            else if (Keyboard.IsKeyDown(Key.Space))
            {
                ComboClip.Add(-1);
                KeyDownCombo = 0;
            }

        }
        public void ExecuteComboClip()
        {
            if(ComboClip.Count() == 0)
            {
                return;
            }

            Combo ComboToUse = new Combo();
            bool OnSelf = false;
            if(ComboClip.Last() == -1)
            {
                OnSelf = true;
                ComboClip.RemoveAt(ComboClip.Count()-1);
            }
            foreach(Combo ComboCodes in Globals.learndCombos)
            {
                if (ComboClip.SequenceEqual(ComboCodes.ComboCode))
                {
                    ComboToUse = ComboCodes;
                    
                    
                }
            }

            if(ComboToUse.ComboCode.Count() == 0)
            {
                ComboClip.Clear();
                return;
            }


            foreach (Effect_Duration stats in ComboToUse.Effects)
            {
                if (stats.FixedStats.HP > 0)
                {
                    stats.FixedStats.HP += Globals.Player.GetFullStats(Globals.Player).Dmg;
                }
            }


            if (OnSelf)
            {
                Globals.Player.efects.AddRange(ComboToUse.Effects);
            }
            else
            {
                //get target
                int SelectedMob = GetSelectedMob();
                Mob Target;
                if (Globals.Mobs[SelectedMob] is null == false)
                {
                    Target = Globals.Mobs[SelectedMob];
                }
                else if (Globals.Mobs[0] is null == false)
                {
                    Target = Globals.Mobs[0];
                }
                else if (Globals.Mobs[1] is null == false)
                {
                    Target = Globals.Mobs[1];
                }
                else
                {
                    Target = Globals.Mobs[2];
                }

                //edit efects, add effects to give dmg and stuff
                Target.efects.AddRange(ComboToUse.Effects);
            }
            

            ComboClip.Clear();


        }
        public void MobEffectRound()
        {
            foreach (Mob mob in Globals.Mobs)
            {
                if(mob is null)
                {

                }
                else
                {
                    mob.OneRound();
                }
                
            }
        }
        public void PlayerEffectRound()
        {
            Globals.Player.OneRound();
        }
        public bool AreMobsDead()
        {
            int strike = 0;
            for (int i = 0; i < 3; i++)
            {

                if (Globals.Mobs[i] is null)
                {
                    strike++;
                }
            }
            if (strike == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isPlayerDead()
        {
            if(Globals.Player.Stats.HP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RemoveDeadMobs()
        {
            for(int i = 0; i < 3; i++)
            {
                
                if (Globals.Mobs[i] is null)
                {

                }
                else
                {
                    if (Globals.Mobs[i].Stats.HP <= 0)
                    {
                        Globals.Mobs[i] = null;
                        var image = new BitmapImage();
                        image.BeginInit();
                        image.UriSource = new Uri(@"Assets\sprites\Ghoast.gif", UriKind.Relative);
                        image.EndInit();
                        ImageBehavior.SetAnimatedSource(MobGif[i], image);
                    }
                }

                
            }
        }
        public void PrintComboClip()
        {
            ComboPress.Content = "";
            foreach(int KeyCode in ComboClip)
            {
                if(KeyCode == 0)
                {
                    ComboPress.Content += " A";
                }else if (KeyCode == 1)
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
                else if(KeyCode == -1)
                {
                    ComboPress.Content += " Cast On Self";
                }
            }
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

        
        public int GetSelectedMob()
        {
            if(System.Windows.Controls.Grid.GetRow(SelectedMob) == 1)
            {
                return 0;
            }else if(System.Windows.Controls.Grid.GetRow(SelectedMob) == 3)
            {
                return 1;
            }
            else
            {
                return 2;
            }
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
