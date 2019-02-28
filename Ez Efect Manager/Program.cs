﻿using System;
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

            List<AEfect> AllEffects = fileHandle.LoadDataEfect();

            while (fin)
            {
                //PrintEffects(AllEffects);
                Console.ReadLine();
            }
            
        }
        static void PrintEffects(List<AEfect> efects)
        {
            foreach(AEfect efect in efects)
            {
                Console.WriteLine(efect.Name + " " + efect.Description + " " + efect.time);
                PrintStat(efect.FixedStats);
                PrintStat(efect.MStats);
                Console.WriteLine(new string('-', 20));
            }
        }
        static void PrintStat(Stats stat)
        {
            Console.WriteLine(stat.speed + " " + stat.dex + " " + stat.str + " " + stat.Dmg + " " + stat.Def);
        }
        static List<AEfect> Additem(List<AEfect> efects)
        {
            string input;
            AEfect NewEffect = new AEfect();

            Console.WriteLine("Name");
            input = Console.ReadLine();
            NewEffect.Name = input;

            Console.WriteLine("Description");
            input = Console.ReadLine();
            NewEffect.Description = input;

            Console.WriteLine("Time");
            input = Console.ReadLine();
            NewEffect.time = input;// to int
        }
    }
}
