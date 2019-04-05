using System;
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
        public Stats BaseStats { get; set; }
        public int BaseDifficlty { get; set; }
        public List<int> ComboCode { get; set; } = new List<int>();
        public List<Effect_Duration> Effects { get; set; } = new List<Effect_Duration>();
        Random rand = new Random();


        public void GenerateCode(Stats Character)
        {
            List<int> CodeToReturn = new List<int>();
            if (Character.Def > BaseStats.Def && Character.dex > BaseStats.dex && Character.Dmg > BaseStats.Dmg && Character.speed > BaseStats.speed && Character.str > BaseStats.str) 
            {
                if (Character.Def > BaseStats.Def + 20 && Character.dex > BaseStats.dex + 20 && Character.Dmg > BaseStats.Dmg + 20 && Character.speed > BaseStats.speed + 20 && Character.str > BaseStats.str + 20) //easy
                {
                    ComboCode = GenerateCodeRND(BaseDifficlty, -(BaseDifficlty / 2), Globals.learndCombos);
                }
                else //normal
                {
                    ComboCode = GenerateCodeRND(BaseDifficlty, 0, Globals.learndCombos);
                }
            }
            else // hard
            {
                ComboCode = GenerateCodeRND(BaseDifficlty, BaseDifficlty, Globals.learndCombos);
            }
             
        }
        List<int> GenerateCodeRND(int BaseDifficlty,int LengthChanger, List<Combo> combos)
        {
            int lenght;
            
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

                if(!DoesComboExist(ComboToReturn, combos))
                {
                    return ComboToReturn;
                }
                else
                {
                    ComboToReturn.Clear();
                }
            }
            
            
        }
        public bool DoesComboExist(List<int> ComboToCheck, List<Combo> combos)
        {
            int lenght = ComboToCheck.Count();
          
            foreach (Combo ExistingCombo in combos) // kontrola existence komba
            {
                int Strike=0;
                if (ExistingCombo.ComboCode.Count() == lenght)
                {
                    for (int i = lenght-1; i >= 0; i--)
                    {
                        if (ExistingCombo.ComboCode[i] == ComboToCheck[i])
                        {
                            Strike++;
                        }
                    }
                }
                if (Strike == lenght)
                {
                    return true;
                }
            }
            
            return false;
            
            
        }


    }
}
