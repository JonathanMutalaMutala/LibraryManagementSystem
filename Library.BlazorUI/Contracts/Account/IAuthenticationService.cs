namespace Library.BlazorUI.Contracts.Account
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateUserAsync (string email, string password);

        Task Logout();
    }
}
