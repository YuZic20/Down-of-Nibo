using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Down_of_Nibo
{
    public static class Globals
    {
        public static List<Combo> learndCombos = new List<Combo>();
        public static int Turns { get; set; } = 100;
        public static Character Player { get; set; } = new Character();
        public static Mob[] Mobs { get; set; } = new Mob[3];
        public static RegionMap[] regionMaps { get; set; } = new RegionMap[3];
        public static List<Quest>[] Quests { get; set; } = new List<Quest>[3];
        public static Stats Training { get; set; } = new Stats();

        static int scene;
        public static int Scene
        {
            get
            {
                return scene;
            }
            set
            {
                scene = value;
                CallMe();
            }
        }

        private static void CallMe()
        {
            
            /*
                0 region Map 0
                1 region Map 1
                2 region Map 2
                3 World map
                4 Menu
                5 battle
                6 training
                */
            //change code here...
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;

            if (scene == 0)
            {
                
                ExistingInstanceOfMainWindow.MainWindowFrame.Content = regionMaps[0];
            }
            else if (scene == 1)
            {
                ExistingInstanceOfMainWindow.MainWindowFrame.Content = regionMaps[1];
            }
            else if (scene == 2)
            {
                ExistingInstanceOfMainWindow.MainWindowFrame.Content = regionMaps[2];
            }
            else if (scene == 3)
            {
                ExistingInstanceOfMainWindow.MainWindowFrame.Content = new WorldMap();
            }
            else if (scene == 4)
            {
                //menu
            }
            else if (scene == 5)
            {
                ExistingInstanceOfMainWindow.MainWindowFrame.Content = new Battle();
            }
            else if (scene == 6)
            {
                ExistingInstanceOfMainWindow.MainWindowFrame.Content = new Train();
            }
            
                
        }
        
    }
}
