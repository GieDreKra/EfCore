using System;

namespace CurrencyRatesApp.Models
{
    public class Item
    {
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public string Unit { get; set; }
    }
}
