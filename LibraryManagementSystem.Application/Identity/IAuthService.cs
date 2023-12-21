using LibraryManagementSystem.Application.Models.Login;
using LibraryManagementSystem.Application.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Identity
{

    /// <summary>
    /// Ce service contient les contrats lié à l'authentification 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Methode permettant de connecté le User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthResponse> Login(AuthRequest request);

        /// <summary>
        /// Methode permettant qu'un utilisateur s'enregistre et en créant son compte 
        /// </summary>
        /// <param name="request">Correspond à L'object envoyé lors pour l'enregistrement </param>
        /// <returns></returns>
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
