using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Exceptions
{
    public  class BadRequestException : Exception
    {
        public  BadRequestException(string message) : base(message)
        {

        }

        /// <summary>
        /// Constructeur permettant de gerer les erreurs liée au bad request 
        /// </summary>
        /// <param name="message">Message qui correspond </param>
        /// <param name="validationResult">Result avec plus detail qui sera envoyé au Body de la response </param>
        public BadRequestException(string message, FluentValidation.Results.ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }

        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
