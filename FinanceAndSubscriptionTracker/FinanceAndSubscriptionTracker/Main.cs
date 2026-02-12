using System;
using System.Diagnostics;
using System.Xml.Linq;

//TL; DR: Smart Finance & Subscription Tracker
//Cíl: Aplikace pro správu pravidelných plateb (Netflix, nájem, tarif).
//Hlavní třída Subscription: Name, Price (decimal), Currency (Enum), Category (Enum)
//NextBillingDate (DateTime), Period (Enum: Monthly / Yearly).
//Funkcionalita:
//Ukládání / načítání seznamu předplatných přes JSON.
//Výpočet "Monthly Burn Rate" (kolik měsíčně celkem zaplatím).
//Výpis plateb seřazených podle data nebo ceny (použití LINQ).
//Logger barevné varování: Červená pro drahé služby, Žlutá pro platby v nejbližších 3 dnech.
//Bonus: Funkce pro vyhledávání předplatného podle jména.

namespace FinanceAndSubscriptionTracker
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            SaveManager.LoadData();
            InputManager.Menu();
        }
    }
}
