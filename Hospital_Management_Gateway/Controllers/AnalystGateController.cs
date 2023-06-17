using Hospital_Management_Gateway.Models;
using Hospital_Management_Gateway.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalystGateController : ControllerBase
    {
        private readonly IAnalystRepository _analystRepository;
        public AnalystGateController(IAnalystRepository analystRepository) 
        {
            _analystRepository = analystRepository;
        }
        // GET: api/<AnalystGateController>
        [HttpGet]
        public async Task<IEnumerable<AnalystDTO>> Get()
        {
            List<AnalystDTO> list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _analystRepository.Get_AnalystsAsync<ResponseDTO>(/*accessToken*/);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AnalystDTO>>(Convert.ToString(response.Result));
            }
            return list;
        }

        // GET api/<AnalystController>/5
        [HttpGet("{id}")]
        public async Task<AnalystDTO> Get(int id)
        {
            AnalystDTO list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _analystRepository.Get_Analyst_By_Id<ResponseDTO>(id/*accessToken*/);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<AnalystDTO>(Convert.ToString(response.Result));
            }
            return list;
        }

        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            List<AnalystDTO> list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _analystRepository.Get_Analyst_By_Name<ResponseDTO>(name/*accessToken*/);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AnalystDTO>>(Convert.ToString(response.Result));
            }
            return list;
        }

        // GET api/<AnalystController>/sec/Id
        [HttpGet("sec/{sid}")]
        public async Task<object> Get_By_Sec(int sid)
        {
            List<AnalystDTO> list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _analystRepository.Get_Analyst_By_Id<ResponseDTO>(sid/*accessToken*/);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AnalystDTO>>(Convert.ToString(response.Result));
            }
            return list;
        }

        // POST api/<AnalystController>
        [HttpPost]
        public async Task<object> Post([FromBody] AnalystDTO analystDTO)
        {
            List<AnalystDTO> list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _analystRepository.Create_Analyst<ResponseDTO>(analystDTO/*accessToken*/);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AnalystDTO>>(Convert.ToString(response.Result));
            }
            return list;
        }

        // PUT api/<AnalystController>
        [HttpPut]
        public async Task<object> Put([FromBody] AnalystDTO analystDTO)
        {
            List<AnalystDTO> list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _analystRepository.Update_Analyst<ResponseDTO>(analystDTO/*accessToken*/);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AnalystDTO>>(Convert.ToString(response.Result));
            }
            return list;
        }

        // DELETE api/<AnalystController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            List<AnalystDTO> list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _analystRepository.Delete_Analyst_By_Id<ResponseDTO>(id/*accessToken*/);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AnalystDTO>>(Convert.ToString(response.Result));
            }
            return list;
        }
    }
}
