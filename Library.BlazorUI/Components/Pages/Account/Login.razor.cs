using Library.BlazorUI.Contracts.Account;
using Library.BlazorUI.Models.AccountModel;
using Microsoft.AspNetCore.Components;

namespace Library.BlazorUI.Components.Pages.Account
{
    public partial class Login : ComponentBase
    {
        [SupplyParameterFromForm]
        public LoginVM Model { get; set; }

        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }


        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }

        protected async Task HandleLogin()
        {
            bool isAuthenticate = await AuthenticationService.AuthenticateUserAsync(Model.Email,Model.Password);

            if (isAuthenticate)
            {
                NavigationManager.NavigateTo("/books/index");
            }

            Message = "UserName/Password ne correspond pas";
        }
    }
}