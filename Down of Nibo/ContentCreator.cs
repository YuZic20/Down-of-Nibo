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

        public static void GenerateContent()
        {

            GenerateEffects();
            GenerateItems();
            GenerateCombos();
            GenerateQuests();

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
            Hell_BeastStats.Def = 650;
            Hell_BeastStats.Dmg = 650;
            Hell_BeastStats.speed = 650;

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
        
        public static void GenerateCombos()
        {

            Combo combo = new Combo();            
            combo.Name = "Seknutí";
            combo.Description = "Sekne lehce nepřítele";
            combo.BaseDifficlty = 3;
            Stats stats = new Stats();
            stats.Def = 50;
            stats.Dmg = 50;
            stats.HP = 0;
            stats.speed = 25;
            stats.dex = 0;            
            stats.str = 0;

            combo.BaseStats = stats; 
            combo.Effects.Add(Repository.AllEffects[10]);
            Repository.AllCombos.Add(combo);

            Combo combo2 = new Combo();
            combo2.Name = "Ochrana";
            combo2.Description = "Přidá lehkou ochranu";
            combo2.BaseDifficlty = 3;
            Stats stats2 = new Stats();
            stats2.Def = 50;
            stats2.Dmg = 50;
            stats2.HP = 0;
            stats2.speed = 25;
            stats2.dex = 0;
            stats2.str = 0;

            combo2.BaseStats = stats2;
            combo2.Effects.Add(Repository.AllEffects[12]);
            Repository.AllCombos.Add(combo2);

            Combo combo3 = new Combo();
            combo3.Name = "Rychlost";
            combo3.Description = "Přidá na rychlosti";
            combo3.BaseDifficlty = 3;
            Stats stats3 = new Stats();
            stats3.Def = 50;
            stats3.Dmg = 50;
            stats3.HP = 0;
            stats3.speed = 50;
            stats3.dex = 0;
            stats3.str = 0;

            combo3.BaseStats = stats3;
            combo3.Effects.Add(Repository.AllEffects[15]);
            Repository.AllCombos.Add(combo3);

            Combo combo4 = new Combo();
            combo4.Name = "Silné ohnivé bodnutí";
            combo4.Description = "Bodne nepřítele a ten začne krvácet a hořet zároveň";
            combo4.BaseDifficlty = 5;
            Stats stats4 = new Stats();
            stats4.Def = 50;
            stats4.Dmg = 150;
            stats4.HP = 0;
            stats4.speed = 55;
            stats4.dex = 0;
            stats4.str = 0;

            combo4.BaseStats = stats4;
            combo4.Effects.Add(Repository.AllEffects[10]);
            combo4.Effects.Add(Repository.AllEffects[9]);
            Repository.AllCombos.Add(combo4);

            Combo combo5 = new Combo();
            combo5.Name = "Aura Ochrany";
            combo5.Description = "Udělá auru která ochrání cíl";
            combo5.BaseDifficlty = 5;
            Stats stats5 = new Stats();
            stats5.Def = 150;
            stats5.Dmg = 50;
            stats5.HP = 0;
            stats5.speed = 75;
            stats5.dex = 0;
            stats5.str = 0;

            combo5.BaseStats = stats5;
            combo5.Effects.Add(Repository.AllEffects[12]);
            combo5.Effects.Add(Repository.AllEffects[14]);
            Repository.AllCombos.Add(combo5);

            Combo combo6 = new Combo();
            combo6.Name = "boost";
            combo6.Description = "prchající pocit rychlosti";
            combo6.BaseDifficlty = 5;
            Stats stats6 = new Stats();
            stats6.Def = 50;
            stats6.Dmg = 50;
            stats6.HP = 0;
            stats6.speed = 125;
            stats6.dex = 0;
            stats6.str = 0;

            combo6.BaseStats = stats6;
            combo6.Effects.Add(Repository.AllEffects[16]);
            Repository.AllCombos.Add(combo6);

            Combo combo7 = new Combo();
            combo7.Name = "Silné Seknutí";
            combo7.Description = "Sekne lehce nepřítele";
            combo7.BaseDifficlty = 7;
            Stats stats7 = new Stats();
            stats7.Def = 100;
            stats7.Dmg = 200;
            stats7.HP = 0;
            stats7.speed = 55;
            stats7.dex = 0;
            stats7.str = 0;

            combo7.BaseStats = stats7;
            combo7.Effects.Add(Repository.AllEffects[10]);
            combo7.Effects.Add(Repository.AllEffects[11]);
            Repository.AllCombos.Add(combo7);

            Combo combo8 = new Combo();
            combo8.Name = "Silná ochrana";
            combo8.Description = "Využije veškerou sílů na jednorázovou ochranu";
            combo8.BaseDifficlty = 7;
            Stats stats8 = new Stats();
            stats8.Def = 200;
            stats8.Dmg = 150;
            stats8.HP = 0;
            stats8.speed = 100;
            stats8.dex = 0;
            stats8.str = 0;

            combo8.BaseStats = stats8;
            combo8.Effects.Add(Repository.AllEffects[12]);
            combo8.Effects.Add(Repository.AllEffects[13]);
            Repository.AllCombos.Add(combo8);

            Combo combo9 = new Combo();
            combo9.Name = "Aura ozáření";
            combo9.Description = "Uživatel se cítí rychlejší o více chráněný";
            combo9.BaseDifficlty = 7;
            Stats stats9 = new Stats();
            stats9.Def = 150;
            stats9.Dmg = 150;
            stats9.HP = 0;
            stats9.speed = 125;
            stats9.dex = 0;
            stats9.str = 0;

            combo9.BaseStats = stats9;
            combo9.Effects.Add(Repository.AllEffects[13]);
            combo9.Effects.Add(Repository.AllEffects[16]);
            Repository.AllCombos.Add(combo9);


        }
        public static void GenerateEffects()
        {
            

            Repository.AllEffects = GameFileHandle.LoadDataEfectGame();

        }
        public static void GenerateItems()
        {

            

            Repository.AllItems = GameFileHandle.LoadDataItemGame();


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
