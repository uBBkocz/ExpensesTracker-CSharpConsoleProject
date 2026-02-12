using System;
using System.Diagnostics;
using System.Xml.Linq;

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

