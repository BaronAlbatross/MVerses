using System;
namespace MVerses
{
    public class View
    {
        public void ViewMenu()
        {
            
        }

        public static void Display()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
            Console.WriteLine("\n{0}\n", Global.verse);
            Console.WriteLine("{0} {1}:{2}", Global.book, Global.chnum, Global.vnum);
        }

        public static void ExtractVerse()
        {

        }

    }


}
