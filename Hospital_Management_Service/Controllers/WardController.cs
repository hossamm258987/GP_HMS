using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Repository.IRepository;
using Hospital_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        protected ResponseDTO _response;
        private IWardRepository _wardRepository;

        public WardController(IWardRepository wardRepository)
        {
            this._response = new ResponseDTO();
            _wardRepository = wardRepository;
        }
        // GET: api/<WardsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<WardDTO> wardDTOs = await _wardRepository.Get_Wards();
                _response.Result = wardDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<WardsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                WardDTO wardDTO = await _wardRepository.Get_Ward_By_Id(id);
                _response.Result = wardDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<WardsController>/name/Ward
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<WardDTO> wardDTOs = await _wardRepository.Get_Ward_By_Name(name);
                _response.Result = wardDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<WardsController>
        [HttpPost]
        public async Task<object> Post([FromBody] WardDTO wardDTO)
        {
            try
            {
                WardDTO model = await _wardRepository.Create_Update_Ward(wardDTO);
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

        // PUT api/<WardsController>
        [HttpPut]
        public async Task<object> Put([FromBody] WardDTO wardDTO)
        {
            try
            {
                WardDTO model = await _wardRepository.Create_Update_Ward(wardDTO);
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

        // DELETE api/<WardsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _wardRepository.Delete_Ward_By_Id(id);
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
