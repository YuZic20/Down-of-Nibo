using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Down_of_Nibo
{
    public static class ContentCreator
    {
       public static void NewGame()
        {

        }

        public static void MCDied()
        {
            Globals.learndCombos = new List<Combo>();
            Globals.Player.died();
            GenerateMaps();
            GenerateQuests();
            Globals.Scene = 3;

        }
        public static void GenerateMobs()
        {
            Mob LBandita = new Mob();
            LBandita.GifPath_Attac = @"Assets\sprites\LBandit\Attack.gif";
            LBandita.GifPath_Idle = @"Assets\sprites\LBandit\idle.gif";
            LBandita.ImgPath = @"Assets\sprites\LBandit\bandit_img.jpg";
            LBandita.Name = "Bandita";

            Stats LBanditaStats = new Stats();
            LBanditaStats.Def = 0;
            LBanditaStats.Dmg = 100;
            LBanditaStats.speed = 0;

            LBandita.Stats = LBanditaStats;
            Repository.AllMobs.Add(LBandita);


            Mob HBandita = new Mob();
            HBandita.GifPath_Attac = @"Assets\sprites\HBandit\Attack.gif";
            HBandita.GifPath_Idle = @"Assets\sprites\HBandit\idle.gif";
            HBandita.ImgPath = @"Assets\sprites\HBandit\bandit_img.jpg";
            HBandita.Name = "Bandita expert";

            Stats HBanditaStats = new Stats();
            HBanditaStats.Def = 50;
            HBanditaStats.Dmg = 100;
            HBanditaStats.speed = 50;

            HBandita.Stats = HBanditaStats;
            Repository.AllMobs.Add(HBandita);

            Mob Solder = new Mob();
            Solder.GifPath_Attac = @"Assets\sprites\sold\Attack.gif";
            Solder.GifPath_Idle = @"Assets\sprites\sold\idle.gif";
            Solder.ImgPath = @"Assets\sprites\sold\img.jpg";
            Solder.Name = "Voják";

            Stats SolderStats = new Stats();
            SolderStats.Def = 70;
            SolderStats.Dmg = 200;
            SolderStats.speed = 50;

            Solder.Stats = SolderStats;
            Repository.AllMobs.Add(Solder);

            Mob Hell_Beast = new Mob();
            Hell_Beast.GifPath_Attac = @"Assets\sprites\demon-Files\GIFS\demon-attack.gif";
            Hell_Beast.GifPath_Idle = @"Assets\sprites\demon-Files\GIFS\demon-idle.gif";
            Hell_Beast.ImgPath = @"Assets\sprites\demon-Files\GIFS\demon.png"; 
            Hell_Beast.Name = "Boss";

            Stats Hell_BeastStats = new Stats();
            Hell_BeastStats.Def = 200;
            Hell_BeastStats.Dmg = 300;
            Hell_BeastStats.speed = 200;

            Hell_Beast.Stats = Hell_BeastStats;
            Repository.AllMobs.Add(Hell_Beast);

            Mob Ghoast = new Mob();
            Ghoast.GifPath_Attac = @"Assets\sprites\Ghost-Files\GIFS\ghost-shriek.gif";
            Ghoast.GifPath_Idle = @"Assets\sprites\Ghost-Files\GIFS\ghost-idle.gif";
            Ghoast.ImgPath = @"Assets\sprites\Ghost-Files\GIFS\Ghoast.png";
            Ghoast.Name = "Duch";

            Stats GhoastStats = new Stats();
            GhoastStats.Def = 100;
            GhoastStats.Dmg = 20;
            GhoastStats.speed = 150;

            Ghoast.Stats = GhoastStats;
            Repository.AllMobs.Add(Ghoast);

            Mob AntiHero = new Mob();
            AntiHero.GifPath_Attac = @"Assets\sprites\Gothic-hero-Files\GIFS\gothic-hero-attack.gif";
            AntiHero.GifPath_Idle = @"Assets\sprites\Gothic-hero-Files\GIFS\gothic-hero-idle.gif";
            AntiHero.ImgPath = @"Assets\sprites\Gothic-hero-Files\GIFS\hero.png"; 
            AntiHero.Name = "Padlý hrdina";

            Stats AntiHeroStats = new Stats();
            AntiHeroStats.Def = 200;
            AntiHeroStats.Dmg = 300;
            AntiHeroStats.speed = 100;

            AntiHero.Stats = AntiHeroStats;
            Repository.AllMobs.Add(AntiHero);

            Mob Demon = new Mob();
            Demon.GifPath_Attac = @"Assets\sprites\Hell-Beast-Files\GIF\without-stroke\hell-beast-breath.gif";
            Demon.GifPath_Idle = @"Assets\sprites\Hell-Beast-Files\GIF\without-stroke\hell-beast-idle.gif";
            Demon.ImgPath = @"Assets\sprites\Hell-Beast-Files\GIF\without-stroke\Demon.png"; 
            Demon.Name = "Démon";

            Stats DemonStats = new Stats();
            DemonStats.Def = 200;
            DemonStats.Dmg = 100;
            DemonStats.speed = 300;

            Demon.Stats = DemonStats;
            Repository.AllMobs.Add(Demon);

        }
        public static void GenerateQuests()
        {
            //poslední quest nejde, přidat null exeption

            List<Quest> quests = new List<Quest>();
            Globals.Quests[0] = quests;

            Quest quest = new Quest();
            quest.decription = "kill em alll1";

            Mob mob = new Mob();
            mob.Stats.Dmg = 5;
            quest.Mobs[1] = mob;           

            //Globals.Quests[0].Add(quest);



            Quest quest1 = new Quest();
            quest1.decription = "kill em alll2";

            Mob mob2 = new Mob();
            mob2.Stats.Dmg = 5;
            quest1.Mobs[1] = mob2;

            Item item2 = new Item();
            item2.Name = "Combo";
            quest1.Reward = item2;

            Globals.Quests[0].Add(quest1);

            Quest quest2 = new Quest();
            quest2.decription = "kill em alll3";

            Mob mob3 = new Mob();
            mob3.Stats.Dmg = 5;
            quest2.Mobs[1] = mob3;

            Item item3 = new Item();
            item3.Name = "Last Training";
            quest2.Reward = item3;

            Globals.Quests[0].Add(quest2);

            Quest quest4 = new Quest();
            quest4.decription = "kill em alll4";

            Mob mob4 = new Mob();
            mob4.Stats.Dmg = 5;
            quest4.Mobs[1] = mob4;

            Item item4 = new Item();
            item4.Name = "Last Training";
            quest4.Reward = item3;

            Globals.Quests[0].Add(quest4);
            Globals.Quests[0].Add(quest4);



        }
        public static void GenerateContent()
        {
            GenerateQuests();
            GenerateCombos();
        }
        public static void GenerateCombos()
        {

            Combo combo = new Combo();
            combo.BaseDifficlty = 0;
            combo.Description = "Oheň";
            Stats stats = new Stats();
            stats.Def = 0;
            stats.dex = 0;
            stats.Dmg = 0;
            stats.HP = 100;
            stats.speed = 0;
            stats.str = 0;

            combo.BaseStats = stats;
            combo.Name = "nwm";

            Effect_Duration effect_Duration = new Effect_Duration();
            effect_Duration.Description = "uff";
            effect_Duration.Duration = 1;
            effect_Duration.FixedStats = stats;
            effect_Duration.MStats = stats;
            effect_Duration.Name = "ufff";

            combo.Effects.Add(effect_Duration);

            Repository.AllCombos.Add(combo);
            

        }
        public static void GenerateEffects()
        {



        }
        public static void GenerateItems()
        {
            
            


        }
        public static void GenerateMaps()
        {
            Globals.regionMaps[0] = new RegionMap();
            Globals.regionMaps[1] = new RegionMap();
            Globals.regionMaps[2] = new RegionMap();


            BitmapImage BackImageSource = new BitmapImage();
            BackImageSource.BeginInit();
            BackImageSource.UriSource = new Uri(@"Assets\Img\fantasy_map3.png", UriKind.Relative);
            BackImageSource.EndInit();
            Globals.regionMaps[0].RegionMapImage.Source = BackImageSource;

            BackImageSource = new BitmapImage();
            BackImageSource.BeginInit();
            BackImageSource.UriSource = new Uri(@"Assets\Img\fantasy_map1.png", UriKind.Relative);
            BackImageSource.EndInit();
            Globals.regionMaps[1].RegionMapImage.Source = BackImageSource;

            BackImageSource = new BitmapImage();
            BackImageSource.BeginInit();
            BackImageSource.UriSource = new Uri(@"Assets\Img\fantasy_map2.png", UriKind.Relative);
            BackImageSource.EndInit();
            Globals.regionMaps[2].RegionMapImage.Source = BackImageSource;


        }
    }
}
