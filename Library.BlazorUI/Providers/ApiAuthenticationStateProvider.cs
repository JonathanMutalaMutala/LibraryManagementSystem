using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Library.BlazorUI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            this.jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        /// <summary>
        /// Methode permettant de fournir l'etat actuelle de l'authentification
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());  // Creation de claims vide 
            var isTokenPresent = await _localStorageService.ContainKeyAsync("token");  // Recuperation du token dans les LocalStorage

            if (!isTokenPresent)
            {
                return new AuthenticationState(user);
            }

            var savedToken = await _localStorageService.GetItemAsync<string>("token");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);


            if(tokenContent.ValidTo < DateTime.Now)
            {
                await _localStorageService.RemoveItemAsync("token"); 
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")); 

            return new AuthenticationState(user);

        }

        /// <summary>
        /// MEthode permettant de marker l'utilisateur authentifié si les credentials sont Correct
        /// </summary>
        /// <returns></returns>
        public async Task LoggedIn()
        {
            var claims = await GetClaims();

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")); 

            var authState = Task.FromResult(new AuthenticationState(user));

            NotifyAuthenticationStateChanged(authState);


        }


        /// <summary>
        /// Methode permettant de Recuperer les claims du Token 
        /// </summary>
        /// <returns>List de claims</returns>
        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await _localStorageService.GetItemAsync<string>("token");

            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken); 

            var claims = tokenContent.Claims.ToList();

            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));

            return claims;

        }
    }
}
