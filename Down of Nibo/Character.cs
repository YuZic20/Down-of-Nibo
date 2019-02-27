using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace Down_of_Nibo
{
    class Character
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public Stats Stats { get; set; }
        public Eqiped Eqiped { get; set; }
        public List<Efect> efects { get; set; }//!!!!! přidat


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
                        tempStats = GetStatsFromList(character, character.Eqiped.Helmet);
                        break;
                    case 2:
                        tempStats = GetStatsFromList(character, character.Eqiped.Body);
                        break;
                    case 3:
                        tempStats = GetStatsFromList(character, character.Eqiped.Shoes);
                        break;
                    case 4:
                        tempStats = GetStatsFromList(character, character.Eqiped.Weapon);
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

            for(int i =0; i< character.Eqiped.Consumed.Count(); i++)
            {
                foreach (Efect effect in character.Eqiped.Consumed[i].Efects)
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
            return ReturnStats;

        }
        private Stats GetStatsFromList(Character character, Item item)
        {
            Stats ReturnStats = new Stats();

            foreach (Efect effect in item.Efects)
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
        public List<Item> CheckExpirationOfConsumibles(List<Item> Consumibles)
        {
            List<Item> returnList = new List<Item>();
            foreach(Item Items in Consumibles)
            {
                if(Items.duration > 0)
                {
                    returnList.Add(Items);
                }
            }
            return returnList;
        }

    }
}
