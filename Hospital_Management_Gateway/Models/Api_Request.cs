using static Hospital_Management_Gateway.SD;

namespace Hospital_Management_Gateway.Models
{
    public class Api_Request
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
