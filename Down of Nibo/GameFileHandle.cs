using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;
using Newtonsoft.Json;

namespace Down_of_Nibo
{
    public static class GameFileHandle
    {
        static string path = @"data/";
        static string Datapath = @"ItemsAndEffects/";

        public static void SaveGame()
        {
            string realpath = path + "Game.txt";

            GlobalData GameData = new GlobalData();



            GameData.learndCombos = Globals.learndCombos;
            GameData.Turns = Globals.Turns;
            GameData.Player = Globals.Player;
            GameData.Mobs = Globals.Mobs;

            GameData.Quests = Globals.Quests;
            GameData.Training = Globals.Training;


            string json = JsonConvert.SerializeObject(GameData, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            //string json = JsonConvert.SerializeObject(GameData);

            System.IO.FileInfo file = new System.IO.FileInfo(realpath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            System.IO.File.WriteAllText(file.FullName, json);

            
        }

        public static void LoadGame()
        {
            string realpath;

            realpath = path + "Game.txt";
            if (File.Exists(realpath))
            {
                string file = System.IO.File.ReadAllText(realpath);

                GlobalData GameData = JsonConvert.DeserializeObject<GlobalData>(file);

                Globals.learndCombos = GameData.learndCombos;
                Globals.Turns = GameData.Turns;
                Globals.Player = GameData.Player;
                Globals.Mobs = GameData.Mobs;

                Globals.Quests = GameData.Quests;
                Globals.Training = GameData.Training;



                
            }
                                      


           
        }
        public static bool CanLoadGame()
        {
            string realpath;

            realpath = path + "Game.txt";
            if (File.Exists(realpath))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void DeleteSave()
        {
            if (File.Exists(@"data/Game.txt"))
            {
                File.Delete(@"data/Game.txt");
            }
        }
        public static List<Effect_Duration> LoadDataEfectGame()
        {
            string realpath;

            realpath = Datapath + "Effects.txt";
            if (File.Exists(realpath))
            {
                string file = System.IO.File.ReadAllText(realpath);

                List<Effect_Duration> m = JsonConvert.DeserializeObject<List<Effect_Duration>>(file);
                return m;
            }
            else
            {
                return new List<Effect_Duration>();
            }






        }
        public static List<Item> LoadDataItemGame()
        {
            string realpath;
            realpath = Datapath + "Items.txt";
            if (File.Exists(realpath))
            {

                string file = System.IO.File.ReadAllText(realpath);

                List<Item> m = JsonConvert.DeserializeObject<List<Item>>(file);
                return m;
            }
            else
            {
                return new List<Item>();
            }


        }
    }
}
