using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace Down_of_Nibo
{
    public class Character
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; } = new Inventory();
        public Stats Stats { get; set; } = new Stats();
        public Eqiped Eqiped { get; set; } = new Eqiped();
        public List<Effect_Duration> efects { get; set; } = new List<Effect_Duration>();
        public string GifPath_Idle { get; set; } = @"Assets\sprites\main\idle.gif";
        public string GifPath_Attac { get; set; } = @"Assets\sprites\main\Attack.gif";


        private Stats HalfTheStats(Stats StatsToHalfe)
        {
            Stats NewStats = new Stats();
            NewStats.Def = StatsToHalfe.Def / 2;
            NewStats.speed = StatsToHalfe.speed / 2;
            NewStats.str = StatsToHalfe.str / 2;
            NewStats.Dmg = StatsToHalfe.Dmg / 2;
            NewStats.dex = StatsToHalfe.dex / 2;

            return NewStats;
        }
        public void AddStats(Stats StatsToAdd)
        {
            Stats.Def = Stats.Def + StatsToAdd.Def;
            Stats.speed = Stats.speed + StatsToAdd.speed;
            Stats.str = Stats.str + StatsToAdd.str;
            Stats.Dmg = Stats.Dmg + StatsToAdd.Dmg;
            Stats.dex = Stats.dex + StatsToAdd.dex;
        }
        public Stats GetFullStats(Character character)
        {
            //basic stats
            Stats ReturnStats = new Stats();
            ReturnStats.Def = character.Stats.Def;
            ReturnStats.speed = character.Stats.speed;
            ReturnStats.str = character.Stats.str;
            ReturnStats.Dmg = character.Stats.Dmg;
            ReturnStats.dex = character.Stats.dex;

            //Eqip Stats

            Stats tempStats = new Stats();
            
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        tempStats = GetStatsFromList(character, character.Eqiped.Weapon);
                        break;
                    case 2:
                        tempStats = GetStatsFromList(character, character.Eqiped.Body);
                        break;
                    case 3:
                        tempStats = GetStatsFromList(character, character.Eqiped.Shoes);
                        break;
                    
                        
                }
                //Fix Stats
                ReturnStats.Def = ReturnStats.Def + tempStats.Def;
                ReturnStats.speed = ReturnStats.speed + tempStats.speed;
                ReturnStats.str = ReturnStats.str + tempStats.str;
                ReturnStats.Dmg = ReturnStats.Dmg + tempStats.Dmg;
                ReturnStats.dex = ReturnStats.dex + tempStats.dex;
                //float Stas
                ReturnStats.Def = ReturnStats.Def + (tempStats.Def * character.Stats.Def);
                ReturnStats.speed = ReturnStats.speed + (tempStats.speed * character.Stats.speed);
                ReturnStats.str = ReturnStats.str + (tempStats.str * character.Stats.str);
                ReturnStats.Dmg = ReturnStats.Dmg + (tempStats.Dmg * character.Stats.Dmg);
                ReturnStats.dex = ReturnStats.dex + (tempStats.dex * character.Stats.dex);

            }

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

            if(item is null)
            {

            }
            else
            {
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
            }
            ReturnStats.Dmg = ReturnStats.Dmg + ReturnStats.str / 2;
            return ReturnStats;
        }
        public List<Effect_Duration> CheckExpirationOfConsumibles(List<Effect_Duration> Efects)
        {
            List<Effect_Duration> returnList = new List<Effect_Duration>();
            foreach(Effect_Duration efect in Efects)
            {
                if(efect.Duration > 0)
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
        
        public int EffectToAttac()
        {
            int Attac = 0;
            foreach (Effect_Duration efect in efects)
            {
                Attac = Attac + efect.FixedStats.HP;
                Attac = Attac + (efect.MStats.HP * Stats.HP);
            }
            return Attac;
        }
        public void OneRound()
        {
            int def = GetFullStats(this).Def;

            int givendimg = EffectToAttac();

            Random rand = new Random();
            int CritChance = rand.Next(100);
            if (CritChance < 15)
            {
                givendimg = def - givendimg * 2;
            }
            else if (CritChance > 75)
            {
                givendimg = def - givendimg / 2;
            }
            else
            {
                givendimg = def - givendimg;
            }

            if (givendimg < 0)
            {
                Stats.HP = Stats.HP + givendimg;
            }
            efects = ExpireConsumibles(efects, 1);
            efects = CheckExpirationOfConsumibles(this.efects);

        }
        public void died()
        {
            Stats = HalfTheStats(Stats);
            Inventory = new Inventory();
            Eqiped = new Eqiped();
            efects = new List<Effect_Duration>();
        }

    }
}
