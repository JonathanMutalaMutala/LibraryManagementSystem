using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    /// <summary>
    /// Cette classe correspond aux informations que les users pourront entrée pour le Login 
    /// Email et password qu'on aura dans la Request
    /// </summary>
    public class AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
