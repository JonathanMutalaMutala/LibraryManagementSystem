namespace Library.BlazorUI.Services.Base
{
    /// <summary>
    /// Represente la response qu'on compte avoir au niveau du UI 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public string Message { get; set; }

        public string ValidationsErrors { get; set; }

        public bool Success { get; set; }

        public T Data { get; set; }
    }
}
