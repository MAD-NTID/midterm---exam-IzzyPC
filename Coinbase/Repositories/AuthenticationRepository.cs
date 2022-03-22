using System.Threading.Tasks;
using Coinbase.Models;

namespace Coinbase.Repositories
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        public async Task<Authentication> Authenticate(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}