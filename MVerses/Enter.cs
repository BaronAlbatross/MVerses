using System;
using System.IO;

namespace MVerses
{
    public class Enter
    {
        
        public static void EnterVerse()
        {
            bool run = true;
            while (run == true)
            {
                //Input Verse and location info
                Console.WriteLine("Please enter the Book, example \"Proverbs\")");
                Global.book = Console.ReadLine();
                Console.WriteLine("Please enter the Chapter number, example \"18\")");
                Global.chnum = Console.ReadLine();
                Console.WriteLine("Please enter the Verse number(s), example \"1-2\")");
                Global.vnum = Console.ReadLine();
                Console.WriteLine("Please enter the Verse");
                Global.verse = Console.ReadLine();

                //confirm input. 
                string conf = "a";
                while (conf != "Y" && conf != "y" && conf != "N" && conf != "n")
                {
                    View.Display();
                    Console.WriteLine("\nIs this correct? [Y]es or [N]o");
                    conf = Console.ReadLine();

                    if (conf == "Y" || conf == "y")
                    {
                        StoreVerse();
                        run = false;
                        break;
                    }
                    if (conf == "N" || conf == "n")
                    {
                        Console.WriteLine("Retry Verse Entry");
                        break;
                    }
                    continue;
                }
                continue;
            }
        }

        public static void StoreVerse()
        {
            string storeString = Global.book + "@" + Global.chnum + "@" + Global.vnum + "@" + Global.verse + "*";
            StreamWriter writer = new StreamWriter(Global.file,true);
            writer.Write(storeString);
            writer.Close();
            Console.WriteLine("Verse added to library.");
        }
    }
}
