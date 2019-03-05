using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace Ez_Efect_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fin = true;

            ClassLibrary2.FileHandle fileHandle = new FileHandle();


            List<AEffect> AllEffects = fileHandle.LoadDataEfect();
            List<Item> AllItems = fileHandle.LoadDataItem();



            string input;
            Console.WriteLine("items t/f");
            input = Console.ReadLine();
            


            while (fin)
            {
                if (input.Equals("t"))
                {
                    PrintItems(AllItems);
                    Console.ReadLine();
                    AllItems.Add(Additem());
                    fileHandle.SaveData(AllItems);
                }
                else
                {
                    PrintEffects(AllEffects);

                    Console.ReadLine();
                    AllEffects.Add(AddEffect());
                    fileHandle.SaveData(AllEffects);
                }
            }
            
        }
        static void PrintItems(List<Item> items)
        {
            Console.Clear();
            Console.WriteLine("Jméno | Eqipible | usible");
            
            foreach (Item item in items)
            {
                               
                
                Console.WriteLine(item.Name + " " + item.Eqipible+" " + item.usable);
                
               
                Console.WriteLine(new string('-', 50));

            }
        }
        
        static void PrintEffects(List<AEffect> efects)
        {
            Console.WriteLine("Jméno | Popis | Duration");
            Console.Clear();
            foreach (AEffect efect in efects)
            {
                
                if (efect is Effect_Duration)
                {
                    Console.WriteLine(efect.Name + " | " + efect.Description + "  | Duration:" + ((Effect_Duration)efect).Duration);                    
                }
                else
                {
                    Console.WriteLine(efect.Name + " | " + efect.Description);
                }
                Console.WriteLine("Speed | Dex | str | Dmg | Def");
                PrintStat(efect.FixedStats);
                PrintStat(efect.MStats);
                Console.WriteLine(new string('-', 50));

            }
        }
        static void PrintStat(Stats stat)
        {
            
            Console.WriteLine(stat.speed + " " + stat.dex + " " + stat.str + " " + stat.Dmg + " " + stat.Def);
        }
        static Item Additem()
        {
            Console.Clear();
            string input;
            Item NewItem = new Item();

            Console.WriteLine("Name");
            input = Console.ReadLine();
            NewItem.Name = input;

            Console.WriteLine("Eqipible t/f");
            input = Console.ReadLine();
            if (input.Equals("t"))
            {
                NewItem.Eqipible = true;
            }
            else
            {
                NewItem.Eqipible = false;
            }

            Console.WriteLine("usible t/f");
            input = Console.ReadLine();
            if (input.Equals("t"))
            {
                NewItem.usable = true;
            }
            else
            {
                NewItem.usable = false;
            }
            return NewItem;

        }
        static AEffect AddEffect()
        {
            Console.Clear();
            
            string input;
            AEffect NewEfectA = new AEffect();

            NewEfectA = EfectCreator();

            Console.WriteLine("Duration t/f");
            input = Console.ReadLine();
            if (input.Equals("t"))
            {
                Effect_Duration NewEfect = new Effect_Duration();
                NewEfect.Name = NewEfectA.Name;
                NewEfect.Description = NewEfectA.Description;
                NewEfect.FixedStats = NewEfectA.FixedStats;
                NewEfect.MStats = NewEfectA.MStats;

                Console.WriteLine("Duration");
                input = Console.ReadLine();
                NewEfect.Duration = Int32.Parse(input);

                return NewEfect;
                
                
            }
            else
            {
                return NewEfectA;
            }
            

            

        }
        static AEffect EfectCreator()
        {
            Console.Clear();
            string input;
            AEffect Efect = new AEffect();

            Console.WriteLine("Name");
            input = Console.ReadLine();
            Efect.Name = input;

            Console.WriteLine("Description");
            input = Console.ReadLine();
            Efect.Description = input;

            Console.WriteLine("Stats Fixed");
            Efect.FixedStats = CreateStats();

            Console.WriteLine("Stats multi");
            Efect.MStats = CreateStats();

            return Efect;



        }
        static Stats CreateStats()
        {
            Stats stats = new Stats();
            string input;

            Console.WriteLine("Speed");
            input = Console.ReadLine();
            stats.speed = Int32.Parse(input);

            Console.WriteLine("Dex");
            input = Console.ReadLine();
            stats.dex = Int32.Parse(input);

            Console.WriteLine("Str");
            input = Console.ReadLine();
            stats.str = Int32.Parse(input);

            Console.WriteLine("DMG");
            input = Console.ReadLine();
            stats.Dmg = Int32.Parse(input);

            Console.WriteLine("Def");
            input = Console.ReadLine();
            stats.Def = Int32.Parse(input);

            return stats;
        }

    }
}
