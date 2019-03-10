﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace Down_of_Nibo
{
    public class Combo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> ComboCode { get; set; } = new List<int>();
        Random rand = new Random();


        public List<int> GenerateCode(Stats Character, Stats BaseStats, int BaseDifficlty)
        {
            List<int> CodeToReturn = new List<int>();
            if (Character.Def > BaseStats.Def && Character.dex > BaseStats.dex && Character.Dmg > BaseStats.Dmg && Character.speed > BaseStats.speed && Character.str > BaseStats.str) 
            {
                if (Character.Def > BaseStats.Def + 20 && Character.dex > BaseStats.dex + 20 && Character.Dmg > BaseStats.Dmg + 20 && Character.speed > BaseStats.speed + 20 && Character.str > BaseStats.str + 20) //easy
                {
                    CodeToReturn = GenerateCodeRND(BaseDifficlty, -(BaseDifficlty / 2), Globals.leaarndCombos);
                }
                else //normal
                {
                    CodeToReturn = GenerateCodeRND(BaseDifficlty, 0, Globals.leaarndCombos);
                }
            }
            else // hard
            {
                CodeToReturn = GenerateCodeRND(BaseDifficlty, BaseDifficlty * 2, Globals.leaarndCombos);
            }
            return CodeToReturn;
        }
        List<int> GenerateCodeRND(int BaseDifficlty,int LengthChanger, List<Combo> combos)
        {
            int lenght;
            int Strike = 0;
            List<int> ComboToReturn = new List<int>();
            //délka komba
            if(BaseDifficlty + LengthChanger >= 3) //3 = minimílní délka komba
            {
                lenght = BaseDifficlty + LengthChanger;
            }
            else
            {
                lenght = 3;
            }
            
            //generace komba
            while (true)
            {
                for (int i = lenght; i >= 1; i--)
                {
                    ComboToReturn.Add(rand.Next(4));
                }

                foreach (Combo ExistingCombo in combos) // kontrola existence komba
                {
                    if (ExistingCombo.ComboCode.Count() == lenght)
                    {
                        for (int i = lenght; i >= 1; i--)
                        {
                            if (ExistingCombo.ComboCode[i] == ComboToReturn[i])
                            {
                                Strike++;
                            }
                        }
                    }
                }
                if(Strike == 0)
                {
                    return ComboToReturn;
                }
                else
                {
                    Strike = 0;
                    ComboToReturn.Clear();
                }
            }
            
        }


    }
}