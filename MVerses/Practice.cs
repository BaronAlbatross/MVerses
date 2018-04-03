using System;
namespace MVerses
{
    public class Practice
    {
        public static void PracticeMenu()
        {
            View.SetVerseLib();
            Random rand = new Random();
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

                    }
                    //Select Enter New Verse
                    if (menu == "S" || menu == "s")
                    {
                        
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
        public static void Test()
        {
            string retry = "a";

            while (retry != "N" && retry != "n")
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Please Enter {0} {1}:{2}\n", Global.book, Global.chnum, Global.vnum);
                string practice = Console.ReadLine();
                Console.WriteLine("\n");

                if (practice == Global.verse)
                {
                    Console.WriteLine("Correct!");
                    break;
                }
                if (practice != Global.verse)
                {
                    while (retry != "Y" && retry != "y" && retry != "N" && retry != "n")
                    {
                        Console.WriteLine("Incorrect. Retry? (Y/N)");
                        retry = Console.ReadLine();
                        continue;
                    }

                }
            }

        }

    }
}
