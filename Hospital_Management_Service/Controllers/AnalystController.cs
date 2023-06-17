using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalystController : ControllerBase
    {
        protected ResponseDTO _response;
        private IAnalystRepository _analystRepository;

        public AnalystController(IAnalystRepository analystRepository)
        {
            this._response = new ResponseDTO();
            _analystRepository = analystRepository;
        }
        // GET: api/<AnalystController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<AnalystDTO> analystDTOs = await _analystRepository.Get_Analysts();
                _response.Result = analystDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AnalystController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                AnalystDTO analystDTO = await _analystRepository.Get_Analyst_By_Id(id);
                _response.Result = analystDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<AnalystDTO> analystDTOs = await _analystRepository.Get_Analyst_By_Name(name);
                _response.Result = analystDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AnalystController>/sec/Id
        [HttpGet("sec/{sid}")]
        public async Task<object> Get_By_Sec(int sid)
        {
            try
            {
                List<AnalystDTO> analystDTO = await _analystRepository.Get_Analyst_By_Section(sid);
                _response.Result = analystDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<AnalystController>
        [HttpPost]
        public async Task<object> Post([FromBody] AnalystDTO analystDTO)
        {
            try
            {
                AnalystDTO model = await _analystRepository.Create_Update_Analyst(analystDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // PUT api/<AnalystController>
        [HttpPut]
        public async Task<object> Put([FromBody] AnalystDTO analystDTO)
        {
            try
            {
                AnalystDTO model = await _analystRepository.Create_Update_Analyst(analystDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE api/<AnalystController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _analystRepository.Delete_Analyst_By_Id(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
