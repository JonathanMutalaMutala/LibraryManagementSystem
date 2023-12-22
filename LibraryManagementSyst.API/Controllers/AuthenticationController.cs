using LibraryManagementSystem.Application.Identity;
using LibraryManagementSystem.Application.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSyst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly IAuthService _authenticationService; 


        public AuthenticationController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Ce  Http permet de connecter un utilisateur 
        /// Prend L'objet AuthRequest en parametre et appel la methode permettant d'authentifié l'utilisateur 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }




    }
}
