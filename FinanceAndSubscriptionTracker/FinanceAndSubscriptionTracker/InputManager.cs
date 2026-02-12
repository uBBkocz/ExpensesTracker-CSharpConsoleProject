using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAndSubscriptionTracker
{
    public class InputManager
    {
        public static void Menu()
        {
            Console.Clear();
            Logger.LightBlue("Insert your choise: 1 - Add | 2 - Remove | 3 - Print Info About | " +
                "4 - Print Info About All | 5 - Print Monthly Money Burn | 6 - EXIT");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SubscriptionManager.AddSubscription();
                    break;
                case "2":
                    SubscriptionManager.RemoveSubscription();
                    break;
                case "3":
                    SubscriptionManager.PrintDataAboutSubscr();
                    break;
                case "4":
                    SubscriptionManager.PrintAllInfo();
                    break;
                case "5":
                    SubscriptionManager.PrintTotalCost();
                    break;
                case "6":
                    Logger.White("Exiting");
                    Environment.Exit(0);
                    break;
                default:
                    Logger.Red("Wrong input. Exiting");
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
