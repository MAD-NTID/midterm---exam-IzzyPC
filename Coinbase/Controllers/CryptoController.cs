using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Coinbase.Models;
using Coinbase.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Coinbase.Controllers
{
    [Authorize]
    [Route("api/cryptocurrencies/")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptocurrencyRepository _repository;

        public CryptoController(ICryptocurrencyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> AllCryptocurrencies()
        {
            return Ok(await _repository.All());
        }


        [HttpPost]
        public async Task<IActionResult> Create(Cryptocurrency cryptocurrency)
        {
            return Ok(await _repository.Create(cryptocurrency));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cryptocurrency cryptocurrency)
        {
            return Ok(await _repository.Update(cryptocurrency));
        }

        [HttpGet("{rank}")]
        public async Task<IActionResult> GetCryptocurrency(int rank)
        {
            return Ok(await _repository.Get(rank));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCryptocurrency(int rank)
        {
            _repository.Delete(rank);
            return Ok("Successful Delete!");
        }

        [HttpGet("marketcap")]
        public async Task<IActionResult> GetMarketCap()
        {
            return Ok(await _repository.MarketCap());
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchCryptcurrency(string name)
        {
            return Ok(await _repository.Search(name));
        }

        [HttpGet("pricerange/{start}/{end}")]
        public async Task<IActionResult> SearchByRange(double min, double max)
        {
            return Ok(await _repository.PriceRange(min, max));
        }
    }
}