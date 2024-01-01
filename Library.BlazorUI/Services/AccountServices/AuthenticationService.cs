using AutoMapper;
using Blazored.LocalStorage;
using Library.BlazorUI.Contracts.Account;
using Library.BlazorUI.Providers;
using Library.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace Library.BlazorUI.Services.AccountServices
{
    public class AuthenticationService : BaseHttpService,IAuthenticationService
    {
        protected readonly AuthenticationStateProvider _authenticationStateProvider;
        protected readonly ILocalStorageService _localStorageService; 
        public AuthenticationService(IClient client, IMapper mapper,AuthenticationStateProvider authenticationStateProvider,ILocalStorageService localStorageService) : base(client, mapper)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
           bool authenticationResult = false;

            try
            {
                AuthRequest authRequest = new AuthRequest() { Email = email, Password = password};
                var authenticationResponse = await _client.LoginAsync(authRequest);

                if (!string.IsNullOrEmpty(authenticationResponse.Token))
                {
                    await _localStorageService.SetItemAsStringAsync("token", authenticationResponse.Token);

                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn(); // Connecter le User 

                    authenticationResult = true;
                }
                return authenticationResult;
            }
            catch (Exception)
            {

                return authenticationResult;
            }

        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }
    }
}
