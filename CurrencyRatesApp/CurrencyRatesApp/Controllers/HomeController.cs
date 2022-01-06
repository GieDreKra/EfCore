using CurrencyRatesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace CurrencyRatesApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Item> getCurrency(string dateString)
        {
            string loadWebService = "http://www.lb.lt/webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=" + dateString;
            List<Item> Items = new List<Item> { };
            foreach (XElement level1Element in XElement.Load(loadWebService).Elements("item"))
            {
                Item item = new Item();
                item.Date = DateTime.Parse(level1Element.Element("date").Value);
                item.Currency = level1Element.Element("currency").Value;
                item.Quantity = Int32.Parse(level1Element.Element("quantity").Value);
                item.Rate = double.Parse(level1Element.Element("rate").Value.Replace(".", ","));
                item.Unit = level1Element.Element("unit").Value;
                Items.Add(item);
            }
            return Items;
        }

        public IActionResult ListOfChanges(DateTime date)
        {
            try
            {
                List<Item> Items = new List<Item> { };
                Items = getCurrency(date.ToString().Substring(0, 10));

                List<Item> Items1 = new List<Item>();
                Items1 = getCurrency(date.AddDays(-1).ToString().Substring(0, 10));
            
                List<Item> Items2 = new List<Item>();
                for (var i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Currency == Items1[i].Currency)
                    {
                        Item item = new Item();
                        item.Currency = Items[i].Currency;
                        item.Rate = Items[i].Rate - Items1[i].Rate;
                        item.Unit = Items[i].Unit;
                        Items2.Add(item);
                    }
                }
                List<Item> SortedItems = Items2.OrderByDescending(o => o.Rate).ToList();
                return View(SortedItems);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
