namespace TSC.Expopunto.Domain.Models
{
    public class BaseResponseModel
    {
        public int statusCode { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}
