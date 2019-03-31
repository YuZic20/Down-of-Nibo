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
        static string path = @"C:\Users\W0olf\Desktop\drivers";

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
            System.IO.File.WriteAllText(realpath, json);
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
            if (File.Exists(@"C:\Users\W0olf\Desktop\drivers/Game.txt"))
            {
                File.Delete(@"C:\Users\W0olf\Desktop\drivers/Game.txt");
            }
        }
    }
}
