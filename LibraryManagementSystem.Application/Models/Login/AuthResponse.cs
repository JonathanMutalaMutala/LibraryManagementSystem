using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models.Login
{
    /// <summary>
    /// Lors de L'authentification 
    /// C'est le donnée qu'on va renvoyer au UI 
    /// </summary>
    public class AuthResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
