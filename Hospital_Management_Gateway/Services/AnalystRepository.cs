using Hospital_Management_Gateway.Models;
using Hospital_Management_Gateway.Repository.IRepository;
using System.Xml.Linq;

namespace Hospital_Management_Gateway.Services
{
    public class AnalystRepository : BaseService, IAnalystRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public AnalystRepository(IHttpClientFactory clientFactory):base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> Create_Analyst<T>(AnalystDTO analystDto)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.POST,
                Data = analystDto,
                Url = SD.Hospital_ServiceBase + "/api/analyst",
                AccessToken = ""
            });
        }

        public async Task<T> Delete_Analyst_By_Id<T>(int id)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.Hospital_ServiceBase + "/api/analyst" + id,
                AccessToken = ""
            });
        }

        public async Task<T> Get_AnalystsAsync<T>()
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/analyst",
                AccessToken = ""
            });
        }

        public async Task<T> Get_Analyst_By_Id<T>(int id)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/analyst" + id,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Analyst_By_Name<T>(string name)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/analyst/name/" + name,
                AccessToken = ""
            });
        }

        public async Task<T> Get_Analyst_By_Section<T>(int secId)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.Hospital_ServiceBase + "/api/analyst/sec/" + secId,
                AccessToken = ""
            });
        }

        public async Task<T> Update_Analyst<T>(AnalystDTO analystDto)
        {
            return await this.SendAsync<T>(new Api_Request()
            {
                ApiType = SD.ApiType.PUT,
                Data = analystDto,
                Url = SD.Hospital_ServiceBase + "/api/analyst",
                AccessToken = ""
            });
        }
    }
}
