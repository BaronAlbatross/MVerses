using System;
using System.IO;
using System.Linq;

namespace MVerses
{
    public class View
    {



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
                        bool subRun = true;
                        while (subRun == true)
                        {
                            //Display Verse
                            FindVerse();
                            if (subRun == true)
                            {
                                LoadVerse();
                                Display();
                            }
                        }

                    }
                    if (menu == "A" || menu == "a")
                    {
                        //Display All
                        int x = 0;
                        for (x = 0; x < (Global.vLib.Count -1); x++)
                        {
                            Global.load = x;
                            LoadVerse();
                            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
                        }


                    }
                    if (menu == "B" || menu == "b")
                    {
                        //Search by Book


                    }
                    if (menu == "W" || menu == "w")
                    {
                        //Search by Words


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

        public static void Display()
        {
            //Displays the verse that is stored in the global variables
            Console.WriteLine("\n\n");
            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
            Console.WriteLine("\n{0}\n", Global.verse);
            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);

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
            while (attempt = true)
            {
                Console.WriteLine("Enter the Verse in this format, [Book] [Chapter #]:[Verse #]");
                string v2Find = Console.ReadLine();
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
                for (x = 0; x < (Global.vLib.Count - 1); x++)
                {
                    string[] vBroken = Global.vLib[Global.load].Split('@');
                    if (find3[0] == vBroken[0] && find3[1] == vBroken[1] && find3[2] == vBroken[2])
                    {
                        Global.load = x;
                        break;
                    }
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
