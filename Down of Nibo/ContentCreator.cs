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
        public static void GenerateQuests()
        {
            List<Quest> quests = new List<Quest>();
            Globals.Quests[0] = quests;

            Quest quest = new Quest();
            quest.decription = "kill em alll1";

            Mob mob = new Mob();
            mob.Stats.Dmg = 50;
            quest.Mobs[1] = mob;           

            Globals.Quests[0].Add(quest);



            Quest quest1 = new Quest();
            quest1.decription = "kill em alll2";

            Mob mob2 = new Mob();
            mob2.Stats.Dmg = 50;
            quest1.Mobs[1] = mob2;

            Item item2 = new Item();
            item2.Name = "Combo";
            quest1.Reward = item2;

            Globals.Quests[0].Add(quest1);

            Quest quest2 = new Quest();
            quest2.decription = "kill em alll3";

            Mob mob3 = new Mob();
            mob3.Stats.Dmg = 50;
            quest.Mobs[1] = mob3;

            Item item3 = new Item();
            item3.Name = "dombo";
            quest2.Reward = item3;

            Globals.Quests[0].Add(quest2);

        }
        public static void GenerateContent()
        {
            GenerateQuests();
            GenerateCombos();
        }
        public static void GenerateCombos()
        {

            Combo combo = new Combo();
            combo.BaseDifficlty = 5;
            combo.Description = "Oheň";
            Stats stats = new Stats();
            stats.Def = 5;
            stats.dex = 5;
            stats.Dmg = 5;
            stats.HP = 5;
            stats.speed = 5;
            stats.str = 5;

            combo.BaseStats = stats;
            combo.Name = "nwm";

            Effect_Duration effect_Duration = new Effect_Duration();
            effect_Duration.Description = "uff";
            effect_Duration.Duration = 1;
            effect_Duration.FixedStats = stats;
            effect_Duration.Name = "ufff";

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
            BackImageSource.UriSource = new Uri(@"Assets\Img\fantasy_map.png", UriKind.Relative);
            BackImageSource.EndInit();
            Globals.regionMaps[0].RegionMapImage.Source = BackImageSource;

            BackImageSource = new BitmapImage();
            BackImageSource.BeginInit();
            BackImageSource.UriSource = new Uri(@"Assets\Img\fantasy_map.png", UriKind.Relative);
            BackImageSource.EndInit();
            Globals.regionMaps[1].RegionMapImage.Source = BackImageSource;

            BackImageSource = new BitmapImage();
            BackImageSource.BeginInit();
            BackImageSource.UriSource = new Uri(@"Assets\Img\fantasy_map.png", UriKind.Relative);
            BackImageSource.EndInit();
            Globals.regionMaps[2].RegionMapImage.Source = BackImageSource;


        }
    }
}
