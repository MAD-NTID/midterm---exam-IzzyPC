using System.Threading.Tasks;

namespace Coinbase.Models
{
    public interface IAuthenticationRepository
    {
        public Task<Authentication> Authenticate(string key);
    }
}