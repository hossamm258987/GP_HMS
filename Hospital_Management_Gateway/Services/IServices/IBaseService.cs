using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(Api_Request apiRequest);
    }
}
