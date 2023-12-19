
namespace Library.BlazorUI.Services.Base.ClientService
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return  new HttpClient() ?? _httpclient ;
            }
        }
    }
}
