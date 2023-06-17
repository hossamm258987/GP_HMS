using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository;
using Hospital_Management_Service.Repository.IRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        protected ResponseDTO _response;
        private INurseRepository _nurseRepository;

        public NurseController(INurseRepository nurseRepository)
        {
            this._response = new ResponseDTO();
            _nurseRepository = nurseRepository;
        }
        // GET: api/<NurseController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<NurseDTO> nurseDTOs = await _nurseRepository.Get_Nurses();
                _response.Result = nurseDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<NurseController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                NurseDTO nurseDTO = await _nurseRepository.Get_Nurse_By_Id(id);
                _response.Result = nurseDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<NurseController>/name/nurse
        [HttpGet("name/{name}")]
        public async Task<object> Get(string Name)
        {
            try
            {
                List<NurseDTO> nurseDTO = await _nurseRepository.Get_Nurse_By_Name(Name);
                _response.Result = nurseDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<NurseController>/sec/Id
        [HttpGet("sec/{sid}")]
        public async Task<object> Get_By_Sec(int sid)
        {
            try
            {
                List<NurseDTO> nurseDTO = await _nurseRepository.Get_Nurse_By_Section(sid);
                _response.Result = nurseDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<NurseController>
        [HttpPost]
        public async Task<object> Post([FromBody] NurseDTO nurseDTO)
        {
            try
            {
                NurseDTO model = await _nurseRepository.Create_Update_Nurse(nurseDTO);
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

        // PUT api/<NurseController>/5
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] NurseDTO nurseDTO)
        {
            try
            {
                NurseDTO model = await _nurseRepository.Create_Update_Nurse(nurseDTO);
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

        // DELETE api/<NurseController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _nurseRepository.Delete_Nurse_By_Id(id);
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
