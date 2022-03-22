using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coinbase.Models;

namespace Coinbase.Repositories
{
    public class CryptoCurrencyRepository: ICryptocurrencyRepository
    {
        public readonly DatabaseContext _database;
        public async Task<IEnumerable<Cryptocurrency>> All()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Cryptocurrency> Get(int rank)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Cryptocurrency> Create(Cryptocurrency cryptocurrency)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Cryptocurrency> Update(Cryptocurrency cryptocurrency)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int rank)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CoinMarketCap>> MarketCap()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Cryptocurrency>> Search(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Cryptocurrency>> PriceRange(double min, double max)
        {
            throw new NotImplementedException();
            /*
             * 
             *
            List<Cryptocurrency> cryptocurrencies = new List<Cryptocurrency>();
            //loop through each of the currencies
            foreach (Cryptocurrency currency in _database.Cryptocurrencies)
            {
                //strip out the $ and , from the price string
                currency.Price = currency.Price.Replace("$", "").Replace(",", "");
                //convert the price to double so we can use it for range comparing
                double price = double.Parse(currency.Price);
                
                //if the price is in the range, we add it to the list
                if (price >= min && price <= max)
                {
                    cryptocurrencies.Add(currency);
                }
            }

            return cryptocurrencies;
            
            */
        }
    }
}