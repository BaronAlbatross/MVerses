using System;
using System.IO;

namespace MVerses
{
    public class View
    {
        public static void ViewMenu()
        {
            bool run = true;

            while (run == true)
            {
                ClearLibrary();
                SetVerseLib();

                string menu = "z";
                while (menu != "V" && menu != "v" && menu != "A" && menu != "a" && menu != "B" && menu != "b" && menu != "W" && menu != "w" && menu != "R" && menu != "r")
                {
                    Console.WriteLine("Display [V]erse, Display [A]ll verse headers, Search by [B]ook, Search by [W]ord or phrase, [R]eturn to Main Menu");
                    menu = Console.ReadLine();

                    if (menu == "V" || menu == "v")
                    {
                        //Display Verse
                        FindVerse();

                    }
                    if (menu == "A" || menu == "a")
                    {
                        //Display All


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

        public static void ClearLibrary()
        {
            int clrLib = (Global.vLib.GetLength(0) - 1);
            Array.Clear(Global.vLib, 0, clrLib);
        }

        public static void SetVerseLib()
        {
            //Build vLib
            StreamReader extracted = File.OpenText(Global.file);
            string extractedString = extracted.ReadToEnd();
            extracted.Close();
            string[] vRaw = extractedString.Split('*');


            int x = 0;
            int y = 0;

            for (x = 0; x < (vRaw.GetLength(0)); x++)
            {
                string[] vBroken = vRaw[x].Split('@');
                for (y = 0; y < vBroken.GetLength(0); y++)
                {
                    Global.vLib[x, y] = vBroken[y];
                }
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
                Console.WriteLine(find3[0] + " " + find3[1] + ":" + find3[2]);

                //incomplete, got distracted by issues with SetVerseLib()




            }


        }

        public static void LoadVerse()
        {
            Global.book = Global.vLib[Global.load,0];
            Global.chnum = Global.vLib[Global.load, 1];
            Global.vnum = Global.vLib[Global.load, 2];
            Global.verse = Global.vLib[Global.load, 3];
        }

    }


}
