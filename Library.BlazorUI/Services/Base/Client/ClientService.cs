
namespace Library.BlazorUI.Services.Base.Client
{
    public class ClientService : IClientService
    {
        public HttpClient HttpClient
        {
            get
            {
                return HttpClient; 
            }
        }
    }

}
