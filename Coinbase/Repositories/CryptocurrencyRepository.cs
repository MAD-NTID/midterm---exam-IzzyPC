using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coinbase.Exceptions;
using Coinbase.Models;
using Microsoft.EntityFrameworkCore;

namespace Coinbase.Repositories
{
    public class CryptoCurrencyRepository : ICryptocurrencyRepository
    {
        private readonly DatabaseContext _database;

        public CryptoCurrencyRepository(DatabaseContext database)
        {
             _database = database;
        }
        public async Task<IEnumerable<Cryptocurrency>> All()
        {
            return await _database.Cryptocurrencies.ToListAsync(); //error here
        }

        public async Task<Cryptocurrency> Get(int rank)
        {
            Cryptocurrency crypt = await _database.Cryptocurrencies
                .FirstOrDefaultAsync(currency => currency.Rank == rank );
            if (crypt is null)
                throw new UserErrorException($"No Cryptocurrency found based on {rank}");
            return crypt;
        }

        public async Task<Cryptocurrency> Create(Cryptocurrency cryptocurrency)
        {
            if (cryptocurrency is null)
                throw new UserErrorException("cryptocurrency cannot be null", 400);
            if (cryptocurrency.Name == "")
                throw new Exception("Name cannot be empty");
            await _database.AddAsync(cryptocurrency);
            await _database.SaveChangesAsync();
            return cryptocurrency;
        }

        public async Task<Cryptocurrency> Update(Cryptocurrency cryptocurrency)
        {
            await Get(cryptocurrency.Rank);
            _database.Cryptocurrencies.Update(cryptocurrency);
            await _database.SaveChangesAsync();
            return cryptocurrency;
        }

        public async void Delete(int rank)
        {
            Cryptocurrency crypt = await Get(rank);
            _database.Remove(crypt);
            await _database.SaveChangesAsync();
        }

        public async Task<IEnumerable<CoinMarketCap>> MarketCap()
        {
            List<CoinMarketCap> coinMarket = new List<CoinMarketCap>();
            Cryptocurrency cryptCurrent;
            for (int i = 0; i < _database.Cryptocurrencies.Count(); i++)
            {
                cryptCurrent = await Get(i);
                coinMarket.Add(new CoinMarketCap { Name = cryptCurrent.Name, MarketCap = cryptCurrent.MarketCap, AvailableSupply = cryptCurrent.AvailableSupply });
            }

            return coinMarket;
        }

        public async Task<IEnumerable<Cryptocurrency>> Search(string name)
        {
            name = name.ToLower();
            return await _database.Cryptocurrencies.Where(crypt => crypt.Name.ToLower().Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Cryptocurrency>> PriceRange(double min, double max)
        {
            List<Cryptocurrency> cryptocurrencies = new List<Cryptocurrency>();
            //loop through each of the currencies
            foreach (Cryptocurrency currency in _database.Cryptocurrencies)
            {
                currency.Price = currency.Price.Replace("$", "").Replace(",", "");
                
                double price = double.Parse(currency.Price);
                
                if (price >= min && price <= max)
                {
                    cryptocurrencies.Add(currency);
                }
            }

            return cryptocurrencies;
        }
    }
}