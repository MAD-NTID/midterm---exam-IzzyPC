using System.Collections.Generic;
using System.Threading.Tasks;
using Coinbase.Models;
 
namespace Coinbase.Repositories
{
    public interface ICryptocurrencyRepository
    {
        /// <summary>
        /// This fetch and return all cryptocurrency
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Cryptocurrency>> All();
 
        /// <summary>
        /// This takes a rank and return the associating cryptocurrency
        /// </summary>
        /// <param name="rank">The rank of the cryptocurrency</param>
        /// <returns></returns>
        public Task<Cryptocurrency> Get(int rank);
 
        /// <summary>
        /// This create a new cryptocurrency in the repository
        /// </summary>
        /// <param name="cryptocurrency">The crypto currency to add</param>
        /// <returns></returns>
        public Task<Cryptocurrency> Create(Cryptocurrency cryptocurrency);
        
        /// <summary>
        /// This updates the cryptocurrency
        /// </summary>
        /// <param name="cryptocurrency"></param>
        /// <returns></returns>
        public Task<Cryptocurrency> Update(Cryptocurrency cryptocurrency);
        
        /// <summary>
        /// Removes a cryptocurrency the repository
        /// </summary>
        /// <param name="rank">The cryptocurrency to remove</param>
        public void Delete(int rank);
 
        /// <summary>
        /// This returns the market cap of all cryptocurrencies
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CoinMarketCap>> MarketCap();
 
        /// <summary>
        /// Return the partial matching cryptocurrencies
        /// </summary>
        /// <param name="name">The keyword to search</param>
        /// <returns></returns>
        public Task<IEnumerable<Cryptocurrency>> Search(string name);
        
 
        /// <summary>
        /// This returns the cryptocurrencies that matches the price ranges
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public Task<IEnumerable<Cryptocurrency>> PriceRange(double min, double max);
        
        
    }
}