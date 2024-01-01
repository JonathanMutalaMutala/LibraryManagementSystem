using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Library.BlazorUI.Contracts.Account;
using Library.BlazorUI.Providers;

namespace Library.BlazorUI.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authenticationState = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            if(authenticationState.User?.Identity?.IsAuthenticated == false)
            {
                NavigationManager.NavigateTo("/login");
            }
           
        }


    }
}