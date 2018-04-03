using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace MVerses
{
    public class Practice
    {
        public static void PracticeMenu()
        {
            View.SetVerseLib();
            bool run = true;
            while (run == true)
            {
                string menu = "a";
                while (menu != "P" && menu != "p" && menu != "S" && menu != "s" && menu != "R" && menu != "r")
                {
                    //Main Menu and input
                    Console.WriteLine("Select Function");
                    Console.WriteLine("[P]ick Verse, [S]huffle All, [R]eturn to Main Menu");
                    menu = Console.ReadLine();

                    //Directs to user selection

                    //Select Practice Selected Verse
                    if (menu == "P" || menu == "p")
                    {
                        View.FindVerse();
                        View.LoadVerse();
                        Test();

                    }
                    //Select Enter New Verse
                    if (menu == "S" || menu == "s")
                    {
                        Global.shuffleTracker.Clear();
                        while ((Global.shuffleTracker.Count) < (Global.vLib.Count - 1))
                        {
                            Console.WriteLine("Shuffling...");
                            Shuffle();
                            View.LoadVerse();
                            Console.WriteLine("{0} out of {1}", Global.shuffleTracker.Count, (Global.vLib.Count - 1));
                            Test();
                        }

                    }
                    //Select Quit
                    if (menu == "R" || menu == "r")
                    {
                        run = false;
                        break;
                    }
                    continue;
                }
                continue;
            }
        }

        public static void Shuffle()
        {
            Random rand = new Random();
            bool confUntested = false;

            while (confUntested == false)
            {
                int shuf = (rand.Next(0, (Global.vLib.Count - 1)));
                bool testShuf = Global.shuffleTracker.Contains(shuf);
                if (testShuf == false)
                {
                    Global.load = shuf;
                    Global.shuffleTracker.Add(shuf);
                    confUntested = true;
                }
            }
        }

        public static void Test()
        {
            string retry = "a";
            bool testing = true;

            while (testing == true)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Please Enter {0} {1}:{2}\n", Global.book, Global.chnum, Global.vnum);
                string practice = Console.ReadLine();
                Console.WriteLine("\n");

                if (practice == Global.verse)
                {
                    Console.WriteLine("Correct!");
                    testing = false;
                    break;

                }
                if (practice != Global.verse)
                {
                    while (retry != "Y" && retry != "y" && retry != "N" && retry != "n")
                    {
                        Console.WriteLine("Incorrect. Retry? (Y/N)");
                        retry = Console.ReadLine();
                        if (retry == "Y" || retry == "y")
                        {
                            retry = "a";
                            break;
                        }
                        if (retry == "N" || retry == "n")
                        {
                            testing = false;
                            break;
                        }
                    }

                }
            }

        }

    }
}
