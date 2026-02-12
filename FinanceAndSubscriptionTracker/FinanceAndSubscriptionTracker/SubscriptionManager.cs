using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinanceAndSubscriptionTracker
{
    
    public class SubscriptionManager
    {
        public static string enterName()
        {
            Logger.White("Insert the name of the subscription: ");
            string name = Console.ReadLine();
            bool canContinue = true;
            foreach (Subscription sub in SaveManager.Data)
            {
                if (name == sub.Name)
                {
                    name = "";
                    Logger.Red("Cant have two subscriptions with the same name!");
                    canContinue = false;
                    break;
                }
            }
            if (canContinue)
            {
                return name;
            }
            else
            {
                return enterName();
            }
        }

        public static double enterPrice()
        {
            Logger.White("Price of subscription (USE ',' FOR DECIMALS): ");
            string input = Console.ReadLine();
            double price = 0.0;
            if (double.TryParse(input, out price) & price > 0)
            {
                return price;
            }
            else
            {
                Logger.Red("Wrong Input!");
                return enterPrice();
            }
        }

        public static PayPeriod enterPayPeriod()
        {
            Logger.White("Type of payment - Monthly/Annualy (CASE SENSITIVE): ");
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out PayPeriod payPeriod))
            {
                return payPeriod;
            }
            else
            {
                Logger.Red("Wrong Input!");
                return enterPayPeriod();
            }
        }

        public static Currency enterCurrency()
        {
            Logger.White("Currency - EUR/USD/CZK: ");
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out Currency currency))
            {
                return currency;
            }
            else
            {
                Logger.Red("Wrong Input!");
                return enterCurrency();
            }
        }

        public static Category enterCategory()
        {
            Logger.White("Category - Entertainment, Food, Utilities, Work, Other (CASE SENSITIVE): ");
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out Category category))
            {
                return category;
            }
            else
            {
                Logger.Red("Wrong Input!");
                return enterCategory();
            }
        }

        public static void AddSubscription()
        {
            DateTime nextBillingTime = DateTime.Today;

            string name = enterName();
            double price = enterPrice();
            PayPeriod payPeriod = enterPayPeriod();
            Currency currency = enterCurrency();
            Category category = enterCategory();

            nextBillingTime = payPeriod == PayPeriod.Monthly ? nextBillingTime.AddDays(30) : nextBillingTime.AddDays(365);

            Console.WriteLine("THE END");

            Subscription newSub = new Subscription(name, price, nextBillingTime, currency, category, payPeriod);
            SaveManager.Data.Add(newSub);
            SaveManager.SaveData();
            InputManager.Menu();
        }

        public static void RemoveSubscription()
        {
            foreach(Subscription sub in SaveManager.Data)
            {
                Console.WriteLine(sub.Name);
            }
            Logger.Red("\nWhich one do you want to delete?");
            string name = Console.ReadLine();
            List<Subscription> temporary = new List<Subscription>(SaveManager.Data);
            
            foreach (Subscription sub in temporary)
            {
                if (sub.Name == name)
                {
                    SaveManager.Data.Remove(sub);
                    SaveManager.SaveData();
                }
            }
            Logger.Green("\n\n Press anything to continue");
            Console.ReadKey();
            InputManager.Menu();
        }

        public static void PrintDataAboutSubscr()
        {
            foreach (Subscription sub in SaveManager.Data)
            {
                Console.WriteLine(sub.Name);
            }
            Logger.Green("\nAbout which subscription do you want the full data?");
            string name = Console.ReadLine();
            foreach (Subscription sub in SaveManager.Data)
            {
                if (sub.Name == name)
                {
                    Console.WriteLine($"Name: {sub.Name}");
                    Console.WriteLine($"Price: {sub.Price}");
                    Console.WriteLine($"NextBillingDay: {sub.NextBillingDay}");
                    Console.WriteLine($"Currency: {sub.Currency}");
                    Console.WriteLine($"Category: {sub.Category}");
                    Console.WriteLine($"PayPeriod: {sub.PayPeriod}");
                }
            }
            Logger.Green("\n\n Press anything to continue");
            Console.ReadKey();
            InputManager.Menu();
        }

        public static void PrintAllInfo()
        {
            foreach (Subscription sub in SaveManager.Data)
            {
                Console.WriteLine($"Name: {sub.Name}");
                Console.WriteLine($"Price: {sub.Price}");
                Console.WriteLine($"NextBillingDay: {sub.NextBillingDay}");
                Console.WriteLine($"Currency: {sub.Currency}");
                Console.WriteLine($"Category: {sub.Category}");
                Console.WriteLine($"PayPeriod: {sub.PayPeriod}");
                Logger.Green("---------------------------------------------------");
            }
            Logger.Green("\n\n Press anything to continue");
            Console.ReadKey();
            InputManager.Menu();
        }
        public static void PrintTotalCost()
        {
            Dictionary<string, double> totalPrices = new Dictionary<string, double>();
            totalPrices.Add("EUR", 0);
            totalPrices.Add("USD", 0);
            totalPrices.Add("CZK", 0);

            foreach (Subscription sub in SaveManager.Data)
            {
                if (sub.PayPeriod == PayPeriod.Monthly)
                {
                    totalPrices[sub.Currency.ToString()] += sub.Price;
                }
                else
                {
                    totalPrices[sub.Currency.ToString()] += sub.Price / 12;
                }
            }
            Console.WriteLine("Enter the Currency you want the result in - EUR/USD/CZK: ");
            string input = Console.ReadLine();
            double total = 0.0;
            switch (input)
            {
                case "EUR":
                    total = totalPrices["EUR"];
                    total += totalPrices["USD"] * 0.84;
                    total += totalPrices["CZK"] * 0.041;
                    break;
                case "USD":
                    total = totalPrices["USD"];
                    total += totalPrices["EUR"] * 1.19;
                    total += totalPrices["CZK"] * 0.049;
                    break;
                case "CZK":
                    total = totalPrices["CZK"];
                    total += totalPrices["USD"] * 20.44;
                    total += totalPrices["EUR"] * 24.25;
                    break;
                default:
                    Logger.Red("Wrong Input!");
                    PrintTotalCost();
                    break;
                
            }
            Console.WriteLine($"The total is {total}{input}");
            Logger.Green("\n\n Press anything to continue");
            Console.ReadKey();
            InputManager.Menu();
        }
    }
}
