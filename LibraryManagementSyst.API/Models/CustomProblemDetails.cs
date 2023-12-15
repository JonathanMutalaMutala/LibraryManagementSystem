using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSyst.API.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> ErrorsDetailsDictionnary { get; set; } = new Dictionary<string,string[]>();
        public string? CurrentTrace {  get; set; }  
    }
}
