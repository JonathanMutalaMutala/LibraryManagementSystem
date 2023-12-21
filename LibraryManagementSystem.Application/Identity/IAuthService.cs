using LibraryManagementSystem.Application.Models;
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
        Task<AuthResponse> Login(AuthRequest request);

    }
}
