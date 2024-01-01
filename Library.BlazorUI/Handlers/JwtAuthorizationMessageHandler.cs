using Blazored.LocalStorage;

namespace Library.BlazorUI.Handlers
{
    /// <summary>
    /// Cette classe intercepetera toute les requetes sortant 
    /// et permettra l'ajout du token dans le Header de la requetes 
    /// </summary>
    public class JwtAuthorizationMessageHandler : DelegatingHandler
    {
        public readonly ILocalStorageService _localStorageService;

        public JwtAuthorizationMessageHandler(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorageService.GetItemAsync<string>("token"); // Recuperation du TOken dans le localstorage
                                                                     
            if(!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue ("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
