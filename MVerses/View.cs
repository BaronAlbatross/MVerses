using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MVerses
{
    public class View
    {

        public static bool subRun;

        public static void ViewMenu()
        {
            
            bool run = true;

            while (run == true)
            {
                
                SetVerseLib();

                string menu = "z";
                while (menu != "V" && menu != "v" && menu != "A" && menu != "a" && menu != "B" && menu != "b" && menu != "W" && menu != "w" && menu != "R" && menu != "r")
                {
                    
                    Console.WriteLine("Display [V]erse, Display [A]ll verse headers, Search by [B]ook, Search by [W]ord or phrase, [R]eturn to Main Menu");
                    menu = Console.ReadLine();

                    if (menu == "V" || menu == "v")
                    {
                        subRun = true;
                        while (subRun == true)
                        {
                            //Display Verse
                            FindVerse();
                            if (subRun == true)
                            {
                                LoadVerse();
                                Display();
                                menu = "z";
                                break;
                            }
                        }

                    }
                    if (menu == "A" || menu == "a")
                    {
                        //Display All
                        Console.WriteLine("\nAll Verses\n");
                        int x = 0;
                        for (x = 0; x < (Global.vLib.Count -1); x++)
                        {
                            Global.load = x;
                            LoadVerse();
                            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
                        }
                        Console.WriteLine("\n\n");


                    }
                    if (menu == "B" || menu == "b")
                    {
                        //Search by Book
                        searchBook();


                    }
                    if (menu == "W" || menu == "w")
                    {
                        //Search by Words
                        searchWord();


                    }
                    if (menu == "R" || menu == "r")
                    {
                        //return to main menu
                        run = false;
                        break;
                    }
                }
            }
        }

        public static void searchWord()
        {
            string wSearch;
            bool found = false;
            Console.WriteLine("\nPlease enter the word or phrase you would like to search for");
            wSearch = Console.ReadLine();

            Console.WriteLine("\nVerses containing \"{0}\"\n", wSearch);
            int x = 0;
            for (x = 0; x < (Global.vLib.Count - 1); x++)
            {
                string[] vBroken = Global.vLib[x].Split('@');
                if(vBroken[3].Contains(wSearch))
                {
                    Global.load = x;
                    LoadVerse();
                    Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
                    found = true;
                }

            }
            if (found == false)
            {
                Console.WriteLine("No verses found containing \"{0}\"", wSearch);
            }
            Console.WriteLine("\n\n");
        }

        public static void searchBook()
        {
            string bSearch;
            bool found = false;
            Console.WriteLine("\nPlease enter the name of the book you would like to search in");
            bSearch = Console.ReadLine();

            Console.WriteLine("\nVerses from {0}\n", bSearch);
            int x = 0;
            for (x = 0; x < (Global.vLib.Count - 1); x++)
            {
                string[] vBroken = Global.vLib[x].Split('@');
                if (bSearch == vBroken[0])
                {
                    Global.load = x;
                    LoadVerse();
                    Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
                    found = true;

                }
            }
            if (found == false)
            {
                Console.WriteLine("No verses found in {0}", bSearch);
            }
            Console.WriteLine("\n\n");
        }

        public static void Display()
        {
            //Displays the verse that is stored in the global variables
            Console.WriteLine("\n\n");
            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
            Console.WriteLine("\n{0}\n", Global.verse);
            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
            Console.WriteLine("\n\n");

        }

        public static void SetVerseLib()
        {
            Global.vLib.Clear();
            //Populate vLib
            StreamReader extracted = File.OpenText(Global.file);
            string extractedString = extracted.ReadToEnd();
            extracted.Close();
            string[] vRaw = extractedString.Split('*');
            int x = 0;
            for (x = 0; x < (vRaw.GetLength(0)); x++)
            {
                Global.vLib.Add(vRaw[x]);
            }
        }

        public static void FindVerse()
        {
            bool attempt = true;
            bool found = false;
            while (attempt == true)
            {
                Console.WriteLine("Enter the Verse in this format, [Book] [Chapter #]:[Verse #] or [Q]uit");
                string v2Find = Console.ReadLine();

                if (v2Find != "Q" || v2Find != "q")
                {
                    //query for the book by splitting it
                    /*split v2Find into array Find {Book, Chapter, Verse}
                     * for each subarray in Global.vLiv check for match and pull index # of sub array
                     * store subarray # in Global.load
                     */
                    string[] find1 = v2Find.Split(' ');
                    string[] find2 = find1[1].Split(':');
                    string[] find3 = { find1[0], find2[0], find2[1] };
                    //Console.WriteLine(find3[0] + " " + find3[1] + ":" + find3[2]);
                    int x = 0;
                    for (x = 0; x < (Global.vLib.Count -1); x++)
                    {
                        string[] vBroken = Global.vLib[x].Split('@');
                        if (find3[0] == vBroken[0] && find3[1] == vBroken[1] && find3[2] == vBroken[2])
                        {
                            Global.load = (x);
                            found = true;
                            attempt = false;
                            break;
                        }
                    }
                    if (found != true)
                    {
                        Console.WriteLine("Verse Not Found");
                    }
                }
                else
                {
                    subRun = false;
                    attempt = false;
                }
            }
        }

        public static void LoadVerse()
        {
            string[] vBroken = Global.vLib[Global.load].Split('@');

            Global.book = vBroken[0];
            Global.chnum = vBroken[1];
            Global.vnum = vBroken[2];
            Global.verse = vBroken[3];
        }

    }


}
