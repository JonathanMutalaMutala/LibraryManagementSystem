
namespace Library.BlazorUI.Services.Base.Client
{
    public partial class Client : IClient
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
