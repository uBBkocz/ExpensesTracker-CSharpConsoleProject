using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAndSubscriptionTracker
{

    
    public enum Currency
    {
        EUR,
        USD,
        CZK
    }
    public enum Category
    {
        Entertainment,
        Food,
        Utilities,
        Work,
        Other
    }
    public enum PayPeriod
    {
        Monthly,
        Annualy
    }

    public class Subscription
    {

        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime NextBillingDay { get; set; }

        public Currency Currency { get; set; }
        public Category Category { get; set; }
        public PayPeriod PayPeriod { get; set; }

        public Subscription() { }
        public Subscription(string name, double price, DateTime nextBillingDay, Currency currency, Category category, PayPeriod payperiod)
        {
            this.Name = name;
            this.Price = price;
            this.NextBillingDay = nextBillingDay;
            this.Currency = currency;
            this.Category = category;
            this.PayPeriod = payperiod;
        }
        
    }
}
