using Library.BlazorUI.Contracts.Account;

namespace Library.BlazorUI.Services.AccountServices
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<bool> AuthenticateUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
