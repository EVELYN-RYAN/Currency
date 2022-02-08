using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Currency.Models;

namespace Currency.Controllers
{
    public class HomeController : Controller
    {
        private CurrencyContext cContext { get; set; }

        //Constructor
        public HomeController(CurrencyContext created)
        {
            cContext = created;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Conversion"] = 100.00m;
            ViewData["Rate"] = 1.0m;
            ViewData["Amount"] = 100m;
            ViewData["FromCode"] = "USD";
            ViewData["ToCode"] = "USD";
            ViewData["RateCode"] = "USD";

            var cur = cContext.Currency.ToList();
            return View(cur);
        }
        [HttpPost]
        public IActionResult Index(string fromCode, string toCode, decimal amount,string rate)
        {
            var calcRate = ConvertCurrency(fromCode,toCode,amount);
            var dRate = GetRate(rate);

            ViewData["Conversion"] = calcRate;
            ViewData["Rate"] = dRate;
            ViewData["Amount"] = amount;
            ViewData["FromCode"] = fromCode;
            ViewData["ToCode"] = toCode;
            

            var cur = cContext.Currency.ToList();
            return View(cur);
        }
        public decimal ConvertCurrency(string fromCode, string toCode, decimal amount)
        {
            var sFrom = cContext.Currency
                .Single(x => x.CurrencyCode == fromCode);
            var sTo = cContext.Currency
                .Single(x => x.CurrencyCode == toCode);

            decimal calcRate = (sTo.Rate/ sFrom.Rate) * amount;
            calcRate = Math.Round(calcRate, 6);
            return calcRate;
        }
        public decimal GetRate(string rate)
        {
            ViewData["RateCode"] = rate;

            var otherRate = (cContext.Currency
                .Single(x => x.CurrencyCode == rate)).Rate;
            var usd = (cContext.Currency
                .Single(x => x.CurrencyCode == "USD")).Rate;

            decimal dRate =  usd/otherRate;
            dRate = Math.Round(dRate, 6);

            return dRate;

        }
        [HttpGet]
        public IActionResult AddCurrency()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCurrency(Models.Currency c)
        {
            if(c.PrevRate == 0)
            {
                c.PrevRate = c.Rate;
            }
            if (ModelState.IsValid)
            {
                cContext.Add(c);
                cContext.SaveChanges();
            }
            else //if valid
            {
                return View("AddCurrency", c);
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int currencyID)
        {
            var cur = cContext.Currency
                .Single(x => x.CurrencyID == currencyID);
            return View("AddCurrency", cur);
        }
        [HttpPost]
        public IActionResult Update(Models.Currency c)
        {
            cContext.Update(c);
            cContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
