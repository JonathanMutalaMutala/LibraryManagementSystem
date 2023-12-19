using AutoMapper;
using Library.BlazorUI.Services.Base.Client;
using MyNamespace;
using System.Net;

namespace Library.BlazorUI.Services.Base.HttpService
{
    public class BaseHttpService
    {
        protected Client.IClient _clientService;
        protected readonly IMapper _mapper; 


        public BaseHttpService(Client.IClient clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }


        /// <summary>
        /// Methode permettant de Convertir l'exception envoyé à L'API 
        /// Pour afficher les bonnes informations
        /// </summary>
        /// <typeparam name="Guid"></typeparam>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected Response<Guid> ConvertApiException<Guid>(ApiException exception)
        {
            Response<Guid> response = new Response<Guid>(); 

            //Si nous recevons une BadRequest cela veut dire que les data envoyé à API sont incorrectes 
            if(exception.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                response = new Response<Guid>
                {
                    Message = "Invalid Data était soumis",
                    ValidationsErrors = exception.Response,
                    Success = false
                }; 
            }
            else if(exception.StatusCode == (int)HttpStatusCode.NotFound)
            {
                response = new Response<Guid>
                {
                    Message = "Aucune donné trouvé",
                    Success = false,
                    ValidationsErrors = exception.Response
                }; 
            }else
            {
                response = new Response<Guid>
                {
                    Message = "Essayer Apres probleme interne",
                    Success = false,
                };
            }
            return response;
        }
        
    }
}
