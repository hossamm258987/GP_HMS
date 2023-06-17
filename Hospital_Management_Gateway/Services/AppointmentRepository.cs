using Hospital_Management_Gateway.Models;
using Hospital_Management_Gateway.Repository.IRepository;
using System.Xml.Linq;

namespace Hospital_Management_Gateway.Services
{
    public class AppointmentRepository : BaseService, IAppointmentRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public AppointmentRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> Create_Appointment<T>(AppointmentDTO appointmentDto)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.POST,
                Data = appointmentDto,
                Url = SD.Hospital_ServiceBase + "/api/Appointment",
                AccessToken = ""
            });
        }

        public async Task<T> Delete_Appointment_By_Id<T>(int id)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.Hospital_ServiceBase + "/api/Appointment" + id,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Appointments<T>()
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/Appointment",
                AccessToken = ""
            });
        }

        public async Task<T> Get_Appointment_By_Id<T>(int id)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/Appointment"+id,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Appointment_By_Name<T>(string name)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/Appointment/name/" + name,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Appointment_By_Number<T>(int number, DateTime time)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/Appointment/name/" + number+ "/" + time,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Appointment_By_Patient<T>(int pid)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/Appointment/name/" + pid,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Appointment_By_Section<T>(int sid)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/Appointment/name/" + sid,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Appointment_By_Section<T>(int sid, DateTime time)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/Appointment/name/" + sid + "/" + time,
                AccessToken = ""
            });
        }

        public async Task<T> Update_Appointment<T>(AppointmentDTO appointmentDto)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.PUT,
                Data = appointmentDto,
                Url = SD.Hospital_ServiceBase + "/api/Appointment",
                AccessToken = ""
            });
        }
    }
}
