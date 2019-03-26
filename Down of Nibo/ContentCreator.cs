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
            quest.decription = "kill em alll";

            Mob mob = new Mob();
            mob.Stats.Dmg = 50;
            quest.Mobs[1] = mob;

            Item item = new Item();
            item.Name = "Rukavice";
            quest.Reward = item;

            Globals.Quests[0].Add(quest);
        }
        public static void GenerateContent()
        {
            GenerateQuests();
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
