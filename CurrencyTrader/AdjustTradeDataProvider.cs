using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly string url;
        ITradeDataProvider urlProvider;

        public AdjustTradeDataProvider(String url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }
        
        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> tradetxt;

            //list of trades with substitutions in them
            List<string> newTradeTxt = new List<string>();

            tradetxt = urlProvider.GetTradeData();

            
            foreach (string line in tradetxt)
            {
                String newLine = line.Replace("GBP", "EUR");
                newTradeTxt.Add(newLine);
            }

            return newTradeTxt;
        }
    }
}
