using System;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Coinbase.Exceptions;
using Coinbase.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Coinbase.Services
{
    public class APIAuthenticationService: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAuthenticationRepository _repository;
        
        public APIAuthenticationService(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IAuthenticationRepository repository) : 
            base(options, logger, encoder, clock)
        {
            _repository = repository;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //exclude anonymous endpoints from the authentication rule
            Endpoint endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                return AuthenticateResult.NoResult();
            
            //implement the authentication code here
            
            if (!Request.Headers.ContainsKey("Authorization"))
                throw new UserErrorException("Authorization header required!", 401);

            AuthenticationHeaderValue authorizationHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            string key = authorizationHeader.Parameter;

            Authentication auth = await _repository.Authenticate(key);
            if(auth is null)
                throw new UserErrorException("Invalid API key supplied", 401);
            
            //replace the two variable value with the correct info from the api repository
            string nameIdentifierApiKey = "12345TestKey";
            string userName = "coinBaseAdmin";
            
            
            //read more on claim
            //https://docs.microsoft.com/en-us/aspnet/core/security/authorization/claims?view=aspnetcore-6.0
            /**
             * A claims-based identity is the set of claims. A claim is a statement that an entity 
             * (a user or another application) makes about itself, it's just a claim. For example a 
             * claim list can have the user’s name, user’s e-mail, user’s age, user's authorization for an action
             */
            
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifierApiKey),
                new Claim(ClaimTypes.Name, userName)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
        
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            throw new UserErrorException("Unauthorized access", 401);
        }

        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            throw new UserErrorException("Forbidden access", 403);
        }
        
        
    }
}