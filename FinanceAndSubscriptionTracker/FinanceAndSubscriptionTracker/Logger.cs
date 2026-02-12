using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAndSubscriptionTracker
{
    public class Logger
    {
        public static void White(string messeage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(messeage);
            Console.ResetColor();
        }
        public static void Green(string messeage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(messeage);
            Console.ResetColor();
        }

        public static void Yellow(string messeage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(messeage);
            Console.ResetColor();
        }

        public static void Red(string messeage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messeage);
            Console.ResetColor();
        }

        public static void LightBlue(string messeage)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(messeage);
            Console.ResetColor();
        }
    }
}
