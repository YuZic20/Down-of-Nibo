using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    public class Mob
    {
        public string Name { get; set; }
        public Stats Stats { get; set; } = new Stats();
        public List<AEffect> efects { get; set; } = new List<AEffect>();
        public string GifPath_Idle { get; set; } = @"Assets\sprites\HBandit\idle.gif";
        public string GifPath_Attac { get; set; }
        public string ImgPath { get; set; } = @"Assets\sprites\HBandit\bandit_img.jpg";

        public Stats GetFullStats(Mob character)
        {
            //basic stats
            Stats ReturnStats = new Stats();
            ReturnStats.Def = character.Stats.Def;
            ReturnStats.speed = character.Stats.speed;
            ReturnStats.str = character.Stats.str;
            ReturnStats.Dmg = character.Stats.Dmg;
            ReturnStats.dex = character.Stats.dex;

           

            //consumible stats            


            foreach (AEffect effect in character.efects)
            {
                //Fix Stats
                ReturnStats.Def = ReturnStats.Def + effect.FixedStats.Def;
                ReturnStats.speed = ReturnStats.speed + effect.FixedStats.speed;
                ReturnStats.str = ReturnStats.str + effect.FixedStats.str;
                ReturnStats.Dmg = ReturnStats.Dmg + effect.FixedStats.Dmg;
                ReturnStats.dex = ReturnStats.dex + effect.FixedStats.dex;
                //float Stas
                ReturnStats.Def = ReturnStats.Def + (effect.MStats.Def * character.Stats.Def);
                ReturnStats.speed = ReturnStats.speed + (effect.MStats.speed * character.Stats.speed);
                ReturnStats.str = ReturnStats.str + (effect.MStats.str * character.Stats.str);
                ReturnStats.Dmg = ReturnStats.Dmg + (effect.MStats.Dmg * character.Stats.Dmg);
                ReturnStats.dex = ReturnStats.dex + (effect.MStats.dex * character.Stats.dex);

            }


            return ReturnStats;

        }
        private Stats GetStatsFromList(Character character, Item item)
        {
            Stats ReturnStats = new Stats();

            foreach (AEffect effect in item.Efects)
            {
                //Fix Stats
                ReturnStats.Def = ReturnStats.Def + effect.FixedStats.Def;
                ReturnStats.speed = ReturnStats.speed + effect.FixedStats.speed;
                ReturnStats.str = ReturnStats.str + effect.FixedStats.str;
                ReturnStats.Dmg = ReturnStats.Dmg + effect.FixedStats.Dmg;
                ReturnStats.dex = ReturnStats.dex + effect.FixedStats.dex;
                //float Stas
                ReturnStats.Def = ReturnStats.Def + (effect.MStats.Def * character.Stats.Def);
                ReturnStats.speed = ReturnStats.speed + (effect.MStats.speed * character.Stats.speed);
                ReturnStats.str = ReturnStats.str + (effect.MStats.str * character.Stats.str);
                ReturnStats.Dmg = ReturnStats.Dmg + (effect.MStats.Dmg * character.Stats.Dmg);
                ReturnStats.dex = ReturnStats.dex + (effect.MStats.dex * character.Stats.dex);

            }
            return ReturnStats;
        }
        public List<Effect_Duration> CheckExpirationOfConsumibles(List<Effect_Duration> Efects)
        {
            List<Effect_Duration> returnList = new List<Effect_Duration>();
            foreach (Effect_Duration efect in Efects)
            {
                if (efect.Duration > 0)
                {
                    returnList.Add(efect);
                }
            }
            return returnList;
        }
        public List<Effect_Duration> ExpireConsumibles(List<Effect_Duration> Efects, int Dose)
        {
            List<Effect_Duration> returnList = new List<Effect_Duration>();
            foreach (Effect_Duration efect in Efects)
            {
                efect.Duration = efect.Duration + Dose;
                returnList.Add(efect);


            }
            return returnList;
        }
    }
}
