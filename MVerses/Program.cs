﻿using System;

namespace MVerses
{

    class Global
    {
        public static string book;
        public static string chnum;
        public static string vnum;
        public static string verse;
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            bool run = true;
            while (run == true)
            {
                string menu = "a";
                while (menu != "V" && menu != "v" && menu != "P" && menu != "p" && menu != "E" && menu != "e" && menu != "Q" && menu != "q")
                {
                    //Main Menu and input
                    Console.WriteLine("Select Function");
                    Console.WriteLine("[V]iew Verses, [P]ractice Recall, [E]nter New Verse, [Q]uit");
                    menu = Console.ReadLine();

                    //Directs to user selection

                    //Select View Verses
                    if (menu == "V" || menu == "v")
                    {
                        //run view methods
                        Console.WriteLine("View");
                    }
                    //Select Practice Recall
                    if (menu == "P" || menu == "p")
                    {
                        //run view methods
                        Console.WriteLine("Practice");
                    }
                    //Select Enter New Verse
                    if (menu == "E" || menu == "e")
                    {
                        //run view methods
                        Enter.EnterVerse();
                    }
                    //Select Quit
                    if (menu == "Q" || menu == "q")
                    {
                        Console.WriteLine("Program Terminated");
                        run = false;
                        break;
                    }
                    continue;
                }
                continue;
            }
        }
    }
}